# Wireless Neuromorphic Code

This repository contains the code implementation for "A Fully Stretchable, Wireless Neuromorphic Patch for AI-driven Human Interfaces".


## Repository Structure

```
WirelessNeuromorphicCode/
├── braille_digits_classification/      # Braille digit classification demo
├── braille_digits_real_time_classification/  # Real-time Braille digit classification
└── chronic_kidney_disease_classification/    # CKD prediction demo
```

## Applications

### Tactile-Based Braille Digit Recognition Using Reservoir Computing
- **Location**: `braille_digits_classification/`
- **Notebooks**: 
  - `braille_digits_demo.ipynb`: Main demonstration
  - `preprocess.ipynb`: Extracts tactile features by identifying the last minimum peak in each Braille dot scan segment
- **Data**:
  - `processed_digits.csv`: Processed reservoir output signals with anomalies removed

### Real-Time BLE-Based Braille Digit Classification System
- **Location**: `braille_digits_real_time_classification/`
- **Platform**: C# Windows application

### Multimodal Sensing with Reservoir Data Fusion for Disease Prediction
- **Location**: `chronic_kidney_disease_classification/`
- **Notebooks**: 
  - `ckd_reservoir_demo.ipynb`: Main demonstration
  - `preprocessing.ipynb`: Computes voltage differences between paired reservoir peaks and baseline for multimodal feature extraction
- **Data**:
  - `kidney_disease.csv`: Original CKD dataset
  - `kidney_4features_reservoir_input.csv`: Scaled subset of the original dataset used as input for the reservoir computing device
  - `reservoir_2set_v2.csv`: Processed reservoir output signals for BGR and WC features only
  - `reservoir_4set_v2.csv`: Processed reservoir output signals compressing 4 features (POT+BGR, SU+WC) into 2 reservoir states

## Python Requirements

- Python 3.10+
- Jupyter Notebook
- Required packages:
  ```
  numpy
  pandas
  matplotlib
  seaborn
  scikit-learn
  scipy
  xgboost
  lightgbm
  optuna
  ```

## C# Requirements

- .NET 6.0 SDK
- Windows 10 SDK (version 19041 or later)
- NuGet packages:
  - ScottPlot.WinForms (v5.0.47)
  - System.Windows.Forms.DataVisualization


## Citation
_Coming soon_