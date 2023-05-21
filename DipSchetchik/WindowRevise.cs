using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DipSchetchik
{
    public partial class WindowRevise : Form
    {
        string filename;
        DataSet data = new DataSet();
        public WindowRevise()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
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


            StreamReader reader = new StreamReader(@"" + filename);
            label2.Text = filename;

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
                dataGridView2.DataSource = data.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка чтения!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        protected void WindowRevice_Closed(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
