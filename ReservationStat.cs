using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Parking_Finder
{
    public partial class ReservationStat : Form
    {
        Controller controllerObj;
        public ReservationStat(int m1,int m2,int m3,int y1,int y2,int y3,int sptid)
        {
            InitializeComponent();
            controllerObj = new Controller();
            MySqlDataReader reader = controllerObj.Month3(m1, m2, m3, y1, y2, y3, sptid);
            chart1.DataSource = reader;
            chart1.Series[0].YValueMembers = "TOTAL_MONTH1";
            chart1.Series[1].YValueMembers = "TOTAL_MONTH2";
            chart1.Series[2].YValueMembers = "TOTAL_MONTH3";
            chart1.Series[0].LegendText = m1.ToString()+"/"+y1.ToString();
            chart1.Series[1].LegendText = m2.ToString() + "/" + y2.ToString();
            chart1.Series[2].LegendText = m3.ToString() + "/" + y3.ToString();
            chart1.Series[3].LegendText = "Current Month";
            chart1.DataBind();
            reader.Close();
            int res = controllerObj.Current(sptid);
            chart1.Series[3].Points.AddY(res);
            
            
        }

        private void ReservationStat_Load(object sender, EventArgs e)
        {

        }

        private void ReservationStat_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            controllerObj.TerminateConnection();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
