using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyExploits;
using System.IO;
using System.Net;
using Microsoft.Win32;
using caciknv;
using caciknv.DiscordRpcDemo;
using System.Diagnostics;

namespace caciki25022022
{
    public partial class Form1 : Form
    {
        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;

        int Move;
        int Mouse_X;
        int Mouse_Y;

        Module module = new Module();
      

        WeAreDevs_API.ExploitAPI module1 = new WeAreDevs_API.ExploitAPI();
        public Form1()
        {
            InitializeComponent();
        }
        Form2 f2 = new Form2();
        

        
        

        private void atBtn_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked == false)
            {
                if (radioButton5.Checked == false)
                {
                    MessageBox.Show("Please select a api in options.","^-^",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }


            if (radioButton3.Checked)
            {
                module.LaunchExploit();
            }

            if (radioButton5.Checked)
            {
                module1.LaunchExploit();              
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                panel3.Visible = true;
            }

            else
            {
                panel3.Visible = false;
            }
        }

        WebClient wc = new WebClient();
        private string defPath = Application.StartupPath + "//Monaco//";

        private void addIntel(string label, string kind, string detail, string insertText)
        {
            string text = "\"" + label + "\"";
            string text2 = "\"" + kind + "\"";
            string text3 = "\"" + detail + "\"";
            string text4 = "\"" + insertText + "\"";
            webBrowser1.Document.InvokeScript("AddIntellisense", new object[]
            {
                label,
                kind,
                detail,
                insertText
            });
        }

        private void addGlobalF()
        {
            string[] array = File.ReadAllLines(this.defPath + "//globalf.txt");
            foreach (string text in array)
            {
                bool flag = text.Contains(':');
                if (flag)
                {
                    this.addIntel(text, "Function", text, text.Substring(1));
                }
                else
                {
                    this.addIntel(text, "Function", text, text);
                }
            }
        }

        private void addGlobalV()
        {
            foreach (string text in File.ReadLines(this.defPath + "//globalv.txt"))
            {
                this.addIntel(text, "Variable", text, text);
            }
        }

        private void addGlobalNS()
        {
            foreach (string text in File.ReadLines(this.defPath + "//globalns.txt"))
            {
                this.addIntel(text, "Class", text, text);
            }
        }

        private void addMath()
        {
            foreach (string text in File.ReadLines(this.defPath + "//classfunc.txt"))
            {
                this.addIntel(text, "Method", text, text);
            }
        }

        private void addBase()
        {
            foreach (string text in File.ReadLines(this.defPath + "//base.txt"))
            {
                this.addIntel(text, "Keyword", text, text);
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {


            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("949033095640776715", ref this.handlers, true, null);
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("949033095640776715", ref this.handlers, true, null);
            this.presence.details = "redzii#0016";
            this.presence.state = "--------------";
            this.presence.largeImageKey = "cklogo";
            this.presence.smallImageKey = "none";
            this.presence.largeImageText = "Cacik-V.2.0";

            DiscordRpc.UpdatePresence(ref this.presence);

            panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E1E1E");
            panel4.Visible = false;
            panel3.Visible = false;
            button10.Visible = false;
            fastColoredTextBox1.Visible = false;
            webBrowser1.Visible = false;
            checkBox2.Checked = true;
            radioButton3.Checked = true;
            radioButton7.Checked = true;

            WebClient wc = new WebClient();
            wc.Proxy = null;
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
                string friendlyName = AppDomain.CurrentDomain.FriendlyName;
                bool flag2 = registryKey.GetValue(friendlyName) == null;
                if (flag2)
                {
                    registryKey.SetValue(friendlyName, 11001, RegistryValueKind.DWord);
                }
                registryKey = null;
                friendlyName = null;
            }
            catch (Exception)
            {
            }
            webBrowser1.Url = new Uri(string.Format("file:///{0}/Monaco/Monaco.html", Directory.GetCurrentDirectory()));
            await Task.Delay(500);
            webBrowser1.Document.InvokeScript("SetTheme", new string[]
            {
                   "Dark" 
                   /*
                    There are 2 Themes Dark and Light
                   */
            });
            addBase();
            addMath();
            addGlobalNS();
            addGlobalV();
            addGlobalF();
            webBrowser1.Document.InvokeScript("SetText", new object[]
            {
                 "have fun ^-^"+"  "+"\ndiscord:redzii#0016"
            });
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult sr = MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sr == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();//Clear Items in the LuaScriptList
                Functions.PopulateListBox(listBox1, "./Scripts", "*.txt");
                Functions.PopulateListBox(listBox1, "./Scripts", "*.lua");
            }
            catch (Exception)
            {
                DialogResult ht = MessageBox.Show("Error !", "?!?!?!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                if (this.listBox1.SelectedIndex != -1)
                {
                    this.webBrowser1.Document.InvokeScript("SetText", new object[1]
                    {
          (object) System.IO.File.ReadAllText("scripts\\" + this.listBox1.SelectedItem.ToString())
                    });
                }
                else
                {
                    int num = (int)MessageBox.Show("Please select a script from the list before trying to loading it in tab.", "^-^");
                }
            }
            if (radioButton6.Checked)
            {
                fastColoredTextBox1.Text = File.ReadAllText($"./Scripts/{listBox1.SelectedItem}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                if (radioButton3.Checked)
                {
                    HtmlDocument document = webBrowser1.Document;
                    string scriptName = "GetText";
                    object[] args = new string[0];
                    object obj = document.InvokeScript(scriptName, args);
                    string script = obj.ToString();
                    module.ExecuteScript(script);
                }



                if (radioButton5.Checked)
                {
                    if (this.listBox1.SelectedIndex != -1)
                    {
                        HtmlDocument document = webBrowser1.Document;
                        string scriptName = "GetText";
                        object[] args = new string[0];
                        object obj = document.InvokeScript(scriptName, args);
                        string script = obj.ToString();
                        module1.SendLuaScript(script);
                    }
                }
                }

            if (radioButton6.Checked)
            {
                if (radioButton3.Checked)
                {
                    module.ExecuteScript(fastColoredTextBox1.Text);
                }

                if (radioButton5.Checked)
                {
                    module1.SendLuaScript(fastColoredTextBox1.Text);
                }
            }
            }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                if (Functions.openfiledialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {

                        string MainText = File.ReadAllText(Functions.openfiledialog.FileName);
                        webBrowser1.Document.InvokeScript("SetText", new object[]
                        {
                          MainText
                        });

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
            }
            /////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////
            if (radioButton6.Checked)
            {

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Txt/Lua Files(.txt; .lua)|*txt; *lua";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    openFileDialog1.Title = "Open";
                    fastColoredTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                HtmlDocument document = this.webBrowser1.Document;
                string scriptName = "GetText";
                object[] array = new string[0];
                object[] array2 = array;
                object[] args = array2;
                object obj = document.InvokeScript(scriptName, args);
                string text = obj.ToString();
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Lua Script (*.lua)|*.lua|Text File (*.txt)|*.txt";
                    saveFileDialog.Title = "your exploit name Save file.";
                    saveFileDialog.ShowDialog();
                    try
                    {
                        string fileName = saveFileDialog.FileName; string text2 = text;
                        string[] contents = new string[] { text2.ToString(), "" }; File.WriteAllLines(saveFileDialog.FileName, contents);
                    }
                    catch (Exception) { }
                }
            }
        
            //if (radioButton7.Checked)
            //{
            //    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //    saveFileDialog1.Filter = "Txt|*.txt";
            //    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            //    {
            //        using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
            //        using (StreamWriter sw = new StreamWriter(s))
            //        {
            //            sw.Write(webBrowser1.Text);
            //        }
            //    }
            //}
            if (radioButton6.Checked)
            {
                SaveFileDialog saveFileDialog2 = new SaveFileDialog();
                saveFileDialog2.Filter = "Lua Script (*.lua)|*.lua|Text File (*.txt)|*.txt";
                if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    using (Stream s = File.Open(saveFileDialog2.FileName, FileMode.CreateNew))
                    using (StreamWriter sw = new StreamWriter(s))
                    {
                        sw.Write(fastColoredTextBox1.Text);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult sr = MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sr == DialogResult.Yes)
            {
                if (radioButton6.Checked)
                {
                    fastColoredTextBox1.Clear();
                }
                if (radioButton7.Checked)
                {
                    webBrowser1.Document.InvokeScript("SetText", new object[]
            {
                ""
            });
                }
            }
            else
            {
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult sr = MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sr == DialogResult.Yes)
            {
                module.killRoblox();
            }
            else
            {
                return;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                fastColoredTextBox1.Visible = true;
            }
            else
            {
                fastColoredTextBox1.Visible = false;
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                webBrowser1.Visible = true;
            }
            else
            {
                webBrowser1.Visible = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                panel4.Visible = true;
                button10.Visible = true;
            }
            else
            {
                panel4.Visible = false;
                button10.Visible = false;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                this.TopMost = true;
                this.Show();    
            }
            else
            {
                this.TopMost = false;
                this.Show();
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            
            
            
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            
        }

        private void checkBox3_CheckedChanged_2(object sender, EventArgs e)
        {
            
            //if (checkBox4.Checked)
            //{
            //    this.handlers = default(DiscordRpc.EventHandlers);
            //    DiscordRpc.Initialize("949025350044745738", ref this.handlers, true, null);
            //    this.handlers = default(DiscordRpc.EventHandlers);
            //    DiscordRpc.Initialize("949025350044745738", ref this.handlers, true, null);
            //    this.presence.details = "Details RPC";
            //    this.presence.state = "State RPC";
            //    this.presence.largeImageKey = "logo";
            //    this.presence.smallImageKey = "logo";
            //    this.presence.largeImageText = "logo";
            //    DiscordRpc.UpdatePresence(ref this.presence);
            //}
            //else
            //{
            //    return;
            //}
        }

        private void checkBox3_CheckedChanged_3(object sender, EventArgs e)
        {
            
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                webBrowser1.Document.InvokeScript("SetTheme", new string[]
            {
                   "Light" 
                   /*
                    There are 2 Themes Dark and Light
                   */
            });
                // Button
                button1.ForeColor = Color.Teal;
                button2.ForeColor = Color.Teal;
                button4.ForeColor = Color.Teal;
                button5.ForeColor = Color.Teal;
                button6.ForeColor = Color.Teal;
                button8.ForeColor = Color.Teal;
                button9.ForeColor = Color.Teal;
                button10.ForeColor = Color.Teal;
                button10.BackColor = Color.White;
                atBtn.ForeColor = Color.Teal;
                // Button
                //
                // RadioB
                radioButton1.ForeColor = Color.Teal;
                radioButton2.ForeColor = Color.Teal;
                radioButton3.ForeColor = Color.Teal;
                radioButton5.ForeColor = Color.Teal;
                radioButton6.ForeColor = Color.Teal;
                radioButton7.ForeColor = Color.Teal;
                // RadioB
                //
                // Label
                label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1E1E1E");
                label2.ForeColor = Color.Teal;
                // Label
                //
                // CheckB
                checkBox4.ForeColor = Color.Teal;
                checkBox4.BackColor = Color.White;
                checkBox5.BackColor = Color.White;
                checkBox5.ForeColor = Color.Teal;
                checkBox1.ForeColor = Color.Teal;
                checkBox2.ForeColor = Color.Teal;
                checkBox3.ForeColor = Color.Teal;
                groupBox1.ForeColor = Color.Teal;
                groupBox2.ForeColor = Color.Teal;
                groupBox3.ForeColor = Color.Teal;
                groupBox4.ForeColor = Color.Teal;
                checkBox1.BackColor = Color.White;
                
                // CheckB
                //
                // Panel
                panel5.BackColor = Color.White;
                panel1.BackColor = Color.White;
                panel2.BackColor = Color.White;
                panel6.ForeColor = Color.Teal;
                panel6.BackColor = Color.White;
                panel3.BackColor = Color.White;
                // Panel
                //
                // Fast
                fastColoredTextBox1.BackColor = Color.White;
                fastColoredTextBox1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1E1E1E");
                fastColoredTextBox1.LineNumberColor = Color.Teal;
                fastColoredTextBox1.IndentBackColor = Color.White;
                // Fast
                //
                // VisualTab
                visualStudioTabControl1.HeaderColor = Color.Teal;
                visualStudioTabControl1.ActiveColor = Color.Teal;
                visualStudioTabControl1.HeaderColor = Color.Teal;
                visualStudioTabControl1.BackTabColor = Color.White;
                // VisualTab
                listBox1.ForeColor = Color.Teal;
                listBox1.BackColor = Color.White;
            }
            else
            {
                webBrowser1.Document.InvokeScript("SetTheme", new string[]
            {
                   "Dark" 
                   /*
                    There are 2 Themes Dark and Light
                   */
            });
                // Button
                button1.ForeColor = Color.Firebrick;
                button2.ForeColor = Color.Firebrick;
                button4.ForeColor = Color.Firebrick;
                button5.ForeColor = Color.Firebrick;
                button6.ForeColor = Color.Firebrick;
                button8.ForeColor = Color.Firebrick;
                button9.ForeColor = Color.Firebrick;
                button10.ForeColor = Color.Firebrick;
                button10.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E1E1E");
                atBtn.ForeColor = Color.Firebrick;
                // Button
                //
                // RadioB
                radioButton1.ForeColor = Color.Firebrick;
                radioButton2.ForeColor = Color.Firebrick;
                radioButton3.ForeColor = Color.Firebrick;
                radioButton5.ForeColor = Color.Firebrick;
                radioButton6.ForeColor = Color.Firebrick;
                radioButton7.ForeColor = Color.Firebrick;
                // RadioB
                //
                // Label
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.Firebrick;
                // Label
                //
                // CheckBox
                checkBox1.BackColor = Color.Transparent;
                checkBox4.BackColor = Color.Transparent;
                checkBox5.BackColor = Color.Transparent;
                checkBox4.ForeColor = Color.Firebrick;
                checkBox5.ForeColor = Color.Firebrick;
                checkBox1.ForeColor = Color.Firebrick;
                checkBox2.ForeColor = Color.Firebrick;
                checkBox3.ForeColor = Color.Firebrick;
                // CheckBox
                //
                // Panel
                panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E1E1E");
                panel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E1E1E");
                panel3.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E1E1E");
                panel6.ForeColor = Color.Firebrick;
                panel6.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E1E1E");//30;30;30
                panel5.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E1E1E");
                // Panel
                //
                // Fast
                fastColoredTextBox1.IndentBackColor = System.Drawing.ColorTranslator.FromHtml("#1E1E1E");
                fastColoredTextBox1.LineNumberColor = System.Drawing.ColorTranslator.FromHtml("#404040");//dim mi neydi              
                fastColoredTextBox1.ForeColor = Color.White;
                fastColoredTextBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E1E1E");
                // Fast
                //
                // GroupB
                groupBox1.ForeColor = Color.Firebrick;
                groupBox2.ForeColor = Color.Firebrick;
                groupBox3.ForeColor = Color.Firebrick;
                groupBox4.ForeColor = Color.Firebrick;
                // GroupB
                //
                // VisualTab
                visualStudioTabControl1.BackTabColor = System.Drawing.ColorTranslator.FromHtml("#1E1E1E");
                visualStudioTabControl1.HeaderColor = Color.Firebrick;
                visualStudioTabControl1.ActiveColor = Color.Firebrick;
                // VisualTab
                listBox1.ForeColor = Color.Firebrick;
                listBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E1E1E");
            }
            
        }

        private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                Process.Start("RBXFIXER_v2.exe");
            }
            else
            {
                foreach (var process in Process.GetProcessesByName("RBXFIXER_v2"))
                {
                    process.Kill();
                }
            }   
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                System.Diagnostics.Process.Start("rbxfpsunlocker.exe");
            }
            else
            {
                foreach (var process in Process.GetProcessesByName("rbxfpsunlocker"))
                {
                    process.Kill();
                }
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
