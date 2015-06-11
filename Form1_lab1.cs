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
            int keyform = Convert.ToInt32(textBox3.Text);   
            if (textBox1.Text != string.Empty) //условия поля шага
                textBox1.Text = Caesar(textBox1.Text, keyform); //шифрование
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int keyform = Convert.ToInt32(textBox3.Text);   
            if(textBox1.Text != string.Empty)
                textBox2.Text = Decode(textBox1.Text, keyform); //дешифровка
        }

        string Caesar(string word, int key) //алгоритм
        {
          
            StringBuilder sb = new StringBuilder(); 
            foreach (char character in word)        
            {
                char ch = character;                 
                ch = (char)(ch + key);              
                if (ch >= 'я')                     
                    ch = (char)(ch - 32);          
                sb.Append(ch.ToString());           
            }
            return sb.ToString();           
        }

        string Decode(string word, int key)
        {
       
            StringBuilder sb = new StringBuilder();
            foreach (char character in word)
            {
                char ch = character;
                ch = (char) ((int) ch - key); 
                if (ch >= 'я')
                    ch = (char)(ch + 32); 
                sb.Append(ch.ToString());
            }
            return sb.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            File.AppendAllText(file_nam.Text, textBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = File.ReadAllText(file_nam.Text);
        }
    }
}
