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
    public partial class Cancel_Make_Reservation : Form
    {
        
        private Controller controllerObj;
        private int? res_ID;
        public int? resID { get { return res_ID; } }
        
        public Cancel_Make_Reservation(string username)
        {
            InitializeComponent();
            res_ID = resID;
            controllerObj = new Controller();
            controllerObj.user_name = username;
        }
        public Cancel_Make_Reservation()
        {
            
            InitializeComponent();
            
        }
        //for displaying the reservation of the client
        private void Cancel_Make_Reservation_Load(object sender, EventArgs e)
        {
            
            YourReservations.DataSource = controllerObj.SelectReservationDESC2(controllerObj.getClientID());
            YourReservations.DisplayMember = "Description";
            YourReservations.ValueMember = "reservation_ID";
            YourReservations.Refresh();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Make_Reservation v = new Make_Reservation(controllerObj.user_name);
            v.Show(this);
        }
        private int getHourstoRefund(DateTime now,DateTime arr)
        {
            
            TimeSpan diff = arr-now;
            return (int)Math.Ceiling(diff.TotalHours); //rounding up hours
           
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime cancel = DateTime.Now;
            if (YourReservations.SelectedValue != null && getHourstoRefund(cancel,controllerObj.getArrDT((int)YourReservations.SelectedValue)) > 24)
            {
              
                    cancel_reason v = new cancel_reason((int)YourReservations.SelectedValue);
                    v.Show(this);
            
            }
            else if (YourReservations.SelectedValue != null && getHourstoRefund(cancel, controllerObj.getArrDT((int)YourReservations.SelectedValue)) <= 24)
            {
                int result = controllerObj.CancelReservation((int)YourReservations.SelectedValue);
                if (result > 0)
                {
                    MessageBox.Show("Reservation Cancelled without refund");
                    this.Close();
                }
                else
                    MessageBox.Show("Cancelation Failed");
            }
        }

        private void update_Reser(object sender, EventArgs e) //double click event
        {
            int Res_ID = (int)YourReservations.SelectedValue;
            Change_Reservation v = new Change_Reservation(Res_ID);
            v.Show(this);
        }

        private void YourReservations_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void Cancel_Make_Reservation_FormClosed(object sender, FormClosedEventArgs e)
        {
            controllerObj.TerminateConnection();
        }
    }
}
