using System;
using System.Windows.Forms;

namespace AdvProg_Act2_Point_Of_Sales
{
    public partial class Form1 : Form
    {
        double totalAmountDue = 0;

        public Form1()
        {
            InitializeComponent();

            // SMART AUTO-CONNECT: Hahanapin at ikokonekta nito ang mga buttons 
            // base sa nakasulat sa kanila. No need mag-double click sa Design!
            IkonekLahatNgButtons(this);
        }

        private void IkonekLahatNgButtons(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Button btn)
                {
                    // Sapilitang ikokonekta ang functions kapag nabasa ang text ng button
                    if (btn.Text.ToUpper().Contains("ADD"))
                        btn.Click += AddToCart_Logic;
                    else if (btn.Text.ToUpper().Contains("CLEAR"))
                        btn.Click += ClearCart_Logic;
                    else if (btn.Text.ToUpper().Contains("PRINT"))
                        btn.Click += PrintReceipt_Logic;
                }

                if (c.Controls.Count > 0)
                {
                    IkonekLahatNgButtons(c);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Instruction 2: Disabled textboxes
            txtAmountDue.Enabled = false;
            txtSalesVAT.Enabled = false;
            txtLessVAT.Enabled = false;
            txtChange.Enabled = false;
            IhandaAngResibo();
        }

        // ==========================================
        // LOGIC PARA SA ADD TO CART
        // ==========================================
        private void AddToCart_Logic(object sender, EventArgs e)
        {
            try
            {
                string code = txtProductCode.Text;
                string name = txtProductName.Text;
                double price = Convert.ToDouble(txtProductPrice.Text);
                int qty = Convert.ToInt32(txtQuantity.Text);
                double cost = price * qty;

                string itemLine = string.Format("{0,-15} {1,-25} {2,12:N2} {3,10} {4,15:N2}\r\n", code, name, price, qty, cost);
                textBox3.AppendText(itemLine);

                totalAmountDue += cost;
                double vat = totalAmountDue * 0.12;
                double lessVat = totalAmountDue - vat;

                txtAmountDue.Text = totalAmountDue.ToString("N2");
                txtSalesVAT.Text = vat.ToString("N2");
                txtLessVAT.Text = lessVat.ToString("N2");

                txtProductCode.Clear();
                txtProductName.Clear();
                txtProductPrice.Clear();
                txtQuantity.Clear();
                txtProductCode.Focus();
            }
            catch
            {
                MessageBox.Show("Please enter valid details for the product. Siguraduhing may laman ang Price at Quantity.", "Input Error");
            }
        }

        // ==========================================
        // LOGIC PARA SA CLEAR CART
        // ==========================================
        private void ClearCart_Logic(object sender, EventArgs e)
        {
            IhandaAngResibo();
        }

        // ==========================================
        // LOGIC PARA SA PRINT RECEIPT
        // ==========================================
        private void PrintReceipt_Logic(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCashRendered.Text))
            {
                MessageBox.Show("Please enter payment", "Notification");
                return;
            }

            try
            {
                double cash = Convert.ToDouble(txtCashRendered.Text);

                if (cash < totalAmountDue)
                {
                    MessageBox.Show("Insufficient Payment", "Notification");
                    return;
                }

                double change = cash - totalAmountDue;
                txtChange.Text = change.ToString("N2");
            }
            catch
            {
                MessageBox.Show("Invalid cash amount. Please input numbers only.", "Input Error");
            }
        }

        private void IhandaAngResibo()
        {
            string header = string.Format("{0,-15} {1,-25} {2,12} {3,10} {4,15}\r\n", "Product Code", "Product Name", "Unit Price", "Quantity", "Cost");
            string linya = new string('-', 80) + "\r\n";
            textBox3.Text = header + linya;

            totalAmountDue = 0;
            txtAmountDue.Text = "0.00";
            txtSalesVAT.Text = "0.00";
            txtLessVAT.Text = "0.00";

            txtProductCode.Clear();
            txtProductName.Clear();
            txtProductPrice.Clear();
            txtQuantity.Clear();
            txtCashRendered.Clear();
            txtChange.Clear();
        }

        // =====================================================================
        // MGA PANANGGA SA ERROR:
        // Hayaan lang ito dito sa ibaba para i-bypass ang lahat ng
        // lumang Double-Click errors mo kanina sa Design View.
        // =====================================================================
        private void button1_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }
        private void button3_Click_1(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
    }
}