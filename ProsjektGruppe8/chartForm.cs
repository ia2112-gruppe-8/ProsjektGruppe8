using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProsjektGruppe8
{
    public partial class chartForm : Form
    {
        public chartForm()
        {
            InitializeComponent();
            InitializeGraph();
            dbInterface.LoadTempValuesInChart(chart1);
        }
        void InitializeGraph()//en metode for å initialisere grafen
        {
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Hours;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM-yyyy HH:mm";//Formatering av datoaksen

        }
    }
}
