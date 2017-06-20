using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parking_Finder
{
    public partial class Account_Info : Form
    {
        Controller controllerObj;
        public Account_Info()
        {
            InitializeComponent();
            controllerObj = new Controller();
            
        }

        private void button1_Click(object sender, EventArgs e)//Save Click
        {
            if (textBox1.Text == "" || textBox4.Text == "" || textBox5.Text == "")//validation part
            {
                MessageBox.Show("Please, insert  values");
            }
            else if (textBox2.Text != "" && textBox2.TextLength < 13) {
                MessageBox.Show("Invalid Credit Card Number");
            }

            else
            {


                int r = controllerObj.Insert_Account(textBox4.Text, textBox5.Text, "Client");
                if (r > 0)
                {
                    ///should check first that account insertion occured
                    // Then create client account
                    if (textBox3.Text == "")
                    {
                        int p;
                        p = controllerObj.Insert_Client(textBox1.Text, textBox4.Text, 0);
                    }
                    else
                    {
                        int q;
                        q = controllerObj.Insert_Client(textBox1.Text, textBox4.Text, Convert.ToInt32(textBox3.Text));
                    }

                    /*if (textBox2.Text != "") {

                    }*/


                    MessageBox.Show(" Account created successfully");
                }
                else
                    MessageBox.Show("Account Creation Failed! Please insert another user name");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Account_Info_Load(object sender, EventArgs e)
        {

        }

        private void Account_Info_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
            controllerObj.TerminateConnection();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
