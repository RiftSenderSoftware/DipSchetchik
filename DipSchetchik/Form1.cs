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
using System.Drawing.Text;

namespace DipSchetchik
{
    public partial class Form1 : Form
    {
        string filename;
        DataSet data = new DataSet();

        public Form1()
        {
            InitializeComponent();
        }

        private void открытьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveTextFile();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        // открывает текстовые файлы с запятыми
        public void openTextFile()
        {
            // очищает таблицу каждый раз при запуске функции
            data.Tables.Clear();
            // открывает диалоговое окно с выбором файла
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // передаёт значение из открытого диалога в стринг
                filename = openFileDialog.FileName;
            }

            try
            {
                StreamReader reader = new StreamReader(@"" + filename);
                label1.Text = filename;

                // прибавляет +1, когда дата обновляется.
                int coutData = 0;
                coutData += 1;
                data.Tables.Add("dataMounce" + coutData);
                // если определяет, что файл не соответствует требованиям выводит окно с ошибкой и кодом ошибки
                try
                {
                    string header = reader.ReadLine();
                    string[] cout = System.Text.RegularExpressions.Regex.Split(header, ",");

                    for (int c = 0; c < cout.Length; c++)
                    {
                        data.Tables[0].Columns.Add(cout[c]);
                    }
                    string row = reader.ReadLine();
                    while (row != null)
                    {
                        string[] rvalue = System.Text.RegularExpressions.Regex.Split(row, ",");
                        data.Tables[0].Rows.Add(rvalue);
                        row = reader.ReadLine();
                    }
                    dataGridView1.DataSource = data.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка чтения!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }


                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка чтения!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }
        public void saveTextFile()
        {
            try
            {
                StreamWriter writer = new StreamWriter(@"" + filename, false, Encoding.Unicode);
                for (int j = 0; j < data.Tables[0].Columns.Count; j++)
                {
                    writer.Write((data.Tables[0].Columns[j]).ToString());
                    if (j != data.Tables[0].Columns.Count - 1)
                    {
                        writer.Write(",");
                    }
                }
                writer.WriteLine("");
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j != data.Tables[0].Columns.Count; j++)
                    {
                        writer.Write(data.Tables[0].Rows[i][j].ToString());
                        if (j != data.Tables[0].Columns.Count - 1)
                        {
                            writer.Write(",");
                        }
                    }
                    writer.WriteLine("");
                }
                MessageBox.Show("Сохранение прошло успешно","Сохранено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Нужно открыть файл", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openTextFile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openTextFile();
        }



        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openTextFile();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveTextFile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Создание экземпляра формы сверки
            WindowRevise frevise = new WindowRevise(); 
            frevise.Show();
        }
        protected void Form1_Closed(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openTextFile();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openTextFile();
        }
    }
}
