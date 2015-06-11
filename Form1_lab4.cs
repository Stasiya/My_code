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
             
            if (textBox1.Text != string.Empty)
                textBox1.Text = Crypt(textBox1.Text,textBox3.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if(textBox2.Text != string.Empty)
                textBox2.Text = Decrypt(textBox2.Text,textBox3.Text);
        }

        string Crypt(string word,string key)
        {
            this.textBox4.Clear();
            this.dataGridView1.Rows.Clear();
            Key_Table(key);
            foreach (char character in word)        
            {
                
                char m = character;
                int column = 1;
                int row = 0;
                int skip = 0;
                foreach (char character1 in key)
                {
                    char k = character1;
                    if (k != 13)
                    {
                        column++;
                    }
                    else
                    {
                        row++;
                        column = 0;
                    }

                    if ((m == k) && (skip == 0))
                    {
                         dataGridView1[column-1 , row].Style.BackColor = System.Drawing.Color.LightGreen;
                         textBox4.Text += (column + 8).ToString() + (row + 10).ToString() + " ";
                         skip++;                        
                    }
                    
                     
                }   
               
            }
            for (int i = 0; i < 90; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, i].Value = (10 + i);
            }
            return word; 
        }

        string Decrypt(string shifrograma, string key)
        {
            6
            this.textBox5.Clear();
            this.dataGridView1.Rows.Clear();
            Key_Table(key);
            string[] param = textBox2.Text.Split( new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries );
            int[] mas = new int[ param.Length ];
            for ( int i = 0; i < param.Length; i++ )
                mas[ i ] = int.Parse( param[ i ] );

            int column = 1;
            int row = 0;
            int j = 0;
            while(j<mas.Length)
              {
                 column = mas[j] / 100;
                 row = mas[j] % 100;
                 textBox5.Text += dataGridView1[column - 9, row-10].Value.ToString();
                 dataGridView1[column - 9, row - 10].Style.BackColor = System.Drawing.Color.Purple;
                 j ++;
              }        
            for (int num_riad = 0; num_riad < 100; num_riad++)
              dataGridView1[0, num_riad].Value = (10 + num_riad);

        return shifrograma;
        }

        private void Key_Table(string key)
        {
               int column = 1;
               int row = 0;

               foreach (char character1 in key)
               {

                   char k = character1;
                   if (column == 91)
                   {
                       row++;
                       column = 1;
                   }
                   if (k != 13)
                   {
                       dataGridView1.Rows.Add();
                       dataGridView1[column, row].Value = k;
                       column++;
                   }
                   else
                   {
                       row++;
                       column = 0;
                   }
               }
        }
     
     
        private void SaveFile_Click(object sender, EventArgs e)
        {
            StreamWriter write_text;  
            FileInfo file = new FileInfo(file_nam.Text); 
            write_text = file.AppendText(); 
            write_text.WriteLine(textBox4.Text); 
            write_text.Close(); 
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                using (StreamReader sr = File.OpenText(openFileDialog1.FileName))
                    textBox4.Text = sr.ReadToEnd();
        }        
    }
}
