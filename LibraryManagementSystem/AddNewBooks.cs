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
    public partial class AddNewBooks : Form
    {
        public AddNewBooks() => InitializeComponent();

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-L464G1Q;Initial Catalog=librarydb;Persist Security Info=True;User ID=sa;Password=eshmamrayed123");
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand("insert into Book(Id,Name,Genre,Price) Values(@id,@name,@genre,@price);", sqlcon);
            SqlDataAdapter sda = new SqlDataAdapter(sqlcom);    
            DataSet ds = new DataSet();

            string conString = "Data Source=DESKTOP-L464G1Q;Initial Catalog=librarydb;Persist Security Info=True;User ID=sa;Password=eshmamrayed123";
            SqlConnection con = new SqlConnection(conString);

            string selectSql = "select Id from Book";
            SqlCommand com = new SqlCommand(selectSql, con);


            string Bookid = "";
            try
            {
                con.Open();

                using (SqlDataReader read = com.ExecuteReader())
                {
                    while (read.Read())
                    {
                        Bookid = (read["id"].ToString());
 
                    }
                }
            }
            finally
            {
                con.Close();
            }

            string bookinsertid = "";
            int mul = 1,number = 0;
            for(int i=(Bookid.Length -1); i >= 0; i--)
            {
                if(Bookid[i] != '-')
                {
                    int temp = Bookid[i] - '0';
                    number += temp * mul;
                    mul *= 10;
                }
                else
                {
                    break;
                }
            }

            number++;
            bookinsertid = "B-0" + number.ToString();

            sqlcom.Parameters.AddWithValue("id", bookinsertid);
            sqlcom.Parameters.AddWithValue("name", txtBookName.Text);
            sqlcom.Parameters.AddWithValue("genre", cmbGenres.Text);
            sqlcom.Parameters.AddWithValue("price", txtPrice.Text);
            sqlcom.ExecuteNonQuery();

            MessageBox.Show("Data Processed Successfully");

            ClearAll();
            sqlcon.Close();


        } 
        public void ClearAll()
        {
            cmbGenres.SelectedIndex = -1;
            txtBookName.Clear();
            txtPrice.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Library bck = new Library("Employee");
            bck.Show();

        }
        
    }
}
