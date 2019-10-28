using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        private int Row = -1;
       
      public Form1()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = $"Simple status strip. Session started on {DateTime.Now}";
        }
   
        private void Form1_Load(object sender, EventArgs e)
        {
            Helper.Deserialize();
            dataGridView1.DataSource = Helper.students;

        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menuStrip = new ContextMenuStrip();
                int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    menuStrip.Items.Add("Change").Name = "Change";
                    menuStrip.Items.Add("Delete").Name = "Delete";
                    menuStrip.Items.Add("Copy").Name = "Copy";
                    menuStrip.Show(dataGridView1, new Point(e.X, e.Y));
                    menuStrip.ItemClicked += new ToolStripItemClickedEventHandler(kek);
                    string ID = dataGridView1.Rows[currentMouseOverRow].Cells["ID"].Value.ToString();
                    Row = int.Parse(ID);
                }
            }
        }

        private void kek(object sender, ToolStripItemClickedEventArgs e)
        {

           switch(e.ClickedItem.Name.ToString())
            {
                case "Change":
                    MessageBox.Show($"Change {Row}");
                    break;

                case "Delete":
                    MessageBox.Show($"Change {Row}");
                    break;

                case "Copy":
                    MessageBox.Show($"Change {Row}");
                    break;

            }
            Row = -1;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Helper.Serialize();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewStudent form = new NewStudent();
            Hide();
            form.ShowDialog();
            Show();
            dataGridView1.DataSource = Helper.students;
        }
    }
}
