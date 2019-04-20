using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProsjektGruppe8
{
    class FileHandler
    {
        public FileHandler()
        {

        }
        static public string ReadFromFile(string filename)//Lese en tekst fra en string. Brukes til passordet
        {
            string text = "";
            try
            {
                var filestream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(filestream);
                text = sr.ReadToEnd();
                sr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return text;
        }
        static public void WriteIntervalToFile(int interval, string filename)//Brukes til å skrive lese og loggeintervallene 
        {
            try
            {
            StreamWriter sw = new StreamWriter(filename,false);
            sw.Write(interval.ToString());
            sw.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
