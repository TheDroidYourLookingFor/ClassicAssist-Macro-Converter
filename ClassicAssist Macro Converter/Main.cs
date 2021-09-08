using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ClassicAssist_Macro_Converter
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public void OpenFile()
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "UOSteam Files (*.uos)|*.uos";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rtb_CurrentFile.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        public void SaveFile()
        {
            saveFileDialog1.Filter = "*.macro|*.macro";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, rtb_ModedFile.Text);
            }
        }

        public void ParseText()
        {
            rtb_ModedFile.Text = rtb_CurrentFile.Text.Replace("endif", "");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("endwhile", "");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("maxmana", "MaxMana()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("maxhits", "MaxHits()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("mana", "Mana()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("hits", "Hits()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("@", "");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("!", "");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("//", "#");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("stop", "Stop()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("grabitem", "GrabItem()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("fly", "Fly()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("land", "Land()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("bandageself", "BandageSelf()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("resync", "Resync()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("ping", "Ping()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("hotkeys", "Hotkeys()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("info", "Info()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("clearjournal", "ClearJournal()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("else\n", "else:\n");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("elseif", "elif");

            //FindObject
            Regex regex = new Regex("findobject '(.*)'", RegexOptions.IgnoreCase);
            string cleanString = regex.Replace(rtb_ModedFile.Text, "FindObject($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("playmacro (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "PlayMacro($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("messagebox (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "MessageBox($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("playsound (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "PlaySound($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("clearhands (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ClearHands($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("feed (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Feed($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("clickobject (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ClickObject($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("attack (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Attack($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("bandage (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Bandage($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("snapshot (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Snapshot($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("useobject (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "UseObject($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("setability (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "SetAbility($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("setability (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "SetAbility($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("findtype (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "FindType($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("usetype (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "UseType($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("movetype (.*) (.*) (.*) (.*) (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "MoveType($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("movetype (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "MoveType($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("equipitem (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "EquipItem($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("sysmsg (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "SysMsg($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("headmsg (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "HeadMsg($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("injournal (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "InJournal($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("autotargetobject (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "AutoTargetObject($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("waitfortarget (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "WaitForTarget($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("targettileoffset (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "TargetTileOffset($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("pause (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Pause($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("promptalias '(.*)'", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "PromptAlias('$1')");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("target (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Target($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("skill '(.*)' >", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Skill('$1') >");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("skill '(.*)' <", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Skill('$1') <");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("skill '(.*)' =", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Skill('$1') =");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("skill '(.*)' !", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Skill('$1') !");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("moveitem (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "MoveItem($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("waitforgump (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "WaitForGump($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("replygump (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ReplyGump($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("if (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "if $1:");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("cast '(.*)' '(.*)'", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Cast('$1', '$2')");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("cast '(.*)'", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Cast('$1')");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("buffexists (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "BuffExists($1)");
            rtb_ModedFile.Text = cleanString;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void parseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParseText();
        }

        private void btn_Parse_Click(object sender, EventArgs e)
        {
            ParseText();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
