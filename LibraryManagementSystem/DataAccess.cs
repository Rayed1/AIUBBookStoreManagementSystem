using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AIUBBookStoreManagementSystem
{
    internal class DataAccess
    {
        private SqlConnection sqlcon;
        public SqlConnection Sqlcon
        {
            get { return this.sqlcon; }
            set { this.sqlcon = value; }
        }

        private SqlCommand sqlcom;
        public SqlCommand Sqlcom
        {
            get { return this.sqlcom; }
            set { this.sqlcom = value; }
        }

        private SqlDataAdapter sda;
        public SqlDataAdapter Sda
        {
            get { return this.sda; }
            set { this.sda = value; }
        }

        private DataSet ds;
        public DataSet Ds
        {
            get { return this.ds; }
            set { this.ds = value; }
        }
        protected SqlConnection GetConnection()
        {
            SqlConnection sqlcon = new SqlConnection();
            sqlcon.ConnectionString = "Data Source=DESKTOP-L464G1Q;Initial Catalog=librarydb;Persist Security Info=True;User ID=sa;Password=eshmamrayed123";
            return sqlcon;
        }
        public DataSet getData(string query)
        {
            SqlConnection sqlcon = GetConnection();
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.Connection = sqlcon;
            sqlcom.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }
        public void setData(string query)
        {
            SqlConnection sqlcon = GetConnection();
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.Connection = sqlcon;
            sqlcon.Open();
            sqlcom.CommandText = query;
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();

            MessageBox.Show("Data Processed Successfully.");
        }
    }
}
