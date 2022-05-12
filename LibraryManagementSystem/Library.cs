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
    public partial class Library : Form
    {

        private Login lg { get; set; }
        public Library()
        {
            InitializeComponent();
        }

        public Library(string v)
        {
            InitializeComponent();
            if (v == "NewUser")
            {
                btnAddNewBooks.Hide();
                btnUpdateBooks.Hide();
                btnRemoveBooks.Hide();
            }
            else if (v == "Employee")
            {
                btnOrderBooks.Hide();
                btnAddNewBooks.Show();
                btnUpdateBooks.Show();
                btnRemoveBooks.Show();
            }
            else if (v == "Student")
            {
                btnAddNewBooks.Hide();
                btnUpdateBooks.Hide();
                btnRemoveBooks.Hide();
            }

        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();  
            this.Hide();
        }

        private void btnAddNewBooks_Click(object sender, EventArgs e)
        {
            AddNewBooks ad = new AddNewBooks(); 
            ad.Show();
            this.Hide();
        }

        private void btnOrderBooks_Click(object sender, EventArgs e)
        {
            Order order = new Order();  
            order.Show();
            this.Hide();
        }

        private void btnUpdateBooks_Click(object sender, EventArgs e)
        {
            UpdateBooks updates = new UpdateBooks();
            updates.Show();
            this.Hide();
        }

        private void btnRemoveBooks_Click(object sender, EventArgs e)
        {
            RemoveBooks removeBooks = new RemoveBooks();
            removeBooks.Show();
            this.Hide();
        }
    }
}
