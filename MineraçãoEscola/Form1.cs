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
using System.Diagnostics;


namespace MineraçãoEscola
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        public static string ExecutarCMD(string comando)
        {

            using (Process processo = new Process())
            {

                processo.StartInfo.FileName = Environment.GetEnvironmentVariable("comspec");

                processo.StartInfo.Arguments = string.Format("/c {0}", comando);

                processo.StartInfo.RedirectStandardOutput = true;
                processo.StartInfo.UseShellExecute = false;
                processo.StartInfo.CreateNoWindow = true;


                processo.Start();
                processo.WaitForExit();

                string saida = processo.StandardOutput.ReadToEnd();
                return saida;
            }
        }
        //########


        private void button2_Click(object sender, EventArgs e)
        {

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void diretórioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //abre o Folder Browser Dialog
                this.folderBrowserDialog1.Description = "Selecione seu diretório";
                this.folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
                this.folderBrowserDialog1.ShowNewFolderButton = true;

                DialogResult result = this.folderBrowserDialog1.ShowDialog();

                if (result == DialogResult.OK)
                {
                    label5.Text = "  " + folderBrowserDialog1.SelectedPath;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string arquivo = @"" + label5.Text + @"\csFiltro.txt";

            try {
                using (StreamWriter writer = new StreamWriter(arquivo, false))
                {
                    string check = "";

                    if (checkBox1.Checked == true)
                    {
                        check = check + "&energiaInexistente=on";
                    }

                    if (checkBox2.Checked == true)
                    {
                        check = check + "&aguaInexistente=on";
                    }

                    if (checkBox3.Checked == true)
                    {
                        check = check + "&esgotoInexistente=on";
                    }

                    if (checkBox4.Checked == true)
                    {
                        check = check + "&laboratorioCiencias=on";
                    }

                    if (checkBox5.Checked == true)
                    {
                        check = check + "&laboratorioInformatica=on";
                    }

                    if (checkBox6.Checked == true)
                    {
                        check = check + "&biblioteca=on";
                    }

                    /**************************/

                    if (comboBox1.Text == "" || comboBox1.Text == "Brasil")
                    {
                        writer.Write("&Brasil" + check + "#");
                    }
                    else
                    {
                        writer.Write("&estado=" + comboBox1.Text + check + "#");
                    }

                    if (comboBox2.Text == "" || comboBox2.Text == "Brasil")
                    {
                        writer.Write("&Brasil" + check + "#");
                    }
                    else
                    {
                        writer.Write("&estado=" + comboBox2.Text + check + "#");
                    }

                    if (comboBox3.Text == "" || comboBox3.Text == "Brasil")
                    {
                        writer.Write("&Brasil" + check + "#");
                    }
                    else
                    {
                        writer.Write("&estado=" + comboBox3.Text + check + "#");
                    }

                    if (comboBox4.Text == "" || comboBox4.Text == "Brasil")
                    {
                        writer.Write("&Brasil" + check + "#");
                    }
                    else
                    {
                        writer.Write("&estado=" + comboBox4.Text + check + "#");
                    }

                    if (comboBox5.Text == "" || comboBox5.Text == "Brasil")
                    {
                        writer.Write("&Brasil" + check);
                    }
                    else
                    {
                        writer.Write("&estado=" + comboBox5.Text + check);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            MessageBox.Show(ExecutarCMD("cd " + label5.Text + " && py pyMineraçãoEscola.py"), "Relatório");
        }
    }
}
