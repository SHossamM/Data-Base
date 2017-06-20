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
    public partial class AddParkingCar : Form
    {
        int spotid;
        Controller controllerObj;
        public AddParkingCar(int sid)
        {
            InitializeComponent();
            controllerObj = new Controller();
            spotid = sid;
            UpdatefloorsComboBox();

           /* comboBox4.DisplayMember = "Floor";
            comboBox4.ValueMember = "Floor";
            comboBox4.DataSource = controllerObj.Selectfreefloors(controllerObj.Selectfreeplaces(), spotid);
            comboBox4.Update();

            comboBox3.DisplayMember = "Section";
            comboBox3.ValueMember = "Section";
            comboBox3.DataSource = controllerObj.Selectfreesections(controllerObj.Selectfreeplaces(), spotid, (int)comboBox4.SelectedValue);
            comboBox3.Update();

            comboBox2.DisplayMember = "Lane";
            comboBox2.ValueMember = "Lane";
            comboBox2.DataSource = controllerObj.Selectfreelanes(controllerObj.Selectfreeplaces(), spotid, (int)comboBox4.SelectedValue, comboBox4.SelectedValue.ToString());
            comboBox2.Update();*/

        }
        private void UpdatefloorsComboBox()
        {
            comboBox4.DisplayMember = "Floor";
            comboBox4.ValueMember = "Floor";
            comboBox4.DataSource = controllerObj.Selectfreefloors(controllerObj.Selectfreeplaces(), spotid);
            comboBox4.Update();
        }
        private void UpdatesectionsComboBox()
        {
            comboBox3.DisplayMember = "Section";
            comboBox3.ValueMember = "Section";
            comboBox3.DataSource = controllerObj.Selectfreesections(controllerObj.Selectfreeplaces(), spotid, (int)comboBox4.SelectedValue);
            comboBox3.Update();
        }
        private void UpdatelanesComboBox()
        {
            comboBox2.DisplayMember = "Lane";
            comboBox2.ValueMember = "Lane";
            comboBox2.DataSource = controllerObj.Selectfreelanes(controllerObj.Selectfreeplaces(), spotid, (int)comboBox4.SelectedValue, comboBox4.SelectedValue.ToString());
            comboBox2.Update();
        }
        
       
        private void AddParkingCar_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int x = controllerObj.Occupied(spotid);
            //int lane = controllerObj.
           /* if(x==0)
             {
                new MaxCapMes().Show();
                return;
             }
            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox3.Text == "" )
            {
                new ErrorMessage().Show();
                return;
            }
            if (Convert.ToInt16(textBox1.Text) <= 0 || Convert.ToInt16(textBox2.Text) <= 0 || Convert.ToInt16(textBox3.Text) <= 0)
            {
                new ErrorMessage().Show();
                return;
            }*/
                         
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatelanesComboBox();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatesectionsComboBox();
        }
        private void AddParkingCar_FormClosed(object sender, FormClosedEventArgs e)
        {
            controllerObj.TerminateConnection();
        }
    }
}
