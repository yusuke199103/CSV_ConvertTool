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

namespace CSV_ConvertTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ファイルを選択するボタン
            string select_file_path = "";
            OpenFileDialog csv_fd = new OpenFileDialog();
            csv_fd.FileName = "default.csv";
            csv_fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            csv_fd.Filter = "Excelファイル(*.csv)|*.csv|すべてのファイル(*.*)|*.*";
            csv_fd.FilterIndex = 2;
            csv_fd.Title = "変換したいCSVファイルを選択してください。";
            csv_fd.RestoreDirectory = true;
            csv_fd.CheckFileExists = true;
            csv_fd.CheckPathExists = true;

            if (csv_fd.ShowDialog() == DialogResult.OK)
            {
                select_file_path=csv_fd.FileName;
            }

            this.textBox1.Text = select_file_path;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //変換を開始するボタン
            MessageBox.Show("変換を開始します。");
            string file_path = "";
            string line = "";
            string output_path = "";
            file_path = this.textBox1.Text;
            output_path = file_path;
            output_path = output_path.Replace(".csv", "");
            output_path = output_path.Replace(".CSV", "");
            output_path = output_path + "出力.csv";
            StreamWriter out_sr = new StreamWriter(output_path, false, Encoding.GetEncoding("Shift_JIS"));
            StreamReader sr = new StreamReader(file_path, Encoding.GetEncoding("shift_jis"));
            {
                // 末尾まで繰り返す
                while (sr.Peek() >= 0)
                {
                    // CSVファイルの一行を読み込む
                    line = sr.ReadLine();
                    Console.WriteLine(line);
                    if (line.Substring(0, 1) == "1")
                    {
                        out_sr.Write('"' + line.Substring(0, 1) + '"' + ",");
                        out_sr.Write('"' + line.Substring(1, 2) + '"' + ",");
                        out_sr.Write('"' + line.Substring(3, 1) + '"' + ",");
                        out_sr.Write('"' + line.Substring(4, 10) + '"' + ",");
                        out_sr.Write('"' + line.Substring(14, 40) + '"' + ",");
                        out_sr.Write('"' + line.Substring(54, 4) + '"' + ",");
                        out_sr.Write('"' + " " + '"' + ",");
                        out_sr.Write("\r\n");
                    }
                    else if (line.Substring(0, 1) == "2") {
                        out_sr.Write('"' + line.Substring(0, 1) + '"' + ",");
                        out_sr.Write('"' + line.Substring(1, 4) + '"' + ",");
                        out_sr.Write('"' + line.Substring(5, 15) + '"' + ",");
                        out_sr.Write('"' + line.Substring(20, 3) + '"' + ",");
                        out_sr.Write('"' + line.Substring(23, 15) + '"' + ",");
                        out_sr.Write('"' + " " + '"' + ",");
                        out_sr.Write('"' + line.Substring(42, 1) + '"' + ",");
                        out_sr.Write('"' + line.Substring(43, 7) + '"' + ",");
                        out_sr.Write('"' + line.Substring(50, 30) + '"' + ",");
                        out_sr.Write('"' + line.Substring(80, 10) + '"' + ",");
                        out_sr.Write('"' + line.Substring(90, 1) + '"' + ",");
                        out_sr.Write('"' + line.Substring(97, 14) + '"' + ",");
                        out_sr.Write('"' + line.Substring(111, 1) + '"' + ",");
                        out_sr.Write('"' + " " + '"' + ",");
                        out_sr.Write("\r\n");
                    }
                    else if (line.Substring(0, 1) == "8")
                    {
                        out_sr.Write('"' + line.Substring(0, 1) + '"' + ",");
                        out_sr.Write('"' + line.Substring(1, 6) + '"' + ",");
                        out_sr.Write('"' + line.Substring(7, 12) + '"' + ",");
                        out_sr.Write('"' + line.Substring(19, 6) + '"' + ",");
                        out_sr.Write('"' + line.Substring(25, 12) + '"' + ",");
                        out_sr.Write('"' + line.Substring(38, 6) + '"' + ",");
                        out_sr.Write('"' + line.Substring(43, 12) + '"' + ",");
                        out_sr.Write('"' + " " + '"' + ",");
                        out_sr.Write("\r\n");
                    }
                    else if (line.Substring(0, 1) == "9")
                    {
                        out_sr.Write('"' + line.Substring(0, 1) + '"' + ",");
                        out_sr.Write('"' + " " + '"');
                        out_sr.Write("\r\n");
                    }
                }
            }
            out_sr.Write(" ");
            sr.Close();
            out_sr.Close();
            MessageBox.Show("変換が完了しました。");
        }
    }
}
