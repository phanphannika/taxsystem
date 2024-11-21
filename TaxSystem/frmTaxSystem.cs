using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaxSystem
{
    public partial class frmTaxSystem : Form
    {
        public frmTaxSystem()
        {
            InitializeComponent();
        }
        private double CalculateTax(double income)
        {
            double tax = 0;

            if (income <= 1500000)
            {
                tax = 0;
            }
            else if (income <= 2000000)
            {
                tax = (income - 1500000) * 0.05;
            }
            else if (income <= 8500000)
            {
                tax = (500000 * 0.05) + ((income - 2000000) * 0.10);
            }
            else if (income <= 12500000)
            {
                tax = (500000 * 0.05) + (6500000 * 0.10) + ((income - 8500000) * 0.15);
            }
            else
            {
                tax = (500000 * 0.05) + (6500000 * 0.10) + (4000000 * 0.15) + ((income - 12500000) * 0.20);
            }

            return tax;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double grossSalary;
            if (double.TryParse(txtGrossSalary.Text, out grossSalary))
            {
                double tax = CalculateTax(grossSalary);
                double netSalary = grossSalary - tax;

                txtTax.Text = tax.ToString("F2");
                txtNetSalary.Text = netSalary.ToString("F2");
            }
            else
            {
                MessageBox.Show("Please enter a valid gross salary.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtGrossSalary.Clear();
            txtTax.Clear();
            txtNetSalary.Clear();
        }
    }
}
