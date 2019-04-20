using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProsjektGruppe8
{
    class ArduinoCom:SerialPort//Arver Seriell port klassen
    {
        public event EventHandler usbTimeout;
        ComboBox cbo;
        public ArduinoCom(int baudRate, ComboBox comboBox)
        {
            cbo = comboBox;
            LoadPortsInComboBox(cbo);
            BaudRate = baudRate;
            WriteTimeout = 500;//Timeout for å skrive til seriellporten
            ReadTimeout = 500;//Timeout for å lese til seriellporten
        }
        public string[] getValues()//Ber om verdier, mottar og laster det inn i et array
        {
            string[] values = new string[3];
            string message;
            if (IsOpen)//Hvis kommunikasjonsporten er åpen
            {
                try
                {
                    Write("1");//be om veriene
                    message = ReadLine();//Last det i en string
                    values = message.Split(';');//Splitt opp stringen til et array
                }
                catch (Exception ex)
                {
                    usbTimeout(this, new EventArgs());//Lager en event som brukes til å skru av timeren så ikke meldingsboksen kommer mange ganger
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                usbTimeout(this, new EventArgs());
                MessageBox.Show("Porten er ikke åpen, er arduino plugget inn?", "Port Lukket");
                for (int i = 1; i <= values.Length; i++)
                {
                    values[i - 1] = null;
                }
            }
            return values;
        }
        public void LoadPortsInComboBox(ComboBox cbo)//Laster tilgjengelige seriellporter til en combobox
        {
            string[] portNames = GetPortNames();
            cbo.Items.Clear();
            foreach (string port in portNames)
            {
                cbo.Items.Add(port);
            }
            cbo.SelectedIndex = 0;//Setter dropdown menyen til den første 
        }
        public void OpenCom()
        {
            if (!IsOpen)//Hvis porten er lukket
            {
                try
                {
                    PortName = cbo.Text;
                    Open();//Åpne porten
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else//Hvis ikke porten er lukket
            {
                Close();//Lukk porten
                PortName = cbo.Text;
                Open();//åpne igjen
            }
        }
    }
}
