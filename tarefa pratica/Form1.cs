using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tarefa_pratica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<Filmes> filmes = new List<Filmes>();
           contador a = new contador();
        }
        public void Form1_Load(object sender, EventArgs e)
        {
           
        }

        public void button1_Click(object sender, EventArgs e,List<Filmes> filmes,contador a)
        {
            Filmes f = new Filmes();
            //contador s;
            //List<Filmes> filme; 
           
            if (textBox1.Text != "" || comboBox1.Text != "" || maskedTextBox1.Text != "" || textBox3.Text != "")
            {
                f.nome = textBox1.Text;
                f.genero = comboBox1.Text;
                f.data = maskedTextBox1.Text;
                f.local = textBox3.Text;
                filmes.Add(f);
                a.i++;
            }
        }

       

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Text = DateTime.Now.AddDays(3).ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Now.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            maskedTextBox1.Text = "";
            textBox3.Text = "";
        }
    }
}
