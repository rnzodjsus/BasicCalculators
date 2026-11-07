using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculatorPrivateAssembly;

namespace BasicCalculators
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void FrmBasicCalculator_Load(object sender, EventArgs e)
        {
           cmbOperation.Items.Add("+");
            cmbOperation.Items.Add("-");
            cmbOperation.Items.Add("*");
            cmbOperation.Items.Add("/");

            cmbOperation.SelectedIndex = 0;
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            try
            {
                float num1, num2;

                if (!float.TryParse(txtNum1.Text, out num1))
                {
                    MessageBox.Show("Enter a valid first number.");
                    txtNum1.Focus();
                    return;
                }

                if (!float.TryParse(txtNum2.Text, out num2))
                {
                    MessageBox.Show("Enter a valid second number.");
                    txtNum2.Focus();
                    return;
                }

                float result = 0;

                switch (cmbOperation.SelectedItem.ToString())
                {
                    case "+":
                        result = BasicComputation.Addition(num1, num2);
                        break;

                    case "-":
                        result = BasicComputation.Subtraction(num1, num2);
                        break;

                    case "*":
                        result = BasicComputation.Multiplication(num1, num2);
                        break;

                    case "/":
                        result = BasicComputation.Division(num1, num2);
                        break;

                    default:
                        MessageBox.Show("Select an operation.");
                        return;
                }

                lblTotal.Text = result.ToString("0.##");
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}