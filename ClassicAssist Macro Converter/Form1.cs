using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ClassicAssist_Macro_Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "UOSteam Files (*.uos)|*.uos";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog1.FileName;
                //...
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "*.macro|*.macro";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox2.Text);
            }
        }

        private void parseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox1.Text.Replace("endif", "");
            richTextBox2.Text = richTextBox2.Text.Replace("endwhile", "");
            richTextBox2.Text = richTextBox2.Text.Replace("maxmana", "MaxMana()");
            richTextBox2.Text = richTextBox2.Text.Replace("maxhits", "MaxHits()");
            richTextBox2.Text = richTextBox2.Text.Replace("mana", "Mana()");
            richTextBox2.Text = richTextBox2.Text.Replace("hits", "Hits()");
            richTextBox2.Text = richTextBox2.Text.Replace("@", "");
            richTextBox2.Text = richTextBox2.Text.Replace("!", "");
            richTextBox2.Text = richTextBox2.Text.Replace("//", "#");
            richTextBox2.Text = richTextBox2.Text.Replace("stop", "Stop()");
            richTextBox2.Text = richTextBox2.Text.Replace("grabitem", "GrabItem()");
            richTextBox2.Text = richTextBox2.Text.Replace("fly", "Fly()");
            richTextBox2.Text = richTextBox2.Text.Replace("land", "Land()");
            richTextBox2.Text = richTextBox2.Text.Replace("bandageself", "BandageSelf()");
            richTextBox2.Text = richTextBox2.Text.Replace("resync", "Resync()");
            richTextBox2.Text = richTextBox2.Text.Replace("ping", "Ping()");
            richTextBox2.Text = richTextBox2.Text.Replace("hotkeys", "Hotkeys()");
            richTextBox2.Text = richTextBox2.Text.Replace("info", "Info()");
            richTextBox2.Text = richTextBox2.Text.Replace("clearjournal", "ClearJournal()");
            richTextBox2.Text = richTextBox2.Text.Replace("else\n", "else:\n");
            richTextBox2.Text = richTextBox2.Text.Replace("elseif", "elif");

            //FindObject
            Regex regex = new Regex("findobject '(.*)'", RegexOptions.IgnoreCase);
            string cleanString = regex.Replace(richTextBox2.Text, "FindObject($1)");
            richTextBox2.Text = cleanString;

            regex = new Regex("playmacro (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "PlayMacro($1)");
            richTextBox2.Text = cleanString;

            regex = new Regex("messagebox (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "MessageBox($1, $2)");
            richTextBox2.Text = cleanString;

            regex = new Regex("playsound (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "PlaySound($1)");
            richTextBox2.Text = cleanString;

            regex = new Regex("clearhands (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "ClearHands($1)");
            richTextBox2.Text = cleanString;

            regex = new Regex("feed (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "Feed($1)");
            richTextBox2.Text = cleanString;

            regex = new Regex("clickobject (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "ClickObject($1)");
            richTextBox2.Text = cleanString;

            regex = new Regex("attack (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "Attack($1)");
            richTextBox2.Text = cleanString;

            regex = new Regex("bandage (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "Bandage($1)");
            richTextBox2.Text = cleanString;

            regex = new Regex("snapshot (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "Snapshot($1)");
            richTextBox2.Text = cleanString;

            regex = new Regex("useobject (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "UseObject($1)");
            richTextBox2.Text = cleanString;

            regex = new Regex("setability (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "SetAbility($1, $2)");
            richTextBox2.Text = cleanString;

            regex = new Regex("setability (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "SetAbility($1)");
            richTextBox2.Text = cleanString;

            regex = new Regex("findtype (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "FindType($1, $2, $3)");
            richTextBox2.Text = cleanString;

            regex = new Regex("usetype (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "UseType($1, $2, $3)");
            richTextBox2.Text = cleanString;

            regex = new Regex("movetype (.*) (.*) (.*) (.*) (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "MoveType($1, $2, $3)");
            richTextBox2.Text = cleanString;

            regex = new Regex("movetype (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "MoveType($1, $2, $3)");
            richTextBox2.Text = cleanString;

            regex = new Regex("equipitem (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "EquipItem($1, $2)");
            richTextBox2.Text = cleanString;

            regex = new Regex("sysmsg (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "SysMsg($1, $2)");
            richTextBox2.Text = cleanString;

            regex = new Regex("headmsg (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "HeadMsg($1, $2)");
            richTextBox2.Text = cleanString;

            regex = new Regex("injournal (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "InJournal($1)");
            richTextBox2.Text = cleanString;

            regex = new Regex("autotargetobject (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "AutoTargetObject($1)");
            richTextBox2.Text = cleanString;

            regex = new Regex("waitfortarget (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "WaitForTarget($1)");
            richTextBox2.Text = cleanString;

            regex = new Regex("targettileoffset (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "TargetTileOffset($1, $2, $3)");
            richTextBox2.Text = cleanString;

            regex = new Regex("pause (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "Pause($1)");
            richTextBox2.Text = cleanString;

            regex = new Regex("promptalias '(.*)'", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "PromptAlias('$1')");
            richTextBox2.Text = cleanString;

            regex = new Regex("target (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "Target($1)");
            richTextBox2.Text = cleanString;

            regex = new Regex("skill '(.*)' >", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "Skill('$1') >");
            richTextBox2.Text = cleanString;

            regex = new Regex("skill '(.*)' <", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "Skill('$1') <");
            richTextBox2.Text = cleanString;

            regex = new Regex("skill '(.*)' =", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "Skill('$1') =");
            richTextBox2.Text = cleanString;

            regex = new Regex("skill '(.*)' !", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "Skill('$1') !");
            richTextBox2.Text = cleanString;

            regex = new Regex("moveitem (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "MoveItem($1, $2)");
            richTextBox2.Text = cleanString;

            regex = new Regex("waitforgump (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "WaitForGump($1, $2)");
            richTextBox2.Text = cleanString;

            regex = new Regex("replygump (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "ReplyGump($1, $2)");
            richTextBox2.Text = cleanString;

            regex = new Regex("if (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "if $1:");
            richTextBox2.Text = cleanString;

            regex = new Regex("cast '(.*)' '(.*)'", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "Cast('$1', '$2')");
            richTextBox2.Text = cleanString;

            regex = new Regex("cast '(.*)'", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "Cast('$1')");
            richTextBox2.Text = cleanString;

            regex = new Regex("buffexists (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(richTextBox2.Text, "BuffExists($1)");
            richTextBox2.Text = cleanString;
        }
    }
}
