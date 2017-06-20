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
    public partial class ReviewReply : Form
    {
        Controller controlObj;
        int sid;
        public ReviewReply(int spotid)
        {
            InitializeComponent();
            controlObj = new Controller();
            dataGridView1.DataSource = controlObj.Reviews(spotid, 5);
            sid=spotid;
            if (dataGridView1.DataSource != null)
            {
                dataGridView1.Columns["Client_ID"].Visible = false;
            }
            dataGridView1.Refresh();

        }

        private void ReviewReply_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Filter_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controlObj.Reviews(sid, Convert.ToInt16(numericUpDown1.Value));
            if (dataGridView1.DataSource != null)
            {
                dataGridView1.Columns["Client_ID"].Visible = false;
            }
            dataGridView1.Refresh();
        
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(1) && e.RowIndex != -1) {
                DateTime rdate = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["_DateTime"].Value);
                int cid = Convert.ToInt16(dataGridView1.CurrentRow.Cells["Client_ID"].Value);
                new Reply(sid, cid, rdate).Show();

            }
        }

        private void ReviewReply_FormClosing(object sender, FormClosingEventArgs e)
        {
            controlObj.TerminateConnection();
        }
    }
}
