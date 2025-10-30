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

namespace WindowsFormsApplication12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string path="";
        bool savestatus=false;
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0)
            {
                if (MessageBox.Show("do you want save", "save", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        path = saveFileDialog1.FileName;
                        File.AppendAllText(path, textBox1.Text);
                    }
                }
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                textBox1.Text = File.ReadAllText(path);
            }



        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (path == "")
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog1.FileName;
                }
            }
            File.AppendAllText(path,textBox1.Text);
            savestatus = true;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;
                File.AppendAllText(path,textBox1.Text);
            }
            savestatus = true;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (savestatus == true)
                this.Close();
            else
            {
                DialogResult r = MessageBox.Show("do you want to save change", "save", MessageBoxButtons.YesNoCancel);
                if (r == DialogResult.Yes)
                {
                    if (path == "")
                    {
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            path = saveFileDialog1.FileName;
                            File.AppendAllText(path, textBox1.Text);
                            savestatus = true;
                        }
                    }
                    else
                    {
                        File.AppendAllText(path, textBox1.Text);
                        savestatus = true;
                    }
                    this.Close();
                }
                if (r == DialogResult.No)
                {
                    this.Close();
                }
                if (r == DialogResult.Cancel)
                {
                    return;
                }
            }

                        
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (savestatus == true)
                textBox1.Clear();
            else
            {
                DialogResult r = MessageBox.Show("do you want to save change", "save", MessageBoxButtons.YesNoCancel);
                if (r == DialogResult.Yes)
                {
                    if (path == "")
                    {
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            path = saveFileDialog1.FileName;
                            File.AppendAllText(path, textBox1.Text);
                            savestatus = true;
                        }
                    }
                    else
                    {
                        File.AppendAllText(path, textBox1.Text);
                        savestatus = true;
                    }
                    textBox1.Clear();

                }
                if (r == DialogResult.No)
                {
                    textBox1.Clear();

                }
                if (r == DialogResult.Cancel)
                {
                    return;
                }
            }
        }
    }
}
