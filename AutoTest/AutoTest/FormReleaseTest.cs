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
        static string testCaseDicPath = Application.StartupPath + "\\TestCase.ini";
        Dictionary<string, string> testCaseDic = new Dictionary<string, string>();
        List<string> dataGridViewList = new List<string>();

        private void CreateDictionary()
        {
            StreamReader str = new StreamReader(testCaseDicPath);
            string item = string.Empty;
            while ((item = str.ReadLine()) != null)
            {
                if (item.Length > 0 && item.Contains("=") == true)
                {
                    testCaseDic.Add(item.Substring(0, item.IndexOf("=")).Trim(), Application.StartupPath + "\\TestCase\\" + item.Substring(item.IndexOf("=") + 1, item.Length - (item.IndexOf("=") + 1)).Trim());
                }
            }
            str.Close();
        }


        private void CreateTestCaseIni()
        {
            INIFile inif = new INIFile(testCaseDicPath);
            inif.Write("Release Test", "eUM", "eUM.csv");
            inif.Write("Release Test", "Power_ON", "Power_ON.csv");
            inif.Write("Release Test", "Power_OFF", "Power_OFF.csv");
            inif.Write("Release Test", "Reinstall_EU(skip satellite)", "Reinstall_EU(skip satellite).csv");
            inif.Write("Release Test", "RC", "RC.csv");
            inif.Write("Release Test", "Volume", "Volume.csv");
            inif.Write("Release Test", "DVB-T_Installation", "DVB-T_Installation.csv");
            inif.Write("Release Test", "DVB-C_Installation", "DVB-C_Installation.csv");
            inif.Write("Release Test", "HDD_Format", "HDD_Format.csv");
            inif.Write("Release Test", "Time_Shift", "Time_Shift.csv");
            inif.Write("Release Test", "Recording", "Recording.csv");
            inif.Write("Release Test", "EPG", "EPG.csv");
            inif.Write("Release Test", "USB", "USB.csv");
            inif.Write("Release Test", "HDMI1", "HDMI1.csv");
            inif.Write("Release Test", "HDMI2", "HDMI2.csv");
            inif.Write("Release Test", "HDMI3", "HDMI3.csv");
            inif.Write("Release Test", "YPbPr", "YPbPr.csv");
            inif.Write("Release Test", "CVBS", "CVBS.csv");
            inif.Write("Release Test", "Wireless", "Wireless.csv");
            inif.Write("Release Test", "SMTV", "SMTV.csv");
            inif.Write("Release Test", "Netflix", "Netflix.csv");
            inif.Write("Release Test", "YouTube", "YouTube.csv");
        }

        public FormReleaseTest()
        {
            InitializeComponent();
            this.FormClosed += FormReleaseTest_FormClosed;
            if (System.IO.File.Exists(testCaseDicPath)) {
                CreateDictionary();
            }
            else
            {
                CreateTestCaseIni();
            }
            foreach (string key in testCaseDic.Keys)
            {
                comboBox_TestItem.Items.Add(key);
            }
        }


        public bool ReleaseTestSchChange()
        {
                if (File.Exists(testCaseDic[(string)comboBox_TestItem.SelectedItem].ToString()) == true)
                {

                Console.WriteLine("comboBox_TestItem: " + comboBox_TestItem.SelectedItem.ToString());
                ini12.INIWrite(Global.MainSettingPath, "Schedule1", "Path", testCaseDic[(string)comboBox_TestItem.SelectedItem].ToString());
                ini12.INIWrite(Global.MainSettingPath, "Schedule1", "Exist", "1");
                return true;
                }
                else
                {
                    MessageBox.Show("CSV file not found or CSV file name does not match with TestCase.ini.", "Error");
                    return false;
                }
        }


        public void comboBox_TestItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("value: " + testCaseDic[(string)comboBox_TestItem.SelectedItem]);
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

            GridUI(comboBox_TestItem.SelectedIndex.ToString(), dataGridView_Report); //Datagridview highlight
            Gridscroll(comboBox_TestItem.SelectedIndex.ToString(), dataGridView_Report);//Datagridview scollbar move when highlight change

        }


        public void button_Run_Click(object sender, EventArgs e)
        {
            Global.Schedule_Loop = 1;
            Form1 lForm1 = (Form1)this.Owner;
            if (comboBox_TestItem.SelectedIndex != -1)
            {
                if (lForm1.StartButtonPressed == true) //STOP key is pressed
                {
                    button_Run.Text = "RUN";
                    lForm1.button_Start.PerformClick();
                    button_Next.Enabled = true;
                }
                else //START key is pressed
                {
                    button_Run.Text = "STOP";
                    lForm1.Autocommand_BlueRat("Form1", "TV");
                    lForm1.RedRatDBViewer_Delay(2000);
                    lForm1.button_Start.PerformClick();
                    button_Last.Enabled = false;
                    button_Next.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please press button NEXT to start the test.", "Error");
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
            dataGridView_Report.Rows[comboBox_TestItem.SelectedIndex].Cells[1].Style.BackColor = Color.LightGray;
        }
        private void FormReleaseTest_Load(object sender, EventArgs e)
        {
            button_Last.Enabled = false;
        }

        //Generate report
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

                //Format for headers
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
                    if (dataGridView_Report.Rows[i].Cells[1].Value == null)
                    {
                        workSheet.Cells[i + 3, 3].Value = " ";
                    }
                    else
                    {
                        workSheet.Cells[i + 3, 3].Value = dataGridView_Report.Rows[i].Cells[1].Value;
                        if (workSheet.Cells[i + 3, 3].Value.ToString() == "PASS")
                        {
                            workSheet.Cells[i + 3, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            workSheet.Cells[i + 3, 3].Style.Fill.BackgroundColor.SetColor(Color.Green);
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
                    }

                    //Comment column
                    if (dataGridView_Report.Rows[i].Cells[2].Value == null)
                    {
                        workSheet.Cells[i + 3, 4].Value = " ";
                    }
                    else
                    {
                        workSheet.Cells[i + 3, 4].Value = dataGridView_Report.Rows[i].Cells[2].Value;
                    }
                }

                //Auto fit column for all cells
                //workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns(); 

                string fileName = string.Format("{0}", "Release_Test_" + DateTime.Now.ToString("yyyyMMddHHmmss"));
                p.SaveAs(new FileInfo(@"D:\Desktop\" + fileName + ".xlsx"));

                p.Dispose();
                workSheet = null;

                MessageBox.Show("Report is generated on Desktop.", "Message");
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

        //Scrolling when Datagridview highlight change
        private delegate void UpdateUICallBack3(string value, DataGridView ctl);
        private void Gridscroll(string i, DataGridView gv)
        {
            if (InvokeRequired)
            {
                UpdateUICallBack3 uu = new UpdateUICallBack3(Gridscroll);
                Invoke(uu, i, gv);
            }
            else
            {
                gv.FirstDisplayedScrollingRowIndex = int.Parse(i);
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
                button_Run.Enabled = true;
            }
            else
            {
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
