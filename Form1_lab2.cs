using System;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace char__
{
    
    public partial class Form1 : Form
    {     
        public Form1()
        {
            InitializeComponent();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var znak = 1;  
            if (textBox1.Text != string.Empty)
                textBox2.Text = Code(textBox1.Text,Gaslo.Text,znak);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var znak = -1;
            if(textBox1.Text != string.Empty)
                textBox2.Text = Code(textBox2.Text,Gaslo.Text,znak);
        }

        string Code(string word,string gsl,int znak)
        {
            var k=0;
            var t = 0;          
            StringBuilder sb = var StringBuilder();
            foreach (var character in word)        
            {
                var ch = character;
                t++;

                if (Check_Liniyne.Checked)
                {
                    k = Convert.ToInt32(a.Text) * t + Convert.ToInt32(b.Text);
                }
                else
                    if (Check_Neliniyne.Checked)
                    {
                        k = Convert.ToInt32(a.Text) * t * t  + Convert.ToInt32(b.Text) * t + Convert.ToInt32(c.Text);
                    }
                    else
                        if (Check_Gaslo.Checked)
                        {
                            foreach (var character1 in gsl)
                            {
                                var ch1 = character1;
                                k = ch1;     
                            } 
                        }
                        else 
                            MessageBox.Show("Ви не вибрали метод шифрування!","Вибір методу", MessageBoxButtons.OK, MessageBoxIcon.Information);
                k = k * znak;
                ch = (char)(ch + k);                      
                sb.Append(ch.ToString());           
            }
            return sb.ToString();           
        }

    
          
        private void SaveFile_Click(object sender, EventArgs e)
        {
            StreamWriter write_text;  
            FileInfo file = var FileInfo(file_nam.Text); 
            write_text = file.AppendText(); 
            write_text.WriteLine(textBox2.Text); 
            write_text.Close(); 
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                var (StreamReader sr = File.OpenText(openFileDialog1.FileName))
                    textBox2.Text = sr.ReadToEnd();
        }

        private void Check_Gaslo_CheckedChanged(object sender, EventArgs e)
        {
            Gaslo.Enabled = true;
            a.Enabled = false;
            b.Enabled = false;
            c.Enabled = false;
            
        }

        private void Check_Liniyne_CheckedChanged(object sender, EventArgs e)
        {
            Gaslo.Enabled = false;
            a.Enabled = true;
            b.Enabled = true;
            c.Enabled = false;
        }

        private void Check_Neliniyne_CheckedChanged(object sender, EventArgs e)
        {
            Gaslo.Enabled = false;
            a.Enabled = true;
            b.Enabled = true;
            c.Enabled = true;
        }

        
        
    }
}
