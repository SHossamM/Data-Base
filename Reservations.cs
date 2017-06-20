using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parking_Finder
{
    public partial class Reservations : Form
    {
        Controller controllerObj;
        int spotid;
        public Reservations(int sid)
        {
            InitializeComponent();
            controllerObj = new Controller();
            spotid=sid;
            DataTable d = controllerObj.SelectDepTimeFromReservation(spotid);
            MovetoTransactions(d);
            DataTable dt = controllerObj.SelectClientFromReservation(spotid);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "CName";
            comboBox1.ValueMember = "Client_ID";
            DataTable t = controllerObj.SelectDepTimeFromReservation(spotid);
            comboBox2.DataSource = t;
            comboBox2.DisplayMember = "Reservation_ID";
            comboBox2.ValueMember = "Reservation_ID";

            
        }
        private int gethours(DateTime arr, DateTime dept)
        {
            TimeSpan diff = dept - arr;
            return (int)Math.Ceiling(diff.TotalHours);
        }
        private void MovetoTransactions(DataTable x)
        {
            int c,y;
            DateTime arr, dep;
            DateTime now = DateTime.Now;
            int cid,diff;
            float deposite;
            DataTable dt;
            foreach (DataRow reservation in x.Rows)
            {
                diff = gethours(Convert.ToDateTime(reservation["DepDT"]), now);
                if (diff >= 0)
                {
                    dt = controllerObj.SelectAllReservationbyID(Convert.ToInt16(reservation["Reservation_ID"]));
                    cid= Convert.ToInt16(dt.Rows[0]["Client_ID"]);
                    deposite = (float)dt.Rows[0]["Deposit"];
                    arr = Convert.ToDateTime(dt.Rows[0]["ArrDT"]);
                    dep = arr;
                    c = controllerObj.InsertTransaction(arr, dep,0, "Credit", cid, spotid, deposite);
                    if (c == 1)
                        y = controllerObj.DeleteReservation(Convert.ToInt16(reservation["Reservation_ID"]));    
                  }
              }
          }
        

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Reservations_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable d = controllerObj.SelectReservation(spotid,(int)comboBox1.SelectedValue);
            dataGridView1.DataSource = d;
        }
        private void Reservations_FormClosed(object sender, FormClosedEventArgs e)
        {
            controllerObj.TerminateConnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "")
            {
                MessageBox.Show("Please Enter Plates Number");
                return;
            }
            DataTable d = controllerObj.SelectParking(-1, Convert.ToInt32(textBox2.Text));
            if (d != null)
            {
                MessageBox.Show("Invalid Plates Number");
                return;
            }
            DataTable t = controllerObj.SelectAllReservationbyID((int)comboBox2.SelectedValue);
            DateTime arr = Convert.ToDateTime(t.Rows[0]["ArrDT"]);
            DateTime now = DateTime.Now;
            int diff = gethours(arr,now);
            if(diff <0)
            {
                //add this part later
                arr=now;
            }
            DateTime dep = Convert.ToDateTime(t.Rows[0]["DepDT"]);
            float deposite = (float)t.Rows[0]["Deposit"];
            int cid = Convert.ToInt16(t.Rows[0]["Client_ID"]);
            int f = Convert.ToInt16(t.Rows[0]["Floor"]);
            int l = Convert.ToInt16(t.Rows[0]["Lane"]);
            char s = Convert.ToChar(t.Rows[0]["Section"]);

            int x = controllerObj.InsertParkingCar(arr, dep, Convert.ToInt32(textBox2.Text),f,l,s,cid, spotid,deposite);
            if (x == 1)
            {
                int y = controllerObj.DeleteReservation(Convert.ToInt16(t.Rows[0]["Reservation_ID"]));
                if (y == 1)
                    MessageBox.Show("Moved To Current Parking Cars");
            }
            else
                MessageBox.Show("ERROR! DID NOT Move To Current Parking Cars");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
