using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<String> tList = new List<String>();

            SerialcomboBox.Items.Clear();

            foreach (string s in SerialPort.GetPortNames())
            {
                tList.Add(s);
            }

            tList.Sort();
            SerialcomboBox.Items.Add("Select COM port...");
            SerialcomboBox.Items.AddRange(tList.ToArray());
            SerialcomboBox.SelectedIndex = 0;
        }

        private void SerialcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((SerialcomboBox.SelectedIndex != 0) &&
                 !(serialMaster.IsOpen))
            {
                serialMaster.PortName = SerialcomboBox.SelectedItem.ToString();
                serialMaster.BaudRate = 115200;
                serialMaster.DataBits = 8;
                serialMaster.Parity = Parity.None;
                serialMaster.StopBits = StopBits.One;

                serialMaster.ReadTimeout = 2000;
                serialMaster.WriteTimeout = 2000;

                try
                {
                    serialMaster.Open();
                    serialMaster.DiscardNull.ToString();
                    serialMaster.Encoding.ToString();
                    InputTextBox.Enabled = true;
                    OutputTextBox.Enabled = true;
                    OutputTextBox.Text = "COM Port opend ...\n";
                  
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message + "Please configure correct COM port", "Error!");
                    serialMaster.Close();
                    return;
                }

            }
        }

        private void SerialcomboBox_Click(object sender, EventArgs e)
        {
            List<String> tList = new List<String>();

            SerialcomboBox.Items.Clear();

            foreach (string s in SerialPort.GetPortNames())
            {
                tList.Add(s);
            }

            tList.Sort();
            SerialcomboBox.Items.Add("Select COM port...");
            SerialcomboBox.Items.AddRange(tList.ToArray());
            SerialcomboBox.SelectedIndex = 0;
        }

        string inputString;
        private void InputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char[] byteBuff = new char[1];
            byteBuff[0] = e.KeyChar;
            inputString = string.Concat(inputString, e.KeyChar);
            if ((e.KeyChar == '\r') && (serialMaster.IsOpen))
            {
                serialMaster.WriteLine(inputString);
                inputString = "";
                InputTextBox.ScrollToCaret();
            }
        }
        string masterRxData;
        private void serialMaster_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            masterRxData = "";
            masterRxData = serialMaster.ReadExisting();
            
            this.Invoke(new EventHandler(displayOutputString));

        }
        private void displayOutputString(object o, EventArgs e)
        {

            OutputTextBox.AppendText(masterRxData);
            masterRxData = "";
            OutputTextBox.ScrollToCaret();
        }
    }
}
