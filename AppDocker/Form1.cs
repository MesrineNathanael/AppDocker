using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDocker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Item> item = new List<Item>();
        private void Form1_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.Navy;



            Item it1 = new Item("bread", "C:\\Users\\Nathanael\\Desktop\\bread\\Breadboard.exe");
            item.Add(it1);
            foreach(Item it in item)
            {
                PictureBox pt = new PictureBox();
                pt.Enabled = true;
                pt.Height = 100;
                pt.Width = 100;
                pt.Location = new Point(10, 10);
                pt.Text = it.getName();
                pt.BackColor = Color.Transparent;
                pt.BorderStyle = BorderStyle.FixedSingle;
                pt.Click += new EventHandler(Item_Click);
                this.Controls.Add(pt);

            }
        }

        private void Item_Click(object sender, EventArgs e)
        {
            string name;
            name = sender.ToString();
            name = name.Substring(35, name.Length - 35);

            Item ite = item.Find(x => x.getName() == name);
            Process.Start(ite.getPath());
        }
    }
}
