using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Combiner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] strs = txtRaw.Text.Split(new char[] { '\n' });
            int itemPerRow = 0;
            try
            {
                itemPerRow = int.Parse(txtItemPerRow.Text);
            }
            catch
            {
            }
            if (itemPerRow == 0) { itemPerRow = 10; txtItemPerRow.Text = "10"; }
            if (string.IsNullOrEmpty(txtSeparator.Text)) txtSeparator.Text = ",";
            int index = 0;
            StringBuilder sb = new StringBuilder();

            foreach (string str in strs)
            {
                if (index != 0 && (index % itemPerRow) == 0)
                {
                    sb.Append("\n");
                }
                sb.Append(str.Trim() + txtSeparator.Text + "\t");
                index++;
            }
            string output = sb.ToString().Trim();
            if (output.EndsWith(txtSeparator.Text)) output = output.Substring(0, output.Length - txtSeparator.Text.Length);
            txtOutput.Text = output;
        }
    }
}
