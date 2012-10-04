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
        //Dictionary<string, List<Filme>> Difilmes = new Dictionary<string, List<Filme>>();
        Dictionary<string,Filme> dicionario = new Dictionary<string,Filme>();

        public void limpar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }
        public void inselist()
        {
            try
            {
                Filme novo = new Filme();
                ListViewItem a = new ListViewItem();
                novo.nome = textBox1.Text;
                novo.genero = comboBox1.Text;
                novo.data = dateTimePicker1.Text;
                novo.local = textBox2.Text;
                filme.Add(novo);
                a.Text = novo.nome;
                a.SubItems.Add(novo.data);
                a.SubItems.Add(novo.local);
                a.Group = listView1.Groups[novo.genero];
                dicionario.Add(novo.nome, novo);
                listView1.Items.Add(a);
                limpar();
                textBox1.Focus();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("esse filme ja existe");
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
                MessageBox.Show("Preencha todos os campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                inselist();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = listView1.SelectedItems.Count - 1; i >= 0; i--)
            {
                Filme l = filme[i];
                if (l.nome == listView1.SelectedItems[0].Text)
                {
                    filme.Remove(l);
                    dicionario.Remove(l.nome);
                }
                ListViewItem a = listView1.SelectedItems[i];
                a.Remove();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = listView1.SelectedItems.Count - 1; i >= 0; i--)
            {
                ListViewItem a = listView1.SelectedItems[i];               
                textBox1.Text = a.Text;
                textBox2.Text = a.SubItems[2].Text;
                comboBox1.Text = a.Group.Name;
                dateTimePicker1.Text = a.SubItems[1].Text;
                dicionario.Remove(a.Text);
                button1.Enabled = true;
                button_ad.Enabled = false;
                button3.Enabled = false;
                button_ed.Enabled = false;               
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = listView1.SelectedItems.Count - 1; i >= 0; i--)
            {
                ListViewItem w = listView1.SelectedItems[i];
                w.Remove();
                ListViewItem x = new ListViewItem();
                Filme f = new Filme();
                x.Text = textBox1.Text;
                f.nome = textBox1.Text;
                dicionario.Remove(x.Text);
                x.SubItems.Add(dateTimePicker1.Text);
                f.data = dateTimePicker1.Text;
                x.SubItems.Add(textBox2.Text);
                f.local = textBox2.Text;
                x.Group = listView1.Groups[comboBox1.Text];
                f.genero = comboBox1.Text;
                dicionario.Add(x.Text,f);
                listView1.Items.Add(x);
                button_ad.Enabled = true;
                button_ed.Enabled = false;
                button3.Enabled = false;
                button1.Enabled = false;
                limpar();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_ed.Enabled = true;
            button3.Enabled = true;
            button_ad.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                button_ed.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            ListViewItem pesq = new ListViewItem();
            pesq.Text = textBox4.Text;
            pesq.SubItems.Add(dateTimePicker2.Text);
            pesq.SubItems.Add(dateTimePicker3.Text);
            pesq.SubItems.Add(textBox3.Text);
            pesq.Group = listView2.Groups[comboBox2.Text];
            if (radioButton1.Checked)
            {
                foreach (string a in dicionario.Keys)
                {
                    if ((a.CompareTo(pesq.Text)) >= 0)
                    {
                        ListViewItem b = new ListViewItem();
                        b.Text = a;
                        b.SubItems.Add(dicionario[a].data);
                        b.SubItems.Add(dicionario[a].local);
                        b.Group = listView2.Groups[dicionario[a].genero];
                        listView2.Items.Add(b);
                    }
                }
            }
            else if (radioButton2.Checked)
            {
                foreach (Filme a in dicionario.Values)
                {
                    if (pesq.Group.Name == (a.genero))
                    {
                        ListViewItem b = new ListViewItem();
                        b.Text = a.nome;
                        b.SubItems.Add(dicionario[a.nome].data);
                        b.SubItems.Add(dicionario[a.nome].local);
                        b.Group = listView2.Groups[dicionario[a.nome].genero];
                        listView2.Items.Add(b);
                    }
                }
            }
            else if (radioButton3.Checked)
            {
                foreach (Filme a in dicionario.Values)
                {
                    if (a.data.CompareTo(pesq.SubItems[1].Text) <= 0 && a.data.CompareTo(pesq.SubItems[2].Text) >= 0)
                    {
                        ListViewItem b = new ListViewItem();
                        b.Text = a.nome;
                        b.SubItems.Add(dicionario[a.nome].data);
                        b.SubItems.Add(dicionario[a.nome].local);
                        b.Group = listView2.Groups[dicionario[a.nome].genero];
                        listView2.Items.Add(b);
                    }
                }
            }
            else if (radioButton4.Checked)
            {
                foreach (Filme a in dicionario.Values)
                {
                    if ((pesq.SubItems[3].Text.CompareTo(a.local)) <= 0)
                    {
                        ListViewItem b = new ListViewItem();
                        b.Text = a.nome;
                        b.SubItems.Add(dicionario[a.nome].data);
                        b.SubItems.Add(dicionario[a.nome].local);
                        b.Group = listView2.Groups[dicionario[a.nome].genero];
                        listView2.Items.Add(b);
                    }
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            limpar();
            button_ad.Enabled = true;
            button_ed.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Enabled = radioButton1.Checked;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = radioButton2.Checked;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Enabled = radioButton3.Checked;
            dateTimePicker3.Enabled = radioButton3.Checked;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = radioButton4.Checked;
        }
    }
}