using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double s1 = 0, s2 = 0;
        bool isFirst = false,isEqlast=false;
        char opr = ' ';
        char[] oprs = new char[] { '+', '-', '*', '/', '=' };

        private void btnOperators_Click(object sender, EventArgs e)
        {
            Button selected = (Button)sender;
            if (opr != ' ') Calculate(selected.Text);
            SelectOperator(selected.Text);
        }

        private void SelectOperator(string text)
        {
            isEqlast = false;
            if (opr == ' ') s1 = Convert.ToDouble(txtInput.Text);

            switch (text)
            {
                case "+": opr = '+'; break;
                case "-": opr = '-'; break;
                case "x":
                case "*": opr = '*'; break;
                case "/": opr = '/'; break;
                case "÷": opr = '÷'; break;
                default: isEqlast = true; break;
            }
            isFirst = true;
        }

        private void Calculate(string text)
        {
            if (!isEqlast) s2 = Convert.ToDouble(txtInput.Text);

            if (!isFirst || text == "=")
            {
                switch (opr)
                {
                    case '+': s1 += s2; break;
                    case '-': s1 -= s2; break;
                    case '*': s1 *= s2; break;
                    case '/': s1 /= s2; break;
                }
            }
            txtInput.Text = s1.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DeleteToDisplay();
        }

        private void DeleteToDisplay()
        {
            if (txtInput.Text.Length > 1)
            {
                txtInput.Text = txtInput.Text.Substring(0, txtInput.Text.Length - 1);
            }
            else
            {
                txtInput.Text = "0";
            }
        }

        private void btnCe_Click(object sender, EventArgs e)
        {
            txtInput.Text = "0";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtInput.Text = "0";
            s1 = s2 = 0;
            opr = ' ';
            isEqlast = isFirst = false;
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            if (txtInput.Text == ",")
            {
                txtInput.Text = "0,";
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtInput.Text == "0")
            {
                txtInput.Text = "";
            }
            if (isFirst && opr != ' ')
            {
                txtInput.Text = "0";
            }

            if (!char.IsNumber(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (int) Keys.Back && !oprs.Contains(e.KeyChar) || (e.KeyChar == ',' && txtInput.Text.Contains(',')))
            {
                e.Handled = true;
            }
            else if (oprs.Contains(e.KeyChar))
            {
                SelectOperator(e.KeyChar.ToString());
            }
            else if (e.KeyChar==(int) Keys.Back)
            {
                DeleteToDisplay();
            }
            else
            {
                WriteToDisplay(e.KeyChar.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnNumPad_Click(object sender, EventArgs e)
        {
            Button selected = (Button)sender;
            WriteToDisplay(selected.Text);
        }

        private void WriteToDisplay(string text)
        {
            if (text == "," && txtInput.Text.Contains(","))
            {
                return;
            }

            if (txtInput.Text == "0"&&text!= ",")
            {
                txtInput.Text = "";
            }
            if (isFirst && opr != ' ')
            {
                txtInput.Text = "";
            }
            txtInput.Text += text;
            isFirst = false;
        }
        
    }
}
