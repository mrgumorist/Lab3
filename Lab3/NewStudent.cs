using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class NewStudent : Form
    {
       
        public NewStudent()
        {
           
            InitializeComponent();
        }

        private void NewStudent_Load(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
        private bool IsDouble(string text)
        {
            Double num = 0;
            bool isDouble = false;

            // Check for empty string.
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            isDouble = Double.TryParse(text, out num);

            return isDouble;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            string pattern = @"^\p{Lu}[a-z]{1,9}$";
            if (Regex.IsMatch(textBox1.Text, pattern))
            {
                if (Regex.IsMatch(textBox2.Text, pattern))
                {
                    if(IsDouble(textBox3.Text))
                    {
                        if(maskedTextBox1.Text!=null)
                        {
                            if (maskedTextBox1.Text != null)
                            {
                                var student = new Student();
                                student.Name = textBox1.Text;
                                student.Surname = textBox1.Text;
                                student.AvarageMark = double.Parse(textBox3.Text);
                                student.IsOnFreeStudy = checkBox1.Checked;
                                student.ID = Helper.GetID();
                                student.CountOfMissedLections = uint.Parse( maskedTextBox1.Text);
                                student.CourseNumber = int.Parse(maskedTextBox2.Text);
                                student.BirthDay = dateTimePicker1.Value;
                                Helper.students.Add(student);
                                MessageBox.Show("Succesfull added");
                                Close();
                            }
                            else
                            {
                                errorProvider1.SetError(maskedTextBox2, "The value can not be empty");
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(maskedTextBox1, "The value can not be empty, you will input 0 if you want");
                     }
                    }
                    else
                    {
                        errorProvider1.SetError(textBox3, "The value is not double");
                        
                    }
                }
                else
                {
                    errorProvider1.SetError(textBox2, "Surname must be like Mishkov");
                }
            }
            else
            {
                errorProvider1.SetError(textBox1, "Name must be like Andrew");
            }
        }
    }
}
