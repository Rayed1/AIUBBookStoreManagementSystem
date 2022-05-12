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

namespace AIUBBookStoreManagementSystem
{
    public partial class UpdateBooks : Form
    {
        DataAccess da = new DataAccess();
        DataSet ds;
        public UpdateBooks()
        {
            InitializeComponent();
        }
        private void UpdateBooks_Load(object sender, EventArgs e)
        {
            loadData();
        }
        public void loadData()
        {
            string query = "select * from book";
            ds = da.getData(query);
            dgvNewCart.DataSource = ds.Tables[0];
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtSearchBookName_TextChanged(object sender, EventArgs e)
        {
            string query = "select * from Book where name like '" + this.txtSearchBookName.Text + "%'";
            ds = da.getData(query);
            dgvNewCart.DataSource = ds.Tables[0];
        }
        private string id;
        public string Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        private void dgvNewCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string temp = (string)dgvNewCart.Rows[e.RowIndex].Cells[0].Value;
            string id_s = "";
            for(int i = 0; i<temp.Length; i++)
            {
                if(temp[i] >= '0' && temp[i] <= '9')
                {
                    id_s += temp[i];
                }
            }

            id = (string)dgvNewCart.Rows[e.RowIndex].Cells[0].Value;
            String name = dgvNewCart.Rows[e.RowIndex].Cells[1].Value.ToString();
            String genre = dgvNewCart.Rows[e.RowIndex].Cells[2].Value.ToString();
            int price = int.Parse(dgvNewCart.Rows[e.RowIndex].Cells[3].Value.ToString());

            txtBookName.Text = name;
            txtGenre.Text = genre;
            txtPrice.Text = price.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = "update book set name= '" + this.txtBookName.Text + "', genre= '" + this.txtGenre.Text + "', price= " + this.txtPrice.Text + " where id ='" + this.id + "'";
            da.setData(query);
            loadData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Library bck = new Library("Employee");
            bck.Show();
        }
    }
}
