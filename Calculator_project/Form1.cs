using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_project
{
    public partial class Form1 : Form
    {
        Double result = 0;
        String operation = "";
        bool enter_value = false;
        bool memory_value = false;
        String firstnum, secondnum;
        Double memory;
        public Form1()
        {
            InitializeComponent();

            btnMC.Enabled = false;
            btnMR.Enabled = false;
        }

        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {

        }

        private void numbers_Only(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if ((txtDisplay.Text == "0") || (enter_value) || (memory_value))
                txtDisplay.Text = "";
            enter_value = false;
            memory_value = false;

            if (b.Text == ".")
            {
                if (!txtDisplay.Text.Contains("."))
                    txtDisplay.Text = txtDisplay.Text + b.Text;
            }
            else
            {
                txtDisplay.Text = txtDisplay.Text + b.Text;
            }
        }

        //arithmetic_operators
        private void operators_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (result != 0)
            {
                btnEquals.PerformClick();
                enter_value = true;
                operation = b.Text;
                lblShowOps.Text = result + " " + operation;
            }
            else
            {
                operation = b.Text;
                result = Double.Parse(txtDisplay.Text);
                enter_value = true;
                lblShowOps.Text = result + " " + operation;
            }
            firstnum = lblShowOps.Text;
            
          
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            result = 0;
            lblShowOps.Text = " ";
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            secondnum = txtDisplay.Text;
            lblShowOps.Text = "";
            switch(operation)
            {
                case "+":
                    txtDisplay.Text = (result + Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (result - Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (result * Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "/":
                    txtDisplay.Text = (result / Double.Parse(txtDisplay.Text)).ToString();
                    break;
                default:
                    break;
            }
            result = Double.Parse(txtDisplay.Text);
            operation = "";

            //===============================================

            btnClearHistory.Visible = true;
            rtbDisplayHistory.AppendText(firstnum + " " + secondnum + " = " + "\n");
            rtbDisplayHistory.AppendText("\n\t" + txtDisplay.Text + "\n\n");
            lblHistoryDisplay.Text = "";
        }

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            rtbDisplayHistory.Clear();
            if (lblHistoryDisplay.Text =="")
            {
                lblHistoryDisplay.Text = "There's no history yet";
            }
            btnClearHistory.Visible = false;
            rtbDisplayHistory.ScrollBars = 0;
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            double sq = Double.Parse(txtDisplay.Text);
            lblShowOps.Text = System.Convert.ToString("sqrt" + "(" + (txtDisplay.Text) + ")");
            sq = Math.Sqrt(sq);
            txtDisplay.Text = System.Convert.ToString(sq);
        }

        private void btnXtopower2_Click(object sender, EventArgs e)
        {
            Double a;
            lblShowOps.Text = System.Convert.ToString("sqr" + "(" + (txtDisplay.Text) + ")");
            a = Convert.ToDouble(txtDisplay.Text) * Convert.ToDouble(txtDisplay.Text);
            txtDisplay.Text = System.Convert.ToString(a);
        }

        private void btnpercent_Click(object sender, EventArgs e)
        {
            Double a;
            a = Convert.ToDouble(txtDisplay.Text) / Convert.ToDouble(100);
            lblShowOps.Text = System.Convert.ToString(a);
            txtDisplay.Text = System.Convert.ToString(a);
        }

        private void btn1peX_Click(object sender, EventArgs e)
        {
            Double a;
            lblShowOps.Text = System.Convert.ToString("1" + "/" + "(" + (txtDisplay.Text) + ")");
            a = Convert.ToDouble(1.0 / Convert.ToDouble(txtDisplay.Text));
            txtDisplay.Text = System.Convert.ToString(a);
        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (txtDisplay.Text.Contains("-"))
            {
                txtDisplay.Text = txtDisplay.Text.Remove(0, 1);
            }
            else
            {
                txtDisplay.Text = "-" + txtDisplay.Text;
            }
        }

        private void btnMS_Click(object sender, EventArgs e)
        {
            memory = Double.Parse(txtDisplay.Text);
            btnMC.Enabled = true;
            btnMR.Enabled = true;
            memory_value = true;
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = memory.ToString();
            memory_value = true;
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            memory = 0;
            btnMR.Enabled = false;
            btnMC.Enabled = false;
        }

        private void btnMPlus_Click(object sender, EventArgs e)
        {
            memory += Double.Parse(txtDisplay.Text);
            btnMC.Enabled = true;
            btnMR.Enabled = true;
        }

        private void btnMMinus_Click(object sender, EventArgs e)
        {
            memory -= Double.Parse(txtDisplay.Text);
            btnMC.Enabled = true;
            btnMR.Enabled = true;
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }

            if (txtDisplay.Text == "")
            {
                txtDisplay.Text = "0";
            }
        }
    }
}
