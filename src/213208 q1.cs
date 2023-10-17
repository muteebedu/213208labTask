// 213208 Muteeb Ur Rehman
using System;
using System.Windows.Forms;

namespace UnitConverterApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Populate combo boxes with unit options
            InitializeUnitComboBoxes();
        }

        private void InitializeUnitComboBoxes()
        {
            // Time units
            comboBoxTimeFrom.Items.Add("Hours");
            comboBoxTimeFrom.Items.Add("Minutes");
            comboBoxTimeFrom.Items.Add("Seconds");
            comboBoxTimeTo.Items.AddRange(comboBoxTimeFrom.Items);

            // Area units
            comboBoxAreaFrom.Items.Add("Foot");
            comboBoxAreaFrom.Items.Add("Inch");
            comboBoxAreaFrom.Items.Add("Meter");
            comboBoxAreaTo.Items.AddRange(comboBoxAreaFrom.Items);

            // Length units
            comboBoxLengthFrom.Items.Add("Kilometer");
            comboBoxLengthFrom.Items.Add("Meter");
            comboBoxLengthFrom.Items.Add("Centimeter");
            comboBoxLengthTo.Items.AddRange(comboBoxLengthFrom.Items);

            // Temperature units
            comboBoxTemperatureFrom.Items.Add("Celsius");
            comboBoxTemperatureFrom.Items.Add("Fahrenheit");
            comboBoxTemperatureFrom.Items.Add("Kelvin");
            comboBoxTemperatureTo.Items.AddRange(comboBoxTemperatureFrom.Items);
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            // Get user inputs
            string unitType = tabControl.SelectedTab.Text;
            ComboBox fromComboBox = GetFromComboBox(unitType);
            ComboBox toComboBox = GetToComboBox(unitType);
            double inputValue;
            if (!double.TryParse(textBoxValue.Text, out inputValue))
            {
                MessageBox.Show("Please enter a valid number for conversion.");
                return;
            }

            // Perform the conversion
            double result = ConvertUnits(unitType, fromComboBox.Text, toComboBox.Text, inputValue);

            // Display the result
            labelResult.Text = $"{inputValue} {fromComboBox.Text} = {result} {toComboBox.Text}";
        }

        private ComboBox GetFromComboBox(string unitType)
        {
            switch (unitType)
            {
                case "Time":
                    return comboBoxTimeFrom;
                case "Area":
                    return comboBoxAreaFrom;
                case "Length":
                    return comboBoxLengthFrom;
                case "Temperature":
                    return comboBoxTemperatureFrom;
                default:
                    return null;
            }
        }

        private ComboBox GetToComboBox(string unitType)
        {
            switch (unitType)
            {
                case "Time":
                    return comboBoxTimeTo;
                case "Area":
                    return comboBoxAreaTo;
                case "Length":
                    return comboBoxLengthTo;
                case "Temperature":
                    return comboBoxTemperatureTo;
                default:
                    return null;
            }
        }

        private double ConvertUnits(string unitType, string fromUnit, string toUnit, double value)
        {
            // Perform unit conversions here based on unitType, fromUnit, toUnit, and value.
            // Implement conversion logic for each unit type as needed.
            // This is a simplified example, and you can expand this with actual conversion formulas.

            if (unitType == "Time")
            {
                return TimeConverter.Convert(fromUnit, toUnit, value);
            }
            else if (unitType == "Area")
            {
                return AreaConverter.Convert(fromUnit, toUnit, value);
            }
            else if (unitType == "Length")
            {
                return LengthConverter.Convert(fromUnit, toUnit, value);
            }
            else if (unitType == "Temperature")
            {
                return TemperatureConverter.Convert(fromUnit, toUnit, value);
            }
            else
            {
                throw new NotImplementedException("Conversion not implemented for the selected unit type.");
            }
        }
    }

    // Create separate converter classes for each unit type (Time, Area, Length, Temperature).
    public class TimeConverter
    {
        public static double Convert(string fromUnit, string toUnit, double value)
        {
            if (fromUnit == "Hours" && toUnit == "Minutes")
                return value * 60;
            if (fromUnit == "Minutes" && toUnit == "Hours")
                return value / 60;
            if (fromUnit == "Minutes" && toUnit == "Seconds")
                return value * 60;
            if (fromUnit == "Seconds" && toUnit == "Minutes")
                return value / 60;
            // Add more conversions as needed
            return value;
        }
    }

    // Create similar classes for Area, Length, and Temperature conversions.

    public partial class MainForm : Form
    {
        // Add the rest of your Windows Forms code here.
    }
}