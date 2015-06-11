using System;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;

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
            {
                DESCryptoServiceProvider crypt = new DESCryptoServiceProvider();
                crypt.Key = UnicodeEncoding.UTF8.GetBytes(key.Text);
                crypt.IV = UnicodeEncoding.UTF8.GetBytes(vector.Text);
                using (FileStream fs = new FileStream(@"C:\Users\Anastasia\Desktop\КПИ\Тарнавский\Laba5\char++\bin\Debug\" + file_nam.Text, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (CryptoStream cs = new CryptoStream(fs, crypt.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] data = UnicodeEncoding.UTF8.GetBytes(textBox1.Text);
                        cs.Write(data, 0, data.Length);
                    }
                }
                
                MessageBox.Show("Шифрування завершено, файл збережено із назвою "+file_nam.Text,"Шифрування",MessageBoxButtons.OK);
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
                     
           
            DESCryptoServiceProvider decrypt = new DESCryptoServiceProvider();
            decrypt.Key = UnicodeEncoding.UTF8.GetBytes(key.Text);
            decrypt.IV = UnicodeEncoding.UTF8.GetBytes(vector.Text);
            using (FileStream fs = new FileStream(@filename_open.Text, FileMode.Open, FileAccess.Read))
            {
                CryptoStream cs = new CryptoStream(fs, decrypt.CreateDecryptor(), CryptoStreamMode.Read);
                using (StreamReader read = new StreamReader(cs))
                {
                    string data = read.ReadToEnd();
                    textBox1.Text = data;
                }
            }              
        }

           
     

        private void Open_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename_open.Text = openFileDialog1.FileName;
            }
        }
         
    }
}
