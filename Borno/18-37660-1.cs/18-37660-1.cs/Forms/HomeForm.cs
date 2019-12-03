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
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
            

        }

        HomeServices hs = new HomeServices();

        private void addBtn_Click(object sender, EventArgs e)
        {
            editBtn.Hide();
            deleteBtn.Hide();
            textBox2.Hide();
            textBox3.Hide();
            comboBox1.Show();
            dateTimePicker1.Show();
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
            cancelBtn.Show();
            confirmBtn.Show(); 
        }


        private void logOutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            EventEntity temp = new EventEntity();
            temp.Title = textBox1.Text;
            bool check = hs.Delete(temp);
            if(check)
            {
                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                textBox4.Text = String.Empty;
                textBox5.Text = String.Empty;

                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not");
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            EventEntity temp = new EventEntity();
            temp.Title = textBox1.Text.ToString();
           
            EventEntity  evnt = new EventEntity();
            evnt = hs.SearchTitle(temp);
            if (evnt != null)
            {
                textBox2.Text = evnt.Date;
                textBox3.Text = evnt.Importance;
                textBox5.Text = evnt.Title;
                textBox4.Text = evnt.Description;

                editBtn.Show();
                deleteBtn.Show();
            }
            else
                MessageBox.Show("No Data Found");
            
            
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == String.Empty || comboBox1.Text == String.Empty || textBox5.Text == String.Empty)
            {
                MessageBox.Show("Provide all data");
            }
            else
            {
                //dateTimePicker1.Format = DateTimePickerFormat.Custom;
                //dateTimePicker1.CustomFormat = "DD/MM/YYYY";

                EventEntity evnt = new EventEntity();
                
                evnt.Date = dateTimePicker1.Text.ToString();
                evnt.Title = textBox5.Text;
                evnt.Importance = comboBox1.Text;
                evnt.Description = textBox4.Text;
                evnt.ModDate = null;

                HomeServices hs = new HomeServices();
               bool check= hs.CreatEvent(evnt);
                if (check)
                {
                    textBox2.Text = String.Empty;
                    textBox3.Text = String.Empty;
                    textBox4.Text = String.Empty;
                    textBox5.Text = String.Empty;
                    cancelBtn.Hide();
                    confirmBtn.Hide();
                    MessageBox.Show("Event Created");

                    textBox2.Show();
                    textBox3.Show();
                    textBox5.Text = String.Empty;
                    
                    
                    comboBox1.Hide();
                    dateTimePicker1.Hide();
                }
                else
                {
                    MessageBox.Show("Change Title");
                }

               
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            EventEntity evnt = new EventEntity();
            evnt.Title = textBox5.Text;
            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;
            evnt.Date = date.ToString();
            evnt.Description = textBox4.Text;
            bool check = hs.Edit(evnt);
            if (check)
            {
                MessageBox.Show("Event Edited");
            }
            else
                MessageBox.Show("Not edited");
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = hs.GetAllEvents();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
