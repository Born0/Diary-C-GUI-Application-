using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _18_36449_1.cs.Services;
using _18_36449_1.cs.Entities;

namespace _18_36449_1.cs
{
    public partial class AddEvent : UserControl
    {
        public AddEvent()
        {
            InitializeComponent();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == String.Empty || comboBox1.Text == String.Empty || textBox4.Text == String.Empty)
            {
                MessageBox.Show("Provide all data");
            }
            else
            {
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "DD/MM/YYYY";

                EventEntity evnt = new EventEntity();
                
                evnt.Date = dateTimePicker1.Text.ToString();
                evnt.Title = textBox2.Text;
                evnt.Importance = comboBox1.Text;
                evnt.Description = textBox4.Text;
                evnt.ModDate = null;

                HomeServices hs = new HomeServices();
               bool check= hs.CreatEvent(evnt);
                if (check)
                {
                    MessageBox.Show("Event Created");
                }
                else
                {
                    MessageBox.Show("Change Title");
                }

                this.Hide();
            }


        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            
            
        }
    }

   
}
