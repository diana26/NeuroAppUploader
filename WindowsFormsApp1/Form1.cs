using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using ArduinoUploader;
using ArduinoUploader.Hardware;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            getAvailablePortNames();
            label2.Visible = false;
        }

        void getAvailablePortNames()
        {
            String[] ports = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(comboBox1.Text == "")
                {
                    label2.Visible = true;
                    label2.Text = "Porfavor selecciona el puerto";    
                }
                else
                {
                    String portName;
                    portName = comboBox1.Text;
                    //label2.Text = portName;
                    var uploader = new ArduinoSketchUploader(
                        new ArduinoSketchUploaderOptions()
                        {
                            FileName = @"C:\Users\Diana\Documents\Arduino\Blink\Blink.ino.standard.hex",
                            PortName = portName,
                            ArduinoModel = ArduinoModel.UnoR3
                        });

                    uploader.UploadSketch();
                }
            }
            catch(UnauthorizedAccessException)
            {
                label2.Text = "Acceso denegado al puerto";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "")
                {
                    label2.Visible = true;
                    label2.Text = "Porfavor selecciona el puerto";
                }
                else
                {
                    String portName;
                    portName = comboBox1.Text;
                    //label2.Text = portName;
                    var uploader = new ArduinoSketchUploader(
                        new ArduinoSketchUploaderOptions()
                        {
                            FileName = @"C:\Users\Diana\Documents\Arduino\EEPROM_ClearMemory\EEPROM_ClearMemory.ino.standard.hex",
                            PortName = portName,
                            ArduinoModel = ArduinoModel.UnoR3
                        });

                    uploader.UploadSketch();
                }
            }
            catch (UnauthorizedAccessException)
            {
                label2.Text = "Acceso denegado al puerto";
            }
        }
    }
}
