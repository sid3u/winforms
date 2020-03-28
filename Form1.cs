using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Text;
using Microsoft.VisualBasic;
using System.Windows.Media.Imaging;
using System.Web;
using Aurigma.GraphicsMill.Codecs;




namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        static int i = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // listView1.View = View.SmallIcon;
            imageList1.ImageSize = new Size(100, 100);

            /*
               String[] paths = { };
                paths = Directory.GetFiles(@"C:\Users\Utilisateur\Desktop\Master 1\db");

                 foreach(String path in paths)
                 {
                    imageList1.Images.Add(Image.FromFile(path));
                     listView1.Items.Add("son", i);
                     i++;
                 }

                /* listView1.Items.Add("son", 0);
                 listView1.Items.Add("goky", 1);
                 listView1.Items.Add("son", 2);*/


        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "All files |*.*", ValidateNames = true, Multiselect = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string f in ofd.FileNames)
                    {

                        imageList1.Images.Add(Image.FromFile(f));



                        ListViewItem item = new ListViewItem();
                        item.Text = Path.GetFileName(f);
                        item.ImageIndex = i++;
                        listView1.Items.Add(item);





                        // PropertyItem[] propItems = image.PropertyItems;
                        //foreach (PropertyItem propItem in propItems)
                        //{



                        // propItem.Value = System.Text.Encoding.UTF8.GetBytes(item.ToString() + "\0");
                        //Console.WriteLine(propItem.Id);
                        //Console.WriteLine(System.Text.Encoding.Default.GetString(propItem.Value));
                        /*  Console.WriteLine(propItem.Id);

                        using (var file = Image.FromFile(path))
                        {
                            PropertyItem propItem = file.PropertyItems[0];
                            propItem.Type = 2;
                            propItem.Value = System.Text.Encoding.UTF8.GetBytes(item.ToString() + "\0");
                            propItem.Len = propItem.Value.Length;
                            file.SetPropertyItem(propItem);
                        }*/



                    }
                }
            }

        }



        private void button2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    foreach (String path in files)
                    {
                        imageList1.Images.Add(Image.FromFile(path));
                        ListViewItem item = new ListViewItem();
                        item.Text = Path.GetFileName(path);
                        item.ImageIndex = i++;
                        listView1.Items.Add(item);


                    }
                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listView1.SelectedItems)
            {
                listView1.Items.Remove(item);

            }
        }
      
        /*
                Image Zoom(Image img, Size size)
                {
                    Bitmap bmp = new Bitmap(img, img.Width + (img.Width * size.Width / 100), img.Height + (img.Height * size.Height / 100);
                    Graphics g = Graphics.FromImage(bmp);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    return bmp;
                }
        */

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value > 0)
            {
                foreach (ListViewItem item in this.listView1.SelectedItems)
                {
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "All files |*.*", ValidateNames = true, Multiselect = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string f in ofd.FileNames)
                    {

                      
                        using (FileStream fs = new FileStream(f, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            BitmapSource img = BitmapFrame.Create(fs);
                            BitmapMetadata md = (BitmapMetadata)img.Metadata;
                            string commentaire =" ";
                            for (int i = 0; i < md.Keywords.Count; i++) {
                                commentaire += " "+md.Keywords[i];
                            }
                            Console.WriteLine(commentaire);
                           
                            
                            
                            



                        }

                    }
                }

            }

        }

    }
}

