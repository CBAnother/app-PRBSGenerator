using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRBSGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            foreach(var order in PRBSGen.GetOrderLst())
            {
                cbxOrderLst.Items.Add(order);
            }
            cbxOrderLst.SelectedIndex = 0;
            cbxOrderLst.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            rtbxResult.Text = PRBSGen.GetPRBS(int.Parse(cbxOrderLst.Items[cbxOrderLst.SelectedIndex].ToString()));
        }
    }
}
