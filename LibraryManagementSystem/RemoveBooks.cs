using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIUBBookStoreManagementSystem
{
    public partial class RemoveBooks : Form
    {
        DataAccess da = new DataAccess();
        DataSet ds;

        public RemoveBooks()
        {
            InitializeComponent();
        }

        private void RemoveBooks_Load(object sender, EventArgs e)
        {
            loadData(); 
        }
        public void loadData()
        {
            string query = "select * from book";
            ds = da.getData(query);
            dgvDelete.DataSource = ds.Tables[0];
        }

        private void txtSearchRemove_TextChanged(object sender, EventArgs e)
        {
            string query = "select * from Book where name like '" + this.txtSearchRemove.Text + "%'";
            ds = da.getData(query);
            dgvDelete.DataSource = ds.Tables[0];
        }
        string id;
        private void dgvDelete_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Delete Item?", "Warning!", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string temp = (string)dgvDelete.Rows[e.RowIndex].Cells[0].Value;
                string id_s = "";
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i] >= '0' && temp[i] <= '9')
                    {
                        id_s += temp[i];
                    }
                }

                id = (string)dgvDelete.Rows[e.RowIndex].Cells[0].Value;
                string query = "delete from book where id = '" + id + "'";
                da.setData(query);
                loadData();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Library bck = new Library("Employee");
            bck.Show();
        }
    }
}
