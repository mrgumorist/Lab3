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
        Helper helper = new Helper();
      public Form1()
        {
            InitializeComponent();
                
        }
   
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = helper.students;
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
                    menuStrip.Show(dataGridView1, new Point(e.X, e.Y));
                    menuStrip.ItemClicked += new ToolStripItemClickedEventHandler(kek);
                    Row = currentMouseOverRow;

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
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            helper.Serialize();
        }
    }
}
