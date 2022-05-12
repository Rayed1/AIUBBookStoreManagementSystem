using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DGVPrinterHelper;

namespace AIUBBookStoreManagementSystem
{
    public partial class Order : Form
    {
        DataAccess da = new DataAccess();
        DataSet ds;
        public Order()
        {
            InitializeComponent();
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtSearchBook.Clear();
            this.txtSearchPrice.Clear();    
            this.txtSearch.Clear();
            this.txtTotal.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Library bck = new Library("Student");
            Library bck1 = new Library("NewUser");
            bck.Show();
        }

        private void cmbSearchGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "select Name from Book where Genre = '" + this.cmbSearchGenre.Text + "' ";
            ShowList(query);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query = "select name from book where genre = '" + this.cmbSearchGenre.Text + "' and name like '" + this.txtSearch.Text + "%' ";
            ShowList(query);
        }
        private void ShowList(string query)
        {
            listBox1.Items.Clear();
            ds = da.getData(query);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nmrcQuantity.ResetText();
            txtTotal.Clear();

            string text = listBox1.GetItemText(listBox1.SelectedItem);
            txtSearchBook.Text = text;
            string query = "select Price from Book where Name = '" + this.txtSearchBook.Text + "'";
            ds = da.getData(query);
            
            txtSearchPrice.Text = ds.Tables[0].Rows[0][0].ToString();
        }

        private void nmrcQuantity_ValueChanged(object sender, EventArgs e)
        {
            int q = (int)Convert.ToInt64(nmrcQuantity.Value.ToString());
            int price = (int)Convert.ToInt64(txtSearchPrice.Text); 
            txtTotal.Text = (q * price).ToString();
        }
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (txtTotal.Text != "0" && txtTotal.Text != "")
            {
                n = dgvCart.Rows.Add();
                dgvCart.Rows[n].Cells[0].Value = txtSearchBook.Text;
                dgvCart.Rows[n].Cells[1].Value = txtSearchPrice.Text;
                dgvCart.Rows[n].Cells[2].Value = nmrcQuantity.Value.ToString();
                dgvCart.Rows[n].Cells[3].Value = txtTotal.Text;

                total += int.Parse(txtTotal.Text);
                lblTotal.Text = "Tk. " + total;
            }
            else
            {
                MessageBox.Show("Insufficient Quantity Selected");
            }
        }
        protected int n, total = 0;

        private int amount;
        public int Amount
        {
            get { return this.amount; }
            set { this.amount = value; }
        }
        private void dgvCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            amount = int.Parse(dgvCart.Rows[e.RowIndex].Cells[3].Value.ToString());

        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                dgvCart.Rows.RemoveAt(this.dgvCart.SelectedRows[0].Index);
            }
            catch { }

            total -= amount;
            lblTotal.Text = "Tk. " + total;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Student Bill";
            printer.SubTitle = String.Format("Date: {0}", DateTime.Now.ToLocalTime());
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Total Payable Amount : " + lblTotal.Text;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dgvCart);

            total = 0;
            dgvCart.Rows.Clear();
            lblTotal.Text = "Tk. " + total;
        }

    }
}
