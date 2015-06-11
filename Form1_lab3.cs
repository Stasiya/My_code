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
                textBox2.Text = Code(textBox1.Text,znak);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var znak = -1;
            if(textBox2.Text != string.Empty)
                textBox2.Text = Code(textBox2.Text,znak);
        }

        string Code(string word,int znak)
        {
            button1.Enabled = true;
            var row = 0;
            var pvch = new int[1000];
            pvch[0] = znak*Convert.ToInt32(gam_param.Text);
            StringBuilder sb = new StringBuilder();
            foreach (var character in word)        
            {
                var m = character;
                pvch[row + 1] = ((pvch[row] * Convert.ToInt32(gam_param.Text) + znak*Convert.ToInt32(gam_param.Text)) % 254);
                dataGridView1.Rows.Add();
                dataGridView1[0,row].Value = pvch[row];
                row++;
                                
                m= (char)(m + pvch[row]);                      
                sb.Append(m.ToString());           
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

      
        
    }
}
