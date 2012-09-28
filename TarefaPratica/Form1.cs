using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TarefaPratica
{
    public partial class Form1 : Form
    {
        public Form1()
        { 
            InitializeComponent();
        }
        List<Filme> filme = new List<Filme>();
        
        Dictionary<string,ListViewItem> dicionario = new Dictionary<string,ListViewItem>();
        
        public void button1_Click(object sender, EventArgs e)
        {
            Filme novo = new Filme();
            ListViewItem a = new ListViewItem();
            novo.nome = textBox1.Text; textBox1.Text = "";
            novo.genero = comboBox1.Text; comboBox1.Text = "";
            novo.data = dateTimePicker1.Text; dateTimePicker1.Value = DateTime.Now;
            novo.local = textBox2.Text; textBox2.Text = "";
            filme.Add(novo);
            a.Text=novo.nome;
            a.SubItems.Add(novo.genero);
            a.SubItems.Add(novo.data);
            a.SubItems.Add(novo.local);
            dicionario.Add(novo.nome,a);
            listView1.Items.Add(a);
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //laço para limpar
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                listView2.Items.Remove(listView2.Items[i]);
            }
            ListViewItem a = new ListViewItem();
            ListViewItem b = new ListViewItem();
            b.SubItems.Add(comboBox2.Text);
            for (int i = 0; i < dicionario.Count; i++)
            {
                
                //if (textBox4.Text.Length == filme[i].nome[])
                //String.Compare(textBox4.Text,filme[i].nome.ToString());
                if ((dicionario.ContainsKey(textBox4.Text) && checkBox1.Checked)/* ||
                   (dicionario.ContainsValue(b) && checkBox2.Checked ==  true)*/)
                {
                    a.Text = filme[i].nome;
                    a.SubItems.Add(filme[i].genero);
                    a.SubItems.Add(filme[i].data);
                    a.SubItems.Add(filme[i].local);
                    listView2.Items.Add(a);
                }
            }
        }
        int i = 0;
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox4.Enabled =checkBox1.Checked;
            i++;
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            comboBox2.Enabled = checkBox2.Checked;
            i++;
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
                dateTimePicker2.Enabled = checkBox3.Checked;
                dateTimePicker3.Enabled = checkBox3.Checked;
                i++;
        }

        private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox3.Enabled = checkBox4.Checked;
            i++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.SelectedItems.Clear();
        }
    }
}
