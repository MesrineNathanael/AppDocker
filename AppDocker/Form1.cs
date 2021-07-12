using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        int defaultPosY;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.Navy;

            //this.StartPosition = FormStartPosition.Manual;
            this.Top = Screen.PrimaryScreen.Bounds.Height - 180;
            defaultPosY = Screen.PrimaryScreen.Bounds.Height - 180;
            this.Left = Screen.PrimaryScreen.Bounds.Width-1214-353;

            notifyIcon1.Text = "Galaxy Docker";
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;

            ContextMenu cm = new ContextMenu();
            MenuItem mi1 = new MenuItem("Exit");
            cm.MenuItems.Add(mi1);
            notifyIcon1.ContextMenu = cm;
            mi1.Click += new System.EventHandler(this.mi1_Click);
            notifyIcon1.MouseClick += NotifyIcon1_MouseClick;

            timer1.Interval = 1000;
            timer1.Start();

            Item it1 = new Item("modassis", "C:\\Users\\Nathanael\\Desktop\\yes\\ModAssistant.exe");
            Item it2 = new Item("bread", "C:\\Users\\Nathanael\\Desktop\\yes\\bread\\Breadboard.exe");
            item.Add(it1);
            item.Add(it2);
            int x = 0;
            foreach(Item it in item)
            {
                Button bt = new Button();
                bt.Enabled = true;
                bt.Height = 100;
                bt.Width = 100;
                bt.Location = new Point(15+x, 15);
                bt.Text = it.getName();
                bt.ForeColor = Color.Transparent;
                bt.Name = it.getName();
                bt.BackColor = Color.Transparent;
               
                bt.FlatStyle = FlatStyle.Popup;


                bt.BackgroundImage = Bitmap.FromHicon(Icon.ExtractAssociatedIcon(it.getPath()).Handle);
                bt.BackgroundImageLayout = ImageLayout.Stretch;
                bt.Click += new EventHandler(Item_Click);
                this.Controls.Add(bt);
                x += 115;
            }
        }

        private void mi1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {


        }

        private void Item_Click(object sender, EventArgs e)
        {
            string name;
            
            name = sender.ToString();
            
            name = name.Substring(35, name.Length - 35);
            Console.WriteLine(name);
            Item ite = item.Find(x => x.getName() == name);
            Process.Start(ite.getPath());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int pos = this.Location.Y;
            if (MouseIsOver())
            {
                //this.Top = defaultPosY;
                this.TopMost = true;
                while (pos > 900)
                {
                    pos -= 1;
                    this.Top = pos;
                    Thread.Sleep(1);
                }
                
                
                
            }
            else
            {
                while (pos < 1079)
                {
                   
                    if (MouseIsOver())
                    {
                        this.Top = defaultPosY;
                        break;
                    }
                    pos += 1;
                    this.Top = pos;
                    this.TopMost = false;
                    Thread.Sleep(4);
                }
            }

            Console.WriteLine(pos);
        }
        private bool MouseIsOver() =>
    this.ClientRectangle.Contains(this.PointToClient(Cursor.Position));

    }
}
