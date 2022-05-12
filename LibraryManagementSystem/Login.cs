namespace AIUBBookStoreManagementSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.txtUsername.Text =="Employee" && this.txtPassword.Text == "employee123")
            {
                MessageBox.Show("Login Confirm");
                Library lb = new Library("Employee");
                lb.Show();
                this.Hide();
            }
            else if (this.txtUsername.Text == "Student" && this.txtPassword.Text == "student123")
            {
                MessageBox.Show("Login Confirm");
                Library lb = new Library("Student");
                lb.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Login Information");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtUsername.Clear();   
            this.txtPassword.Clear();   
        }

        private void btnExitLogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();    
            }
        }

        private void lblGuest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Library lb = new Library("NewUser");
            lb.Show();
            this.Hide();
        }

    }
}