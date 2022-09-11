using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

using System.Windows.Forms;

namespace Motorola_unbrick_tool2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public void cmdcall(string Commands)
        {
            this.progressBar1.MarqueeAnimationSpeed = 30;
            this.progressBar1.Style = ProgressBarStyle.Marquee;
            txtlog.AppendText("=================Waiting for Device======================" + Environment.NewLine);
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "cmd.exe"; // Passing main function to cmd.exe
            p.StartInfo.Arguments = "/c " + Commands; // Commands string passed here. /c argument is used to passed parameters explicitly.
            p.OutputDataReceived += new DataReceivedEventHandler(romprovider);
            p.ErrorDataReceived += new DataReceivedEventHandler(romprovider);
            p.Start();
            p.BeginOutputReadLine();
            while (!p.HasExited)
            {
                Application.DoEvents();

            }
            this.progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Value = 100;
        }

        /// <summary>
        /// This is a function through which we pass the commands the cmd.exe explicitly for running various task.
        /// Usage:- run_process(@"adb.exe reboot recovery");
        /// </summary>
        /// <param name="Commands"></param>
        public void cmdrun(string Commands)
        {
            this.progressBar1.MarqueeAnimationSpeed = 30;
            this.progressBar1.Style = ProgressBarStyle.Marquee;
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "mt/mtk.exe"; // Passing main function to cmd.exe
            p.StartInfo.Arguments = "/c " + Commands; // Commands string passed here. /c argument is used to passed parameters explicitly.
            p.OutputDataReceived += new DataReceivedEventHandler(romprovider2);
            p.Start();
            p.BeginOutputReadLine();
            while (!p.HasExited)
            {
                Application.DoEvents();

            }
            this.progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Value = 100;
        }

        /// <summary>
        /// This is for Normal Reboot button will Restart your device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void romprovider(object sender, DataReceivedEventArgs e)
        {
            string receivedMessage = e.Data + Environment.NewLine;
            if (!string.IsNullOrEmpty(receivedMessage))
            {
                string str = null;
                str = e.Data;
                str = e.Data + null;
                if (str.Contains("< waiting for device >") == true)
                {
                    this.SendLog("< waiting for device >", new Color?(Color.Indigo));
                }
                if (str.Contains("Opening device:") == true)
                {
                    this.SendLog(str, new Color?(Color.Indigo));
                }
                if (str.Contains("Detecting device") == true)
                {
                    this.SendLog("Detecting device", new Color?(Color.Indigo));
                }
                if (str.Contains("...cpu.id") == true)
                {
                    this.SendLog(str, new Color?(Color.DarkGreen));
                }
                if (str.Contains("...cpu.sn") == true)
                {
                    this.SendLog(str, new Color?(Color.DarkGreen));
                }
                if (str.Contains("Loading package") == true)
                {
                    this.SendLog("Loading package", new Color?(Color.Indigo));
                }
                if (str.Contains("Loading programmer") == true)
                {
                    this.SendLog("Loading programmer", new Color?(Color.Indigo));
                }
                if (str.Contains("Sending programmer") == true)
                {
                    this.SendLog("Sending programmer", new Color?(Color.Indigo));
                }
                if (str.Contains("Identifying CPU version") == true)
                {
                    this.SendLog("Identifying CPU version", new Color?(Color.Indigo));
                }
                if (str.Contains("Waiting for firehose to get ready") == true)
                {
                    this.SendLog("Waiting for firehose to get ready", new Color?(Color.Indigo));
                }
                if (str.Contains("unknown") == true)
                {
                    this.SendLog(str, new Color?(Color.DarkGreen));
                }
                if (str.Contains("...secure =") == true)
                {
                    this.SendLog(str, new Color?(Color.Indigo));
                }
                if (str.Contains("Configuring device...") == true)
                {
                    this.SendLog("Configuring device...", new Color?(Color.DarkRed));
                }
                if (str.Contains("Flashing") == true)
                {
                    this.SendLog(str, new Color?(Color.Magenta));
                }
                if (str.Contains("ERROR:") == true)
                {
                    this.SendLog(str, new Color?(Color.DarkViolet));
                }
                if (str.Contains("FAILED:") == true)
                {
                    this.SendLog(str, new Color?(Color.Red));
                }
                if (str.Contains("backup") == true)
                {
                    this.SendLog(str, new Color?(Color.Green));
                }
                if (str.Contains("restore") == true)
                {
                    this.SendLog(str, new Color?(Color.Green));
                }
                if (str.Contains("reboot") == true)
                {
                    this.SendLog(str, new Color?(Color.Green));
                }
                if (str.Contains("rebooting") == true)
                {
                    this.SendLog(str, new Color?(Color.Green));
                }
                if (str.Contains("Doing") == true)
                {
                    this.SendLog(str, new Color?(Color.Green));
                }
                if (str.Contains("WRITE") == true)
                {
                    this.SendLog(str, new Color?(Color.Indigo));
                }
                if (str.Contains("Please") == true)
                {
                    this.SendLog(str, new Color?(Color.Indigo));
                }
                if (str.Contains("Success!") == true)
                {
                    this.SendLog(str, new Color?(Color.Green));
                }
                if (str.Contains("success!") == true)
                {
                    this.SendLog(str, new Color?(Color.Green));
                }
                if (str.Contains("success") == true)
                {
                    this.SendLog(str, new Color?(Color.Green));
                }
                if (str.Contains("Success") == true)
                {
                    this.SendLog(str, new Color?(Color.Green));
                }
                if (str.Contains("remove") == true)
                {
                    this.SendLog(str, new Color?(Color.DarkViolet));
                }
                if (str.Contains("DoWatchDogReset<>:") == true)
                {
                    this.SendLog(str, new Color?(Color.Cyan));
                }
            }
            else
            {

            }
            RichTextBox.CheckForIllegalCrossThreadCalls = false;
        }

        void romprovider2(object sender, DataReceivedEventArgs e)
        {
            string receivedMessage = e.Data + Environment.NewLine;
            if (!string.IsNullOrEmpty(receivedMessage))
            {
                txtlog.ScrollToCaret();
                string str = null;
                str = e.Data;
                str = e.Data + null;
                if (str.Contains("Invalid parameter.") == true)
                {
                    this.SendLog(str, new Color?(Color.Purple));
                }
                if (str.Contains("Build Time:") == true)
                {
                    this.SendLog("Executing Flash", new Color?(Color.Indigo));
                }
                if (str.Contains("LoadDA") == true)
                {
                    this.SendLog("Loading DA: ", breakline: false);
                    this.SendLog("OK", new Color?(Color.Indigo));
                }
                if (str.Contains("LoadScatterFile") == true)
                {
                    this.SendLog("Loading Scatter File: ", breakline: false);
                    this.SendLog("OK", new Color?(Color.Maroon));
                }
                if (str.Contains("auto load all roms") == true)
                {
                    this.SendLog("Loading ROM Files: ", breakline: false);
                    this.SendLog("OK", new Color?(Color.OrangeRed));
                }
                if (str.Contains("timeout set as 120000 ms") == true)
                {
                    this.SendLog("Waiting for USB Device==========================================");
                }
                if (str.Contains("BROM connected") == true)
                {
                    this.SendLog("Device Detected: Processing Flash==============================", new Color?(Color.Red));
                }
                if (str.Contains("Download DA") == true)
                {
                    this.SendLog("Downloading DA: ", breakline: false);
                }
                if (str.Contains("100% of DA has been sent") == true)
                {
                    this.SendLog("100% Flashed", new Color?(Color.Maroon));
                }
                if (str.Contains("Downloading bootloader...") == true)
                {
                    this.SendLog("Downloading bootloader: ", breakline: false);
                }
                if (str.Contains("100% of bootloader has been sent") == true)
                {
                    this.SendLog("100% Flashed", new Color?(Color.Maroon));
                }
                if (str.Contains("Downloading images...") == true)
                {
                    this.SendLog("Flashing Images==========================================", new Color?(Color.Purple));
                }
                if (str.Contains("12%") == true)
                {
                    this.SendLog("12% Flashed", new Color?(Color.Brown));
                }
                if (str.Contains("18%") == true)
                {
                    this.SendLog("18% Flashed", new Color?(Color.Brown));
                }
                if (str.Contains("22%") == true)
                {
                    this.SendLog("22% Flashed", new Color?(Color.Brown));
                }
                if (str.Contains("28%") == true)
                {
                    this.SendLog("28% Flashed", new Color?(Color.Brown));
                }
                if (str.Contains("34%") == true)
                {
                    this.SendLog("34% Flashed", new Color?(Color.Brown));
                }
                if (str.Contains("42%") == true)
                {
                    this.SendLog("42% Flashed", new Color?(Color.Brown));
                }
                if (str.Contains("46%") == true)
                {
                    this.SendLog("46% Flashed", new Color?(Color.Brown));
                }
                if (str.Contains("52%") == true)
                {
                    this.SendLog("52% Flashed", new Color?(Color.DarkGreen));
                }
                if (str.Contains("56%") == true)
                {
                    this.SendLog("56% Flashed", new Color?(Color.DarkGreen));
                }
                if (str.Contains("64%") == true)
                {
                    this.SendLog("64% Flashed", new Color?(Color.DarkGreen));
                }
                if (str.Contains("74%") == true)
                {
                    this.SendLog("74% Flashed", new Color?(Color.DarkGreen));
                }
                if (str.Contains("82%") == true)
                {
                    this.SendLog("82% Flashed", new Color?(Color.DarkCyan));
                }
                if (str.Contains("92%") == true)
                {
                    this.SendLog("92% Flashed", new Color?(Color.DarkCyan));
                }
                if (str.Contains("98%") == true)
                {
                    this.SendLog("98% Flashed", new Color?(Color.DarkCyan));
                }
                if (str.Contains("Download Succeeded.") == true)
                {
                    this.SendLog("Done Flash Full Firmware via Fastboot Mod", new Color?(Color.Green));
                    this.SendLog("======================================================================================", new Color?(Color.Purple));
                }
                if (str.Contains("BROM failed:") == true)
                {
                    this.SendLog(str, new Color?(Color.Purple));
                }
                if (str.Contains("8038") == true)
                {
                    this.SendLog("Please use official Flash tool & Select Format all and Download", new Color?(Color.Purple));
                    this.SendLog(str, new Color?(Color.Purple));
                    this.SendLog("======================================================================================", new Color?(Color.Purple));
                }
                if (str.Contains("5069") == true)
                {
                    this.SendLog("Failed Size is Larger then Partition", new Color?(Color.Purple));
                    this.SendLog("Please use official Flash tool & Select Format all and Download", new Color?(Color.Purple));
                    this.SendLog(str, new Color?(Color.Purple));
                }
                if (str.Contains("Download failed.") == true)
                {
                    this.SendLog("Download Failed", new Color?(Color.Purple));
                    this.SendLog(str, new Color?(Color.Purple));
                }
                if (str.Contains("S_UNSUPPORTED_VER_OF_DA") == true)
                {
                    this.SendLog("UNSUPPORTED VER OF DA", new Color?(Color.Purple));
                    this.SendLog(str, new Color?(Color.Purple));
                }
                if (str.Contains("Error:") == true)
                {
                    this.SendLog(str, new Color?(Color.Purple));
                    this.SendLog("======================================================================================", new Color?(Color.Purple));
                }
                if (str.Contains("Disconnect!") == true)
                {
                    this.SendLog(str, new Color?(Color.Purple));
                    this.SendLog("======================================================================================", new Color?(Color.Purple));
                }
                if (str.Contains("Scatter file which is loaded has been phased out!") == true)
                {
                    this.SendLog("UNSupported Platform Please use SP Flash 5.19 or Lower", new Color?(Color.Red));
                }
                if (str.Contains("STATUS_DA_HASH_MISMATCH") == true)
                {
                    this.SendLog("Err DA hash Mismatch", new Color?(Color.Purple));
                    this.SendLog(str, new Color?(Color.Purple));
                }
                if (str.Contains("Scatter file which is loaded is not be supported!") == true)
                {
                    this.SendLog(str, new Color?(Color.Purple));
                    this.SendLog("======================================================================================", new Color?(Color.Purple));
                }
                if (str.Contains("failed:") == true)
                {
                    this.SendLog(str, new Color?(Color.Purple));
                    this.SendLog("======================================================================================", new Color?(Color.Purple));
                }
            }
            else
            {

            }
            RichTextBox.CheckForIllegalCrossThreadCalls = false;
        }

        //Delegate representing the method in which you set text to a RichTextBox
        delegate void CallBackRichTextBox(RichTextBox rtf, string text);
        //The method in which you set text to a RichTextBox
        private void SetTextToRichTextBox(RichTextBox rtf, string text)
        {
            try
            {
                if (rtf.InvokeRequired)
                {
                    CallBackRichTextBox d = new CallBackRichTextBox(SetTextToRichTextBox);
                    this.Invoke(d, new object[] { rtf, text });
                }
                else
                {
                    rtf.Text = rtf.Text + text;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            RichTextBox.CheckForIllegalCrossThreadCalls = false;
        }
        private void SendLog(string text, Color? color = null, bool time = true, bool breakline = true)
        {
            if (txtlog.InvokeRequired)
            {
                txtlog.BeginInvoke((Action)(() =>
                {
                    if (string.IsNullOrEmpty(text))
                    {
                        txtlog.AppendText("\r\n");
                    }
                    else
                    {
                        if (time)
                            txtlog.SelectionStart = txtlog.TextLength;
                        txtlog.SelectionLength = 0;
                        txtlog.SelectionColor = color ?? txtlog.ForeColor;
                        if (breakline)
                            txtlog.AppendText(text + "\r\n");
                        else
                            txtlog.AppendText(text);
                        txtlog.SelectionColor = txtlog.ForeColor;
                    }
                    txtlog.ScrollToCaret();
                }));
            }
            else
            {
                if (string.IsNullOrEmpty(text))
                {
                    txtlog.AppendText("\r\n");
                }
                else
                {
                    if (time)
                        txtlog.SelectionStart = txtlog.TextLength;
                    txtlog.SelectionLength = 0;
                    txtlog.SelectionColor = color ?? txtlog.ForeColor;
                    if (breakline)
                        txtlog.AppendText(text + "\r\n");
                    else
                        txtlog.AppendText(text);
                }
                RichTextBox.CheckForIllegalCrossThreadCalls = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.comboBox1.DataSource = null;
            this.comboBox1.Items.Clear();
            if (!comboBox1.Items.Contains("item"))
            {
                comboBox1.Items.Add("G50 XT2137-2");
                comboBox1.Items.Add("G9 Power 2021");
                comboBox1.Items.Add("Defy 2021");
                comboBox1.Items.Add("Edge (2021) SD778");
                comboBox1.Items.Add("Edge 20 Lite");
                comboBox1.Items.Add("Edge 20 Pro XT2153-1");
                comboBox1.Items.Add("Edge 20");

                comboBox1.Items.Add("Edge 30");
                comboBox1.Items.Add("Edge 30 Pro");
                comboBox1.Items.Add("Edge 30 Plus");
                comboBox1.Items.Add("Edge Plus");
                comboBox1.Items.Add("Edge X30");
                comboBox1.Items.Add("Edge");
                comboBox1.Items.Add("G Pure");

                comboBox1.Items.Add("E 2020");
                comboBox1.Items.Add("Moto E5 Plus");
                comboBox1.Items.Add("E5 SD425");
                comboBox1.Items.Add("Moto E6");
                comboBox1.Items.Add("Moto E7 Plus");
                comboBox1.Items.Add("Moto G 5G");
                comboBox1.Items.Add("Moto G Play 2021");

                comboBox1.Items.Add("Moto G Power (2022)");
                comboBox1.Items.Add("G Power 2021");
                comboBox1.Items.Add("G Stylus  VZW");
                comboBox1.Items.Add("G Stylus 5G");
                comboBox1.Items.Add("Moto G6 Play");
                comboBox1.Items.Add("Moto G6 Plus");
                comboBox1.Items.Add("Moto G6");

                comboBox1.Items.Add("G7 Play");
                comboBox1.Items.Add("G7 Plus");
                comboBox1.Items.Add("G7 Power");
                comboBox1.Items.Add("Moto G7");
                comboBox1.Items.Add("G8 Play");
                comboBox1.Items.Add("G8 Plus");
                comboBox1.Items.Add("G8 Power XT2041-7");

                comboBox1.Items.Add("Moto G8");
                comboBox1.Items.Add("G9 Play");
                comboBox1.Items.Add("G9 Plus");
                comboBox1.Items.Add("G9 Power");
                comboBox1.Items.Add("Moto G10");
                comboBox1.Items.Add("Moto G30");
                comboBox1.Items.Add("Moto G31");

                comboBox1.Items.Add("Moto G41");
                comboBox1.Items.Add("Moto G50 5G");
                comboBox1.Items.Add("Moto G50");
                comboBox1.Items.Add("G52  XT2221-1");
                comboBox1.Items.Add("G52 XT2221-2");
                comboBox1.Items.Add("Moto G60");
                comboBox1.Items.Add("Moto G71 5G");

                comboBox1.Items.Add("Moto G82");
                comboBox1.Items.Add("Moto G100");
                comboBox1.Items.Add("Moto G200 5G");
                comboBox1.Items.Add("One Power");
                comboBox1.Items.Add("One Zoom");
                comboBox1.Items.Add("Z3 Play");
                comboBox1.Items.Add("Moto Z4");

                comboBox1.Items.Add("One 5G ACE");
                comboBox1.Items.Add("One Action");
                comboBox1.Items.Add("One Fusion Plus");
                comboBox1.Items.Add("One Fusion");
                comboBox1.Items.Add("One Hyper");
                comboBox1.Items.Add("One Macro");
                comboBox1.Items.Add("One Vision");

                comboBox1.Items.Add("Motorola One");
                comboBox1.Items.Add("P30 Note");
                comboBox1.Items.Add("P30 Play");
                comboBox1.Items.Add("Razr 5G XT2071-5");
                comboBox1.Items.Add("Motorola Razr 2019");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "G50 XT2137-2")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\a.bin");
            }
            if (comboBox1.SelectedItem == "G9 Power 2021")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\1.bin");
            }
            if (comboBox1.SelectedItem == "Defy 2021")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\b.bin");
            }
            if (comboBox1.SelectedItem == "Edge (2021) SD778")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\2.bin");
            }
            if (comboBox1.SelectedItem == "Edge 20 Lite")
            {
                cmdrun(" -b -a moto\\edge20Lite\\auth_sv5.auth -d moto\\edge20Lite\\MTK_AllInOne_DA.bin -s moto\\edge20Lite\\scatter.txt -c firmware-upgrade");
            }
            if (comboBox1.SelectedItem == "Edge 20 Pro XT2153-1")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\3.bin");
            }
            if (comboBox1.SelectedItem == "Edge 20")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\4.bin");
            }
            if (comboBox1.SelectedItem == "Edge 30")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\5.bin");
            }
            if (comboBox1.SelectedItem == "Edge 30 Pro")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\6.bin");
            }
            if (comboBox1.SelectedItem == "Edge 30 Plus")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\7.bin");
            }
            if (comboBox1.SelectedItem == "Edge X30")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\8.bin");
            }
            if (comboBox1.SelectedItem == "Edge")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\9.bin");
            }
            if (comboBox1.SelectedItem == "G Pure")
            {
                cmdrun(" -b -a moto\\gpure\\auth_sv5.auth -d moto\\gpure\\MTK_AllInOne_DA.bin -s moto\\gpure\\scatter.txt -c firmware-upgrade");
            }
            if (comboBox1.SelectedItem == "E 2020")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\10.bin");
            }
            if (comboBox1.SelectedItem == "Moto E5 Plus")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\11.bin");
            }
            if (comboBox1.SelectedItem == "E5 SD425")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\12.bin");
            }
            if (comboBox1.SelectedItem == "Moto E6")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\13.bin");
            }
            if (comboBox1.SelectedItem == "Moto E7 Plus")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\14.bin");
            }
            if (comboBox1.SelectedItem == "Moto G 5G")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\15.bin");
            }
            if (comboBox1.SelectedItem == "Moto G Play 2021")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\16.bin");
            }
            if (comboBox1.SelectedItem == "Moto G Play 2021")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\16.bin");
            }
            if (comboBox1.SelectedItem == "Moto G Power (2022)")
            {
                cmdrun(" -b -a moto\\power2022\\auth_sv5.auth -d moto\\power2022\\MTK_AllInOne_DA.bin -s moto\\power2022\\scatter.txt -c firmware-upgrade");
            }
            if (comboBox1.SelectedItem == "G Power 2021")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\17.bin");
            }
            if (comboBox1.SelectedItem == "G Stylus  VZW")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\18.bin");
            }
            if (comboBox1.SelectedItem == "G Stylus 5G")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\19.bin");
            }
            if (comboBox1.SelectedItem == "G Stylus 5G")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\19.bin");
            }
            if (comboBox1.SelectedItem == "Moto G6 Play")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\20.bin");
            }
            if (comboBox1.SelectedItem == "Moto G6 Plus")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\21.bin");
            }
            if (comboBox1.SelectedItem == "Moto G6")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\22.bin");
            }
            if (comboBox1.SelectedItem == "G7 Play")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\23.bin");
            }
            if (comboBox1.SelectedItem == "G7 Plus")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\24.bin");
            }
            if (comboBox1.SelectedItem == "G7 Power")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\25.bin");
            }
            if (comboBox1.SelectedItem == "Moto G7")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\26.bin");
            }
            if (comboBox1.SelectedItem == "G8 Play")
            {
                cmdrun(" -b -a moto\\g8play\\auth_sv5.auth -d moto\\g8play\\MTK_AllInOne_DA.bin -s moto\\g8play\\scatter.txt -c firmware-upgrade");
            }
            if (comboBox1.SelectedItem == "G8 Plus")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\27.bin");
            }
            if (comboBox1.SelectedItem == "G8 Power XT2041-7")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\28.bin");
            }
            if (comboBox1.SelectedItem == "Moto G8")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\29.bin");
            }
            if (comboBox1.SelectedItem == "G9 Play")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\30.bin");
            }
            if (comboBox1.SelectedItem == "G9 Plus")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\31.bin");
            }
            if (comboBox1.SelectedItem == "G9 Power")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\32.bin");
            }
            if (comboBox1.SelectedItem == "Moto G10")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\33.bin");
            }
            if (comboBox1.SelectedItem == "Moto G30")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\34.bin");
            }
            if (comboBox1.SelectedItem == "Moto G31")
            {
                cmdrun(" -b -a moto\\G31\\auth_sv5.auth -d moto\\G31\\MTK_AllInOne_DA.bin -s moto\\G31\\scatter.txt -c firmware-upgrade");
            }
            if (comboBox1.SelectedItem == "Moto G41")
            {
                cmdrun(" -b -a moto\\G41\\auth_sv5.auth -d moto\\G41\\MTK_AllInOne_DA.bin -s moto\\G41\\scatter.txt -c firmware-upgrade");
            }
            if (comboBox1.SelectedItem == "Moto G50")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\35.bin");
            }
            if (comboBox1.SelectedItem == "Moto G50 5G")
            {
                cmdrun(" -b -a moto\\G505G\\auth_sv5.auth -d moto\\G505G\\MTK_AllInOne_DA.bin -s moto\\G505G\\scatter.txt -c firmware-upgrade");
            }
            if (comboBox1.SelectedItem == "G52  XT2221-1")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\36.bin");
            }
            if (comboBox1.SelectedItem == "G52 XT2221-2")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\39.bin");
            }
            if (comboBox1.SelectedItem == "Moto G60")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\40.bin");
            }
            if (comboBox1.SelectedItem == "Moto G71 5G")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\41.bin");
            }
            if (comboBox1.SelectedItem == "Moto G82")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\42.bin");
            }
            if (comboBox1.SelectedItem == "Moto G100")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\43.bin");
            }
            if (comboBox1.SelectedItem == "Moto G200 5G")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\44.bin");
            }
            if (comboBox1.SelectedItem == "One Power")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\45.bin");
            }
            if (comboBox1.SelectedItem == "One Zoom")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\46.bin");
            }
            if (comboBox1.SelectedItem == "Z3 Play")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\47.bin");
            }
            if (comboBox1.SelectedItem == "Moto Z4")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\48.bin");
            }
            if (comboBox1.SelectedItem == "One 5G ACE")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\49.bin");
            }
            if (comboBox1.SelectedItem == "One Fusion Plus")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\50.bin");
            }
            if (comboBox1.SelectedItem == "One Fusion")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\51.bin");
            }
            if (comboBox1.SelectedItem == "One Hyper")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\52.bin");
            }
            if (comboBox1.SelectedItem == "One Macro")
            {
                cmdrun(" -b -a moto\\macro\\auth_sv5.auth -d moto\\macro\\MTK_AllInOne_DA.bin -s moto\\macro\\scatter.txt -c firmware-upgrade");
            }
            if (comboBox1.SelectedItem == "P30 Note")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\53.bin");
            }
            if (comboBox1.SelectedItem == "P30 Play")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\54.bin");
            }
            if (comboBox1.SelectedItem == "Razr 5G XT2071-5")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\55.bin");
            }
            if (comboBox1.SelectedItem == "Motorola Razr 2019")
            {
                cmdcall("mt\\qboot.exe blank-flash moto\\56.bin");
            }
            if (comboBox1.SelectedItem == "One Vision")
            {
                txtlog.AppendText("Please load config from moto/oneAction folder");
                cmdcall("mt\\exynos.exe");
            }
            if (comboBox1.SelectedItem == "One Action")
            {
                txtlog.AppendText("Please load config from moto/oneAction folder");
                cmdcall("mt\\exynos.exe");

            }
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("https://paypal.me/rom2support");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/jeck24India/Motorola-unbrick-tool");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://romprovider.com/motorola-firmware");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("https://t.me/motoupdatestracker");
        }
    }
}
