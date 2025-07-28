namespace BLE3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnConnect = new Button();
            txtData = new TextBox();
            Plot1 = new ScottPlot.WinForms.FormsPlot();
            btnReset = new Button();
            groupBox1 = new GroupBox();
            btnDisconnect = new Button();
            groupBox2 = new GroupBox();
            btnClear = new Button();
            btnStart = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            LED1 = new Button();
            LED2 = new Button();
            LED3 = new Button();
            LED4 = new Button();
            LED5 = new Button();
            Value1 = new TextBox();
            Value2 = new TextBox();
            Value3 = new TextBox();
            Value4 = new TextBox();
            Value5 = new TextBox();
            D51 = new Button();
            D41 = new Button();
            D31 = new Button();
            D21 = new Button();
            D11 = new Button();
            D52 = new Button();
            D42 = new Button();
            D32 = new Button();
            D22 = new Button();
            D12 = new Button();
            D54 = new Button();
            D44 = new Button();
            D34 = new Button();
            D24 = new Button();
            D14 = new Button();
            D53 = new Button();
            D43 = new Button();
            D33 = new Button();
            D23 = new Button();
            D13 = new Button();
            txtRatio = new TextBox();
            LEDIndicate = new Button();
            label7 = new Label();
            pictureBox1 = new PictureBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            groupBox3 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(15, 30);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(156, 42);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // txtData
            // 
            txtData.Location = new Point(763, 42);
            txtData.Multiline = true;
            txtData.Name = "txtData";
            txtData.ScrollBars = ScrollBars.Vertical;
            txtData.Size = new Size(254, 52);
            txtData.TabIndex = 1;
            // 
            // Plot1
            // 
            Plot1.DisplayScale = 1.5F;
            Plot1.Location = new Point(21, 90);
            Plot1.Name = "Plot1";
            Plot1.Size = new Size(472, 527);
            Plot1.TabIndex = 2;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnReset.ForeColor = Color.Red;
            btnReset.Location = new Point(1133, 25);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(97, 69);
            btnReset.TabIndex = 3;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDisconnect);
            groupBox1.Controls.Add(btnConnect);
            groupBox1.Location = new Point(21, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(348, 86);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "BLE connecion";
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(177, 30);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(156, 42);
            btnDisconnect.TabIndex = 1;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnClear);
            groupBox2.Controls.Add(btnStart);
            groupBox2.Location = new Point(395, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(348, 86);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Classification";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(177, 30);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(156, 42);
            btnClear.TabIndex = 1;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(15, 30);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(156, 42);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(763, 14);
            label1.Name = "label1";
            label1.Size = new Size(93, 25);
            label1.TabIndex = 6;
            label1.Text = "Notebook";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(526, 133);
            label2.Name = "label2";
            label2.Size = new Size(104, 45);
            label2.TabIndex = 7;
            label2.Text = "Line 1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(526, 285);
            label3.Name = "label3";
            label3.Size = new Size(104, 45);
            label3.TabIndex = 8;
            label3.Text = "Line 2";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(526, 444);
            label4.Name = "label4";
            label4.Size = new Size(104, 45);
            label4.TabIndex = 9;
            label4.Text = "Line 3";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(526, 611);
            label5.Name = "label5";
            label5.Size = new Size(104, 45);
            label5.TabIndex = 10;
            label5.Text = "Line 4";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(526, 779);
            label6.Name = "label6";
            label6.Size = new Size(104, 45);
            label6.TabIndex = 11;
            label6.Text = "Line 5";
            // 
            // LED1
            // 
            LED1.Enabled = false;
            LED1.Location = new Point(654, 133);
            LED1.Name = "LED1";
            LED1.Size = new Size(97, 95);
            LED1.TabIndex = 12;
            LED1.UseVisualStyleBackColor = true;
            // 
            // LED2
            // 
            LED2.Enabled = false;
            LED2.Location = new Point(654, 285);
            LED2.Name = "LED2";
            LED2.Size = new Size(97, 95);
            LED2.TabIndex = 13;
            LED2.UseVisualStyleBackColor = true;
            // 
            // LED3
            // 
            LED3.Enabled = false;
            LED3.Location = new Point(654, 444);
            LED3.Name = "LED3";
            LED3.Size = new Size(97, 95);
            LED3.TabIndex = 14;
            LED3.UseVisualStyleBackColor = true;
            // 
            // LED4
            // 
            LED4.Enabled = false;
            LED4.Location = new Point(654, 611);
            LED4.Name = "LED4";
            LED4.Size = new Size(97, 95);
            LED4.TabIndex = 15;
            LED4.UseVisualStyleBackColor = true;
            // 
            // LED5
            // 
            LED5.Enabled = false;
            LED5.Location = new Point(654, 779);
            LED5.Name = "LED5";
            LED5.Size = new Size(97, 95);
            LED5.TabIndex = 16;
            LED5.UseVisualStyleBackColor = true;
            // 
            // Value1
            // 
            Value1.Enabled = false;
            Value1.Location = new Point(526, 197);
            Value1.Name = "Value1";
            Value1.Size = new Size(103, 31);
            Value1.TabIndex = 17;
            // 
            // Value2
            // 
            Value2.Enabled = false;
            Value2.Location = new Point(526, 349);
            Value2.Name = "Value2";
            Value2.Size = new Size(104, 31);
            Value2.TabIndex = 18;
            // 
            // Value3
            // 
            Value3.Enabled = false;
            Value3.Location = new Point(526, 508);
            Value3.Name = "Value3";
            Value3.Size = new Size(103, 31);
            Value3.TabIndex = 19;
            // 
            // Value4
            // 
            Value4.Enabled = false;
            Value4.Location = new Point(526, 675);
            Value4.Name = "Value4";
            Value4.Size = new Size(104, 31);
            Value4.TabIndex = 20;
            // 
            // Value5
            // 
            Value5.Enabled = false;
            Value5.Location = new Point(526, 837);
            Value5.Name = "Value5";
            Value5.Size = new Size(103, 31);
            Value5.TabIndex = 21;
            // 
            // D51
            // 
            D51.Enabled = false;
            D51.Location = new Point(29, 457);
            D51.Name = "D51";
            D51.Size = new Size(94, 91);
            D51.TabIndex = 26;
            D51.UseVisualStyleBackColor = true;
            D51.Visible = false;
            // 
            // D41
            // 
            D41.Enabled = false;
            D41.Location = new Point(29, 356);
            D41.Name = "D41";
            D41.Size = new Size(94, 91);
            D41.TabIndex = 25;
            D41.UseVisualStyleBackColor = true;
            D41.Visible = false;
            // 
            // D31
            // 
            D31.Enabled = false;
            D31.Location = new Point(29, 253);
            D31.Name = "D31";
            D31.Size = new Size(94, 91);
            D31.TabIndex = 24;
            D31.UseVisualStyleBackColor = true;
            D31.Visible = false;
            // 
            // D21
            // 
            D21.Enabled = false;
            D21.Location = new Point(29, 150);
            D21.Name = "D21";
            D21.Size = new Size(94, 91);
            D21.TabIndex = 23;
            D21.UseVisualStyleBackColor = true;
            D21.Visible = false;
            // 
            // D11
            // 
            D11.Enabled = false;
            D11.Location = new Point(29, 47);
            D11.Name = "D11";
            D11.Size = new Size(94, 91);
            D11.TabIndex = 22;
            D11.UseVisualStyleBackColor = true;
            D11.Visible = false;
            // 
            // D52
            // 
            D52.Enabled = false;
            D52.Location = new Point(131, 457);
            D52.Name = "D52";
            D52.Size = new Size(94, 91);
            D52.TabIndex = 31;
            D52.UseVisualStyleBackColor = true;
            D52.Visible = false;
            // 
            // D42
            // 
            D42.Enabled = false;
            D42.Location = new Point(131, 356);
            D42.Name = "D42";
            D42.Size = new Size(94, 91);
            D42.TabIndex = 30;
            D42.UseVisualStyleBackColor = true;
            D42.Visible = false;
            // 
            // D32
            // 
            D32.Enabled = false;
            D32.Location = new Point(131, 253);
            D32.Name = "D32";
            D32.Size = new Size(94, 91);
            D32.TabIndex = 29;
            D32.UseVisualStyleBackColor = true;
            D32.Visible = false;
            // 
            // D22
            // 
            D22.Enabled = false;
            D22.Location = new Point(131, 149);
            D22.Name = "D22";
            D22.Size = new Size(94, 91);
            D22.TabIndex = 28;
            D22.UseVisualStyleBackColor = true;
            D22.Visible = false;
            // 
            // D12
            // 
            D12.Enabled = false;
            D12.Location = new Point(131, 47);
            D12.Name = "D12";
            D12.Size = new Size(94, 91);
            D12.TabIndex = 27;
            D12.UseVisualStyleBackColor = true;
            D12.Visible = false;
            // 
            // D54
            // 
            D54.Enabled = false;
            D54.Location = new Point(336, 457);
            D54.Name = "D54";
            D54.Size = new Size(94, 91);
            D54.TabIndex = 41;
            D54.UseVisualStyleBackColor = true;
            D54.Visible = false;
            // 
            // D44
            // 
            D44.Enabled = false;
            D44.Location = new Point(336, 356);
            D44.Name = "D44";
            D44.Size = new Size(94, 91);
            D44.TabIndex = 40;
            D44.UseVisualStyleBackColor = true;
            D44.Visible = false;
            // 
            // D34
            // 
            D34.Enabled = false;
            D34.Location = new Point(336, 253);
            D34.Name = "D34";
            D34.Size = new Size(94, 91);
            D34.TabIndex = 39;
            D34.UseVisualStyleBackColor = true;
            D34.Visible = false;
            // 
            // D24
            // 
            D24.Enabled = false;
            D24.Location = new Point(336, 150);
            D24.Name = "D24";
            D24.Size = new Size(94, 91);
            D24.TabIndex = 38;
            D24.UseVisualStyleBackColor = true;
            D24.Visible = false;
            // 
            // D14
            // 
            D14.Enabled = false;
            D14.Location = new Point(336, 47);
            D14.Name = "D14";
            D14.Size = new Size(94, 91);
            D14.TabIndex = 37;
            D14.UseVisualStyleBackColor = true;
            D14.Visible = false;
            // 
            // D53
            // 
            D53.Enabled = false;
            D53.Location = new Point(233, 457);
            D53.Name = "D53";
            D53.Size = new Size(94, 91);
            D53.TabIndex = 36;
            D53.UseVisualStyleBackColor = true;
            D53.Visible = false;
            // 
            // D43
            // 
            D43.Enabled = false;
            D43.Location = new Point(233, 356);
            D43.Name = "D43";
            D43.Size = new Size(94, 91);
            D43.TabIndex = 35;
            D43.UseVisualStyleBackColor = true;
            D43.Visible = false;
            // 
            // D33
            // 
            D33.Enabled = false;
            D33.Location = new Point(233, 253);
            D33.Name = "D33";
            D33.Size = new Size(94, 91);
            D33.TabIndex = 34;
            D33.UseVisualStyleBackColor = true;
            D33.Visible = false;
            // 
            // D23
            // 
            D23.Enabled = false;
            D23.Location = new Point(233, 149);
            D23.Name = "D23";
            D23.Size = new Size(94, 91);
            D23.TabIndex = 33;
            D23.UseVisualStyleBackColor = true;
            D23.Visible = false;
            // 
            // D13
            // 
            D13.Enabled = false;
            D13.Location = new Point(233, 47);
            D13.Name = "D13";
            D13.Size = new Size(94, 91);
            D13.TabIndex = 32;
            D13.UseVisualStyleBackColor = true;
            D13.Visible = false;
            // 
            // txtRatio
            // 
            txtRatio.Location = new Point(1040, 48);
            txtRatio.Name = "txtRatio";
            txtRatio.Size = new Size(73, 31);
            txtRatio.TabIndex = 48;
            // 
            // LEDIndicate
            // 
            LEDIndicate.Enabled = false;
            LEDIndicate.Location = new Point(879, 172);
            LEDIndicate.Name = "LEDIndicate";
            LEDIndicate.Size = new Size(35, 35);
            LEDIndicate.TabIndex = 49;
            LEDIndicate.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1040, 14);
            label7.Name = "label7";
            label7.Size = new Size(53, 25);
            label7.TabIndex = 50;
            label7.Text = "Ratio";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.handwritting_graph;
            pictureBox1.Location = new Point(66, 644);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(400, 235);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 51;
            pictureBox1.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(84, 793);
            label8.Name = "label8";
            label8.Size = new Size(178, 32);
            label8.TabIndex = 52;
            label8.Text = "Hand Writting";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.White;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(84, 825);
            label9.Name = "label9";
            label9.Size = new Size(165, 32);
            label9.TabIndex = 53;
            label9.Text = "Classification";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.Green;
            label10.Location = new Point(929, 166);
            label10.Name = "label10";
            label10.Size = new Size(105, 45);
            label10.TabIndex = 54;
            label10.Text = "Ready";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label11.ForeColor = Color.Yellow;
            label11.Location = new Point(1040, 166);
            label11.Name = "label11";
            label11.Size = new Size(129, 45);
            label11.TabIndex = 55;
            label11.Text = "Waiting";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(D54);
            groupBox3.Controls.Add(D44);
            groupBox3.Controls.Add(D34);
            groupBox3.Controls.Add(D24);
            groupBox3.Controls.Add(D14);
            groupBox3.Controls.Add(D53);
            groupBox3.Controls.Add(D43);
            groupBox3.Controls.Add(D33);
            groupBox3.Controls.Add(D23);
            groupBox3.Controls.Add(D13);
            groupBox3.Controls.Add(D52);
            groupBox3.Controls.Add(D42);
            groupBox3.Controls.Add(D32);
            groupBox3.Controls.Add(D22);
            groupBox3.Controls.Add(D12);
            groupBox3.Controls.Add(D51);
            groupBox3.Controls.Add(D41);
            groupBox3.Controls.Add(D31);
            groupBox3.Controls.Add(D21);
            groupBox3.Controls.Add(D11);
            groupBox3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox3.Location = new Point(794, 259);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(457, 585);
            groupBox3.TabIndex = 56;
            groupBox3.TabStop = false;
            groupBox3.Text = "Results";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1263, 909);
            Controls.Add(groupBox3);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(pictureBox1);
            Controls.Add(label7);
            Controls.Add(LEDIndicate);
            Controls.Add(txtRatio);
            Controls.Add(Value5);
            Controls.Add(Value4);
            Controls.Add(Value3);
            Controls.Add(Value2);
            Controls.Add(Value1);
            Controls.Add(LED5);
            Controls.Add(LED4);
            Controls.Add(LED3);
            Controls.Add(LED2);
            Controls.Add(LED1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnReset);
            Controls.Add(Plot1);
            Controls.Add(txtData);
            Name = "Form1";
            Text = "Hand Writing Classification @Copyright: Tianda Fu";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConnect;
        private TextBox txtData;
        private ScottPlot.WinForms.FormsPlot Plot1;
        private Button btnReset;
        private GroupBox groupBox1;
        private Button btnDisconnect;
        private GroupBox groupBox2;
        private Button btnClear;
        private Button btnStart;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button LED1;
        private Button LED2;
        private Button LED3;
        private Button LED4;
        private Button LED5;
        private TextBox Value1;
        private TextBox Value2;
        private TextBox Value3;
        private TextBox Value4;
        private TextBox Value5;
        private Button D51;
        private Button D41;
        private Button D31;
        private Button D21;
        private Button D11;
        private Button D52;
        private Button D42;
        private Button D32;
        private Button D22;
        private Button D12;
        private Button D54;
        private Button D44;
        private Button D34;
        private Button D24;
        private Button D14;
        private Button D53;
        private Button D43;
        private Button D33;
        private Button D23;
        private Button D13;
        private TextBox txtRatio;
        private Button LEDIndicate;
        private Label label7;
        private PictureBox pictureBox1;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private GroupBox groupBox3;
    }
}
