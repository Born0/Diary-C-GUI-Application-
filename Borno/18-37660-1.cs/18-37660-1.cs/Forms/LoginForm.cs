using _18_36449_1.cs.Entities;
using _18_36449_1.cs.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18_36449_1.cs.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            LoginServices sLog = new LoginServices();
            LoginEntity eLog = new LoginEntity();
            eLog.UserName=textBox1.Text;
            eLog.Password=textBox2.Text;
            bool check;
            check=sLog.LoginCheck(eLog );
            if (check == true)
            {
                HomeForm home = new HomeForm();
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid UserName or Password");
            }
        }

        private void regBtn_Click(object sender, EventArgs e)
        {
            LoginServices sLog = new LoginServices();
            LoginEntity eLog = new LoginEntity();
            eLog.UserName = textBox1.Text;
            eLog.Password = textBox2.Text;
            bool check;

            check = sLog.NewSignUp(eLog);
            if (check == true)
            {
                MessageBox.Show("SignUp Success");
            }
            else
            {
                MessageBox.Show("Invalid UserName or Password");
            }
        }

       
    }
}
