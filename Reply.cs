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
    public partial class Reply : Form
    {
        int sptid, cid;
        DateTime RevDate;
        Controller controlObj;
        public Reply(int sid,int clid,DateTime rdate)
        {
            InitializeComponent();
            controlObj = new Controller();
            sptid = sid;
            cid = clid;
            RevDate = rdate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controlObj.UpdateReply(sptid, cid, RevDate, richTextBox1.Text);
            this.Close();
        }

        private void Reply_FormClosing(object sender, FormClosingEventArgs e)
        {
            controlObj.TerminateConnection();
 
        }
    }
}
