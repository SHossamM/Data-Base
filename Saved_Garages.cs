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
    public partial class Saved_Garages : Form
    {
        private Controller controllerObj;
        public Saved_Garages(string un)
        {
            InitializeComponent();
            controllerObj = new Controller();
            controllerObj.user_name = un;
            if (controllerObj.getSavedGarages(controllerObj.getClientID()) != null)
            {//put controllerObj.getClientID(); instead of 7
                UpdatesavedgarageComboBox();
            }
            else
            {
                MessageBox.Show("You Have No Saved Garages");
                this.Close();
            }
        }

        private void Saved_Garages_Load(object sender, EventArgs e)
        {
            
        }
        private void UpdatesavedgarageComboBox()
        {
           YourGarages.DisplayMember = "SName";
           YourGarages.ValueMember = "Spot_ID";
           YourGarages.DataSource = controllerObj.getSavedGarages(controllerObj.getClientID());
           YourGarages.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Saved_Garages_FormClosed(object sender, FormClosedEventArgs e)
        {
            controllerObj.TerminateConnection();
        }

        private void YourGarages_DoubleClick(object sender, EventArgs e)
        {
            int garage_id = (int)YourGarages.SelectedValue;
            View_Garage G = new View_Garage(garage_id, controllerObj.user_name);
            G.Show();
        }

        private void YourGarages_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
