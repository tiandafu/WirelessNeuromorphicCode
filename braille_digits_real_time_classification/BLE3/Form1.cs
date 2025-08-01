using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Storage.Streams;
using ScottPlot.WinForms; // Import ScottPlot

namespace BLE3
{
    public partial class Form1 : Form
    {
        private BluetoothLEDevice bleDevice;
        private GattCharacteristic notifyCharacteristic;

        // Data storage
        private readonly double[] yData = new double[100]; // Stores the most recent 1000 data points (up to 10 seconds)
        private readonly double[] xData = new double[100]; // Corresponding x-axis time points (unit: ms)
        //private int currentIndex = 0; // Current data point index

        private int? suddenChangeIndex = null; // Index of the sudden change point
        private bool led1State = false; // State of LED1
        private bool isProcessing = false; // Controls the real-time processing switch
        private int currentIndex = 0; // Current LED and Value index (0-4)
        private double[] values = new double[5]; // Stores the five Value values
        private bool[] leds = new bool[5]; // Stores the states of the five LEDs
        private bool isStable = false; // Determines if the current window is stable
        private Color ledDefaultColor;

        public Form1()
        {
            InitializeComponent();
            InitializePlot();
            ///here
            txtRatio.Text = "1"; // Set the default value of the textbox to 1
            ledDefaultColor = LEDIndicate.BackColor; // Store the default color of LEDIndicate
        }

        private void InitializePlot()
        {
            // Initialize the plot
            for (int i = 0; i < xData.Length; i++)
                xData[i] = i * 0.05; // Initialize x-axis to 0-10 seconds (10ms per point)

            Plot1.Plot.Add.Scatter(xData, yData); // Add an empty plot
            Plot1.Plot.Axes.SetLimits(0, 5, 0, 5.5); // Fix the x-axis range to voltage (0-5.5V)
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // Hardcoded target device ID
                string targetDeviceId = "BluetoothLE#BluetoothLE8c:17:59:a6:25:56-00:a0:50:44:b3:29";

                // Connect to the device using the ID
                bleDevice = await BluetoothLEDevice.FromIdAsync(targetDeviceId);
                if (bleDevice == null)
                {
                    MessageBox.Show("Unable to connect to the device. Ensure the device is on and within range.");
                    return;
                }

                // Search for GATT services
                var gattServices = await bleDevice.GetGattServicesAsync();
                foreach (var service in gattServices.Services)
                {
                    // Output service UUID
                    txtData.AppendText($"Service UUID: {service.Uuid}\n");

                    var characteristics = await service.GetCharacteristicsAsync();
                    foreach (var characteristic in characteristics.Characteristics)
                    {
                        // Output characteristic UUID
                        txtData.AppendText($"  Characteristic UUID: {characteristic.Uuid}\n");

                        // Check if the characteristic supports Notify
                        if (characteristic.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Notify))
                        {
                            notifyCharacteristic = characteristic;
                            txtData.AppendText($"  -> Found a characteristic that supports notification!\n");
                            break;
                        }
                    }

                    if (notifyCharacteristic != null)
                        break;
                }

                if (notifyCharacteristic == null)
                {
                    MessageBox.Show("No characteristic that supports notifications was found.");
                    return;
                }

                // Attempt to enable notifications
                var status = await notifyCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(
                    GattClientCharacteristicConfigurationDescriptorValue.Notify);

                if (status != GattCommunicationStatus.Success)
                {
                    // Attempt to enable Indicate
                    status = await notifyCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(
                        GattClientCharacteristicConfigurationDescriptorValue.Indicate);
                }

                if (status == GattCommunicationStatus.Success)
                {
                    notifyCharacteristic.ValueChanged += NotifyCharacteristic_ValueChanged;
                    //MessageBox.Show("Connection successful and notifications enabled!");
                }
                else
                {
                    MessageBox.Show($"Failed to enable notifications, status: {status}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void NotifyCharacteristic_ValueChanged(GattCharacteristic sender, GattValueChangedEventArgs args)
        {
            var reader = DataReader.FromBuffer(args.CharacteristicValue);
            var data = new byte[reader.UnconsumedBufferLength];
            reader.ReadBytes(data);

            // Update UI with raw ADC data
            string hexData = BitConverter.ToString(data).Replace("-", " ");
            this.Invoke((MethodInvoker)delegate
            {
                txtData.AppendText(hexData + Environment.NewLine);
            });

            if (data.Length >= 3 && data[0] == 0xFE) // Check if the data matches the format FE xx xx
            {
                int adcValue = (data[1] << 8) | data[2]; // Parse the high and low bytes to decimal
                double voltage = ConvertToVoltage(adcValue); // Convert to voltage

                // Display the voltage value in the text box
                this.Invoke((MethodInvoker)delegate
                {
                    txtData.AppendText($"Decimal value: {adcValue}\n");
                    txtData.AppendText($"Voltage value: {voltage:F3} V\n");
                    UpdatePlot(voltage); // Update the plot with voltage
                });
            }
        }

        private double ConvertToVoltage(int adcValue)
        {
            const double referenceVoltage = 5.5; // Reference voltage in volts
            const int adcResolution = 65536; // 16-bit ADC
            return (adcValue * referenceVoltage) / adcResolution;
        }

        private void UpdatePlot(double voltage)
        {
            // Shift the array: move data to the left by one position, discarding the earliest data point
            Array.Copy(yData, 1, yData, 0, yData.Length - 1);
            yData[^1] = voltage; // Add the new voltage value to the last position

            // Smooth the data using 5-point moving average
            double[] smoothedData = new double[yData.Length];
            SmoothData(yData, smoothedData);

            // Update the plot (always refresh)
            double minY = smoothedData.Min();
            double maxY = smoothedData.Max();
            double padding = (maxY - minY) * 0.1;
            if (padding == 0) padding = 0.1;

            Plot1.Plot.Clear();
            Plot1.Plot.Add.Scatter(xData, smoothedData); // Plot smoothed data
            Plot1.Plot.Axes.SetLimits(0, 5, minY - padding, maxY + padding);
            Plot1.Refresh();

            // If real-time processing is not enabled or all LEDs are already assigned, return immediately
            if (!isProcessing || currentIndex >= 5)
            {
                LEDIndicate.BackColor = ledDefaultColor; // Restore default color
                return;
            }

            // Check if a sudden change has been detected and if the signal is stable
            if (!leds[currentIndex])
            {
                LEDIndicate.BackColor = Color.Green; // Green when searching for a sudden change point
                for (int i = 0; i < smoothedData.Length - 4; i++)
                {
                    if (Math.Abs(smoothedData[i + 4] - smoothedData[i]) > 0.03) // Detect >50mV change
                    {
                        suddenChangeIndex = i;
                        break;
                    }
                }

                if (suddenChangeIndex.HasValue && suddenChangeIndex.Value == 0)
                {
                    // threshold
                    double noiseThreshold = 0.005;

                    // find last valley
                    int valleyIndex = FindLastLocalValley(smoothedData, noiseThreshold);
                    if (valleyIndex != -1) // if find valley
                    {
                        double delta = smoothedData[suddenChangeIndex.Value] - smoothedData[valleyIndex];

                        // update LED and value
                        this.Invoke((MethodInvoker)delegate
                        {
                            values[currentIndex] = -delta;
                            leds[currentIndex] = true;

                            Control led = this.Controls[$"LED{currentIndex + 1}"];
                            Control value = this.Controls[$"Value{currentIndex + 1}"];
                            if (led != null) led.BackColor = Color.Green;
                            //if (value != null) value.Text = $"{delta:F3} V";

                            if (currentIndex == 4)
                            {
                                double ratio;
                                if (!double.TryParse(txtRatio.Text, out ratio)) ratio = 1.0;
                                Classification(values, ratio);
                                return;
                            }
                        });
                    }
                    suddenChangeIndex = null;
                }

            }
            else if (currentIndex < 4) // Wait for stability before processing the next Value
            {
                LEDIndicate.BackColor = Color.Yellow; // Yellow while waiting for stabilization
                isStable = (maxY - minY) < 0.04; // Stable if fluctuation is less than 40mV

                if (isStable) currentIndex++;
            }
        }

        private int FindLastLocalValley(double[] data, double noiseThreshold)
        {
            for (int i = data.Length - 4; i > 2; i--) 
            {
                if ((data[i] < data[i - 3] - noiseThreshold) && (data[i] < data[i + 3] - noiseThreshold))
                {
                    return i; 
                }
            }
            return -1;
        }


        private void SmoothData(double[] inputData, double[] outputData)
        {
            // 5-point smoothing
            for (int i = 2; i < inputData.Length - 2; i++)
            {
                outputData[i] = (inputData[i - 2] + inputData[i - 1] + inputData[i] + inputData[i + 1] + inputData[i + 2]) / 5.0;
            }

            // Handle boundaries (copy directly for simplicity)
            outputData[0] = inputData[0];
            outputData[1] = inputData[1];
            outputData[inputData.Length - 2] = inputData[inputData.Length - 2];
            outputData[inputData.Length - 1] = inputData[inputData.Length - 1];
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            Application.Restart(); // Restart the application
            Environment.Exit(0); // Ensure the process is terminated
        }

        private async void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (notifyCharacteristic != null)
                {
                    // Disable notifications or indications
                    var status = await notifyCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(
                        GattClientCharacteristicConfigurationDescriptorValue.None);

                    if (status == GattCommunicationStatus.Success)
                    {
                        notifyCharacteristic.ValueChanged -= NotifyCharacteristic_ValueChanged;
                        txtData.AppendText("Notifications successfully disabled.\n");
                    }
                    else
                    {
                        txtData.AppendText($"Failed to disable notifications, status: {status}\n");
                    }

                    notifyCharacteristic = null;
                }

                if (bleDevice != null)
                {
                    // Close the connection and release resources
                    bleDevice.Dispose();
                    bleDevice = null;
                    txtData.AppendText("Device successfully disconnected.\n");
                }
            }
            catch (Exception ex)
            {
                txtData.AppendText($"Error during disconnection: {ex.Message}\n");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Reset all values
            for (int i = 0; i < 5; i++)
            {
                Control led = this.Controls[$"LED{i + 1}"];
                Control value = this.Controls[$"Value{i + 1}"];
                if (led != null) led.BackColor = SystemColors.Control;
                if (value != null) value.Text = "";
                leds[i] = false;
                values[i] = 0;
            }

            currentIndex = 0; // Reset the index
            isStable = false; // Reset the stability status

            // Hide specific controls
            Control[] controlsToHide =
            {
                D11, D12, D13, D14,
                D21, D22, D23, D24,
                D31, D32, D33, D34,
                D41, D42, D43, D44,
                D51, D52, D53, D54
            };

            foreach (var control in controlsToHide)
            {
                control.Visible = false; // Set the control to be invisible
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Toggle the processing state
            isProcessing = !isProcessing;

            if (isProcessing)
            {
                // Start processing: change button color to green
                btnStart.BackColor = Color.Green;
            }
            else
            {
                // Stop processing: restore button color to default
                btnStart.BackColor = SystemColors.Control;

                // Reset LEDs and Values
                LEDIndicate.BackColor = ledDefaultColor; // recover LEDIndicate default color
                suddenChangeIndex = null; // Reset sudden change detection
            }
        }


        private void Classification(double[] values, double ratio)
        {
            //Multiply each element in values by ratio
            for (int i = 0; i < values.Length; i++)
            {
                values[i] *= ratio;
            }

            // StandardScaler parameters
            double[] mean = { 0.04192862, 0.02102568, 0.04017595, 0.02136306, 0.03631083 };
            double[] scale = { 0.03422924, 0.0140438, 0.0290996, 0.01061234, 0.02267418 };

            // LogisticRegression parameters
            double[,] coef = {
            { 0.60751908, 0.26042069, -2.49009985, 1.03886047, 2.17981164 },
            { -1.48241357, -1.08335919, -3.01759085, -2.5325831, -2.43453153 },
            { -1.4503549, 1.0045995, -0.80728441, -3.50363554, 2.21044303 },
            { -1.73949691, 0.81801096, -0.98275389, 3.60903677, -2.45694002 },
            { -0.89036444, -0.65832296, 2.8511515, -1.59187467, -1.70770785 },
            { 2.92537482, -3.28743408, 1.00739903, -0.33483189, 0.72136467 },
            { -2.54302363, -1.41327868, 2.03370868, 1.75823149, 1.67459083 },
            { 2.31701499, 2.06159548, -1.83650146, -0.71415199, -1.11159695 },
            { 0.70322288, 1.06463529, 1.14623816, 1.71094086, 2.16194733 },
            { 1.55252169, 1.233133, 2.09573309, 0.56000762, -1.23738115 }
            };
            double[] intercept = { 2.20718376, -3.37012655, -1.01544374, 1.00671158, 0.57405544, 1.14423176, -0.24153375, -0.3719324, -0.44371251, 0.51056641 };


            double[] scaledValues = StandardScalerTransform(values, mean, scale);
            double[] probabilities = LogisticRegressionPredictProba(scaledValues, coef, intercept);
            int predictedClass = ArgMax(probabilities); // this is the predicted class from 0-9
            ShowPrediction(predictedClass);
        }

        private void ShowPrediction(int predictedClass)
        {
            // 1. setup button 0-9
            Dictionary<int, Control[]> numberPatterns = new Dictionary<int, Control[]>()
            {
                { 0, new Control[] { D11, D12, D13, D14, D21, D24, D31, D34, D41, D44, D51, D52, D53, D54 } }, //  0
                { 1, new Control[] { D13, D23, D33, D43, D53 } }, //  1
                { 2, new Control[] { D12, D13, D24, D33, D42, D51, D52, D53, D54 } }, //  2
                { 3, new Control[] { D11, D12, D13, D24, D31, D32, D33, D44, D51, D52, D53} }, //  3
                { 4, new Control[] { D11, D13, D21, D23, D31, D32, D33, D34, D43, D53 } }, //  4
                { 5, new Control[] { D12, D13, D14, D22, D32, D33, D34, D44, D51, D52, D53, D54 } }, //  5
                { 6, new Control[] { D11, D12, D13, D21, D31, D32, D33, D34, D41, D44, D51, D52, D53, D54 } }, //  6
                { 7, new Control[] { D11, D12, D13, D14, D24, D33, D43, D53 } }, //  7
                { 8, new Control[] { D11, D12, D13, D14, D21, D24, D31, D32, D33, D34, D41, D44, D51, D52, D53, D54 } }, //  8
                { 9, new Control[] { D11, D12, D13, D14, D21, D24, D31, D32, D33, D34, D44, D54} }  //  9
            };

            // 2. reset all button
            foreach (Control control in this.Controls)
            {
                if (control.Name.StartsWith("D"))
                {
                    control.Visible = false;
                    control.BackColor = DefaultBackColor; // reset color
                }
            }

            // 3. display result
            if (numberPatterns.ContainsKey(predictedClass))
            {
                Control[] controlsToShow = numberPatterns[predictedClass];
                foreach (var control in controlsToShow)
                {
                    control.Visible = true; 
                    control.BackColor = Color.Red;
                }
            }
        }

        static double[] StandardScalerTransform(double[] values, double[] mean, double[] scale)
        {
            double[] scaled = new double[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                scaled[i] = (values[i] - mean[i]) / scale[i];
            }
            return scaled;
        }

        static double[] LogisticRegressionPredictProba(double[] values, double[,] coef, double[] intercept)
        {
            int nClasses = coef.GetLength(0);
            int nFeatures = coef.GetLength(1);
            double[] logits = new double[nClasses];

            for (int i = 0; i < nClasses; i++)
            {
                double sum = intercept[i];
                for (int j = 0; j < nFeatures; j++)
                {
                    sum += coef[i, j] * values[j];
                }
                logits[i] = sum;
            }

            double[] probabilities = Softmax(logits);
            return probabilities;
        }

        static double[] Softmax(double[] logits)
        {
            double maxLogit = double.MinValue;
            for (int i = 0; i < logits.Length; i++)
            {
                if (logits[i] > maxLogit)
                    maxLogit = logits[i];
            }

            double sumExp = 0.0;
            double[] expLogits = new double[logits.Length];
            for (int i = 0; i < logits.Length; i++)
            {
                expLogits[i] = Math.Exp(logits[i] - maxLogit);
                sumExp += expLogits[i];
            }

            double[] probabilities = new double[logits.Length];
            for (int i = 0; i < logits.Length; i++)
            {
                probabilities[i] = expLogits[i] / sumExp;
            }

            return probabilities;
        }

        static int ArgMax(double[] probabilities)
        {
            int maxIndex = 0;
            double maxValue = probabilities[0];
            for (int i = 1; i < probabilities.Length; i++)
            {
                if (probabilities[i] > maxValue)
                {
                    maxValue = probabilities[i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }


    }
}
