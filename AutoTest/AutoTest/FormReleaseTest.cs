using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using jini;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;

namespace AutoTest
{
    public partial class FormReleaseTest : Form
    {

        Dictionary<string, string> TestCaseDic = new Dictionary<string, string>();
        private string testCaseDicPath = Application.StartupPath + "\\TestCase.ini";
        List<string> dataGridViewList = new List<string>();

        private void CreateDictionary()
        {
            StreamReader str = new StreamReader(testCaseDicPath);
            string item = string.Empty;
            while ((item = str.ReadLine()) != null)
            {
                if (item.Length > 0)
                {
                    TestCaseDic.Add(item.Substring(0, item.IndexOf("=")).Trim(), Application.StartupPath + "\\TestCase\\" + item.Substring(item.IndexOf("=") + 1, item.Length - (item.IndexOf("=") + 1)).Trim());

                }
            }
            str.Close();
        }


        public FormReleaseTest()
        {
            InitializeComponent();
            this.FormClosed += FormReleaseTest_FormClosed;
            CreateDictionary();
            foreach (string key in TestCaseDic.Keys)
            {
                comboBox_TestItem.Items.Add(key);
            }
            //comboBox_TestItem.SelectedIndex = 0;
        }


        public bool test()
        {
            try
            {
                Console.WriteLine("comboBox_TestItem: " + comboBox_TestItem.SelectedItem.ToString());
                //Item itm = (Item)comboBox_TestItem.SelectedItem;
                string MainSettingPath = Application.StartupPath + "\\Config.ini";
                ini12.INIWrite(MainSettingPath, "Schedule1", "Path", TestCaseDic[(string)comboBox_TestItem.SelectedItem].ToString());
                ini12.INIWrite(MainSettingPath, "Schedule1", "Exist", "1");
                return true;
            }
            catch (Exception ie)
            {
                return false;
            }

        }
        public void comboBox_TestItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("value: " + TestCaseDic[(string)comboBox_TestItem.SelectedItem]);
            if (dataGridView_Report.Rows.Count > 1)
            {
                bool isSame = false;
                for (int i = 0; i < dataGridView_Report.Rows.Count - 1; i++)
                {
                    dataGridViewList.Add(dataGridView_Report.Rows[i].Cells[0].Value.ToString());

                    foreach (string selectItem in dataGridViewList)
                    {
                        if (selectItem == comboBox_TestItem.SelectedItem.ToString())
                        {
                            isSame = true;
                            if (dataGridView_Report.Rows[comboBox_TestItem.SelectedIndex].Cells[2].Value != null)
                            {
                                textBox_Comment.Text = dataGridView_Report.Rows[comboBox_TestItem.SelectedIndex].Cells[2].Value.ToString();
                            }
                            break;
                        }
                    }
                }
                Console.WriteLine("isSame: " + isSame);
                if (isSame == false)
                {
                    Console.WriteLine("~~~~~~~~~~");
                    dataGridView_Report.Rows.Add(comboBox_TestItem.SelectedItem.ToString());
                    textBox_Comment.Clear();
                }
            }
            else
            {
                Console.WriteLine("+++++++");
                dataGridView_Report.Rows.Add(comboBox_TestItem.SelectedItem.ToString());
            }

            GridUI(comboBox_TestItem.SelectedIndex.ToString(), dataGridView_Report);

        }

        public void button_Run_Click(object sender, EventArgs e)
        {

            Global.Schedule_Loop = 1;
            Form1 lForm1 = (Form1)this.Owner;
            if (comboBox_TestItem.SelectedItem.ToString() != null)
            {
                lForm1.Autocommand_BlueRat("Form1", "TV");
                lForm1.RedRatDBViewer_Delay(3000);
                lForm1.button_Start.PerformClick();
            }
            else
            {
                MessageBox.Show("Please press button NEXT to start the test.");
            }
        }


        private void FormReleaseTest_Shown(object sender, EventArgs e)
        {
            Global.FormReleaseTest = true;
        }

        private void FormReleaseTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.FormReleaseTest = false;
        }

        private void button_Pass_Click(object sender, EventArgs e)
        {
            dataGridView_Report.Rows[comboBox_TestItem.SelectedIndex].Cells[1].Value = "PASS";
        }

        private void button_Fail_Click(object sender, EventArgs e)
        {
            dataGridView_Report.Rows[comboBox_TestItem.SelectedIndex].Cells[1].Value = "FAIL";
        }

        private void button_None_Click(object sender, EventArgs e)
        {
            dataGridView_Report.Rows[comboBox_TestItem.SelectedIndex].Cells[1].Value = "NONE";
        }
        private void FormReleaseTest_Load(object sender, EventArgs e)
        {
            button_Last.Enabled = false;
        }

        private void button_Generate_Click(object sender, EventArgs e)
        {
            ExcelWorksheet workSheet;
            using (var p = new ExcelPackage())
            {
                workSheet = p.Workbook.Worksheets.Add("Release report");

                //Format for all cells (border & font)
                int rowCount = dataGridView_Report.Rows.Count + 1;
                string rangeAll = "B2:D" + rowCount;
                Console.WriteLine("rangeAll: " + rangeAll);
                Console.WriteLine("dataGridView_Report.Rows.Count: " + dataGridView_Report.Rows.Count);
                workSheet.Cells[rangeAll].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[rangeAll].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[rangeAll].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[rangeAll].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells.Style.Font.Size = 12;

                //Header format
                workSheet.Row(2).Height = 31;
                workSheet.Row(2).Style.Font.Bold = true;
                workSheet.Row(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(2).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                workSheet.Cells["B2:D2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["B2:D2"].Style.Fill.BackgroundColor.SetColor(Color.CadetBlue);

                //Test case header
                workSheet.Cells[2, 2].Value = dataGridView_Report.Columns[0].HeaderText;
                workSheet.Column(2).Width = 40;

                //Result header
                workSheet.Cells[2, 3].Value = dataGridView_Report.Columns[1].HeaderText;
                workSheet.Column(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Column(3).Width = 20;

                //Comment header
                workSheet.Cells[2, 4].Value = dataGridView_Report.Columns[2].HeaderText; ;
                workSheet.Column(4).Width = 85;

                for (int i = 0; i < dataGridView_Report.Rows.Count - 1; i++)
                {
                    //Test case column
                    workSheet.Cells[i + 3, 2].Value = dataGridView_Report.Rows[i].Cells[0].Value;
                    workSheet.Cells[i + 3, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[i + 3, 2].Style.Fill.BackgroundColor.SetColor(Color.AliceBlue);

                    //Result column
                    if (dataGridView_Report.Rows[i].Cells[1].Value != null && dataGridView_Report.Rows[i].Cells[2].Value !=null)
                    {
                        workSheet.Cells[i + 3, 3].Value = dataGridView_Report.Rows[i].Cells[1].Value;
                        if (workSheet.Cells[i + 3, 3].Value.ToString() == "PASS")
                        {
                            workSheet.Cells[i + 3, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            workSheet.Cells[i + 3, 3].Style.Fill.BackgroundColor.SetColor(Color.LawnGreen);
                        }

                    else if (workSheet.Cells[i + 3, 3].Value.ToString() == "FAIL")
                    {
                        workSheet.Cells[i + 3, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        workSheet.Cells[i + 3, 3].Style.Fill.BackgroundColor.SetColor(Color.Red);
                    }
                    else if (workSheet.Cells[i + 3, 3].Value.ToString() == "NONE")
                    {
                        workSheet.Cells[i + 3, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        workSheet.Cells[i + 3, 3].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    }

                    //Comment column
                    workSheet.Cells[i + 3, 4].Value = dataGridView_Report.Rows[i].Cells[2].Value;
                    }
                }

                //Auto fit column for all cells
                //workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns(); 

                string fileName = string.Format("{0}", "Release_Test_" + DateTime.Now.ToString("yyyyMMddHHmmss"));
                p.SaveAs(new FileInfo(@"D:\Desktop\" + fileName + ".xlsx"));

                p.Dispose();
                workSheet = null;

                MessageBox.Show("Report is generated on Desktop.");
            }
        }

        //DataGridView highlight
        private delegate void UpdateUICallBack1(string value, DataGridView ctl);
        private void GridUI(string i, DataGridView gv)
        {
            if (InvokeRequired)
            {
                UpdateUICallBack1 uu = new UpdateUICallBack1(GridUI);
                if (int.Parse(i) > 1)
                {
                    Invoke(uu, i, gv);
                }
            }
            else
            {
                dataGridView_Report.ClearSelection();
                gv.Rows[int.Parse(i)].Selected = true;
            }
        }

        private void textBox_Comment_TextChanged(object sender, EventArgs e)
        {
            dataGridView_Report.Rows[comboBox_TestItem.SelectedIndex].Cells[2].Value = textBox_Comment.Text;
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            if (comboBox_TestItem.SelectedIndex < comboBox_TestItem.Items.Count - 1)
            {
                button_Next.Enabled = true;
                button_Last.Enabled = true;
                comboBox_TestItem.SelectedIndex = comboBox_TestItem.SelectedIndex + 1;
            }
            else
            {
                button_Next.Enabled = false;
                MessageBox.Show("This is the last test case.");
            }
        }

        private void button_Last_Click(object sender, EventArgs e)
        {
            if (comboBox_TestItem.SelectedIndex > 0)
            {
                button_Next.Enabled = true;
                comboBox_TestItem.SelectedIndex = comboBox_TestItem.SelectedIndex - 1;
            }
        }
    }
}
