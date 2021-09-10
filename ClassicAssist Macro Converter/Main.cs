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

        public void ReplaceTxt(string regx, string outputstr, RegexOptions regxopts, RichTextBox inputstr, RichTextBox outputrtb)
        {
            Regex regex = new Regex(regx, regxopts);
            string cleanString = regex.Replace(inputstr.Text, outputstr);
            outputrtb.Text = cleanString;
        }

        public void ParseText()
        {
            ReplaceTxt("@", "", RegexOptions.IgnoreCase, rtb_CurrentFile, rtb_ModedFile);
            ReplaceTxt("!\\s", " ", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("//", "#", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("stop", "Stop()", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("weight", "Weight()", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("direction", "Direction()", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("grabitem", "GrabItem()", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("guildbutton", "GuildButton()", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("helpbutton", "HelpButton()", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("logoutbutton", "LogoutButton()", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("questsbutton", "QuestsButton()", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("land", "Land()", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("cancelautotarget", "CancelAutoTarget()", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("canceltarget", "CancelTarget()", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("autoloot", "AutoLoot()", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("cancelprompt", "CancelPrompt()", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("autotargetlast", "AutoTargetLast()", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("bandageself", "BandageSelf()", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("autotargetself", "AutoTargetSelf()", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("resync", "Resync()", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("ping", "Ping()", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("clearignorelist", "ClearIgnoreList()", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("hotkeys", "Hotkeys()", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("info", "Info()", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("clearjournal", "ClearJournal()", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("else\n", "else:\n", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("elseif (.*)", "elif $1", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("elseif\n", "elif", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("endif", "", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("endwhile", "", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);

            //FindObject(serial, range, location)
            Regex regex = new Regex("findobject (.*) (.*) (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            string cleanString = regex.Replace(rtb_ModedFile.Text, "FindObject($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("findobject (.*) (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "FindObject($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("findobject (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "FindObject($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("findobject (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "FindObject($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("findobject (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "FindObject($1)");
            rtb_ModedFile.Text = cleanString;

            //FindType(graphic, range, location, hue, stackamount)
            regex = new Regex("findtype (.*) (.*) (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "FindType($1, $2, $3, $4, $5)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("findtype (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "FindType($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("findtype (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "FindType($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("findtype (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "FindType($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("findtype (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "FindType($1)");
            rtb_ModedFile.Text = cleanString;

            //CreateTimer(name)
            regex = new Regex("createtimer (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "CreateTimer($1)");
            rtb_ModedFile.Text = cleanString;

            //RemoveTimer(name)
            regex = new Regex("removetimer (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "RemoveTimer($1)");
            rtb_ModedFile.Text = cleanString;

            //SetTimer(name, milliseconds)
            regex = new Regex("settimer (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "SetTimer($1)");
            rtb_ModedFile.Text = cleanString;

            //TimerExists(name)
            regex = new Regex("timerexists (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "TimerExists($1)");
            rtb_ModedFile.Text = cleanString;

            //TimerMsg(name)
            regex = new Regex("timermsg (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "TimerMsg($1)");
            rtb_ModedFile.Text = cleanString;

            //Paperdoll(serial)
            regex = new Regex("paperdoll (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "PaperDoll($1)");
            rtb_ModedFile.Text = cleanString;

            //ClearList(serial)
            regex = new Regex("clearlist (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ClearList($1)");
            rtb_ModedFile.Text = cleanString;

            //InList(name, object)
            regex = new Regex("inlist (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "InList($1, $2)");
            rtb_ModedFile.Text = cleanString;

            //CreateList(name)
            regex = new Regex("createlist (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "CreateList($1)");
            rtb_ModedFile.Text = cleanString;

            //ListExists(name)
            regex = new Regex("listexists (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ListExists($1)");
            rtb_ModedFile.Text = cleanString;

            //RemoveList(name)
            regex = new Regex("removelist (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "RemoveList($1)");
            rtb_ModedFile.Text = cleanString;

            //PopList(listname, element)
            regex = new Regex("poplist (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "PopList($1, $2)");
            rtb_ModedFile.Text = cleanString;

            //PushList(listname, element)
            regex = new Regex("pushlist (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "PushList($1, $2)");
            rtb_ModedFile.Text = cleanString;

            //List(name)
            regex = new Regex("list (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "List($1)");
            rtb_ModedFile.Text = cleanString;

            //YellowHits
            regex = new Regex("yellowhits (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "YellowHits($1)");
            rtb_ModedFile.Text = cleanString;

            //TargetExists(serial)
            regex = new Regex("targetexists (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "TargetExists($1)");
            rtb_ModedFile.Text = cleanString;

            //GumpExists(serial)
            regex = new Regex("gumpexists (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "GumpExists($1)");
            rtb_ModedFile.Text = cleanString;

            //InGump(gumpid, text)
            regex = new Regex("ingump (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "InGump($1, $2)");
            rtb_ModedFile.Text = cleanString;

            //WaitingForTarget(milliseconds)
            regex = new Regex("waitingfortarget '(.*)'", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "WaitingForTarget($1)");
            rtb_ModedFile.Text = cleanString;
            ReplaceTxt("waitingfortarget", "WaitingForTarget()", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);

            //IgnoreObject(serial)
            regex = new Regex("ignoreobject (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "IgnoreObject($1)");
            rtb_ModedFile.Text = cleanString;

            //PlayMacro(string)
            regex = new Regex("playmacro (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "PlayMacro($1)");
            rtb_ModedFile.Text = cleanString;

            //Virtue(string)
            // Not sure this one exists will look for the alternative later
            regex = new Regex("virtue (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Virtue($1)");
            rtb_ModedFile.Text = cleanString;

            //InParty(serial)
            regex = new Regex("inparty (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "InParty($1)");
            rtb_ModedFile.Text = cleanString;

            //InRange(serial, distance)
            regex = new Regex("inrange (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "InRange($1, $2)");
            rtb_ModedFile.Text = cleanString;
            regex = new Regex("inrange (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "InRange($1)");
            rtb_ModedFile.Text = cleanString;

            //Property(serial, string)
            regex = new Regex("property (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Property($1, $2)");
            rtb_ModedFile.Text = cleanString;

            //Flying(serial)
            regex = new Regex("flying (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Flying($1)");
            rtb_ModedFile.Text = cleanString;
            regex = new Regex("flying ", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Flying() ");
            rtb_ModedFile.Text = cleanString;

            //Fly(serial)
            regex = new Regex("fly (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Fly($1)");
            rtb_ModedFile.Text = cleanString;
            regex = new Regex("fly ", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Fly() ");
            rtb_ModedFile.Text = cleanString;

            //Undress(string)
            regex = new Regex("undress (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Undress($1)");
            rtb_ModedFile.Text = cleanString;

            //Dress(string)
            regex = new Regex("dress (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Dress($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("organizer (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Organizer($1)");
            rtb_ModedFile.Text = cleanString;

            //Buy(string)
            //Doesnt seem to exist will need to find new func
            regex = new Regex("buy (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Buy($1)");
            rtb_ModedFile.Text = cleanString;

            //Sell(string)
            //Doesnt seem to exist will need to find new func
            regex = new Regex("sell (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Sell($1)");
            rtb_ModedFile.Text = cleanString;

            //FindAlias(name)
            regex = new Regex("findalias (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "FindAlias($1)");
            rtb_ModedFile.Text = cleanString;

            //SetAlias(name, serial)
            regex = new Regex("setalias (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "SetAlias($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("setalias (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "SetAlias($1)");
            rtb_ModedFile.Text = cleanString;

            //UnsetAlias(name)
            regex = new Regex("unsetalias (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "UnsetAlias($1)");
            rtb_ModedFile.Text = cleanString;

            //Distance(serial)
            regex = new Regex("distance (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Distance($1)");
            rtb_ModedFile.Text = cleanString;

            //MessageBox(title, body)
            regex = new Regex("messagebox (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "MessageBox($1, $2)");
            rtb_ModedFile.Text = cleanString;

            //PlaySound(id)
            regex = new Regex("playsound (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "PlaySound($1)");
            rtb_ModedFile.Text = cleanString;

            //ClearHands(name)
            regex = new Regex("clearhands (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ClearHands($1)");
            rtb_ModedFile.Text = cleanString;

            //Feed(serial, graphic, amount, hue
            regex = new Regex("feed (.*) (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Feed($1, $2, $3, $4)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("feed (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Feed($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("feed (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Feed($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("feed (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Feed($1)");
            rtb_ModedFile.Text = cleanString;

            //ClickObject(serial)
            regex = new Regex("clickobject (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ClickObject($1)");
            rtb_ModedFile.Text = cleanString;

            //Attack(serial)
            regex = new Regex("attack (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Attack($1)");
            rtb_ModedFile.Text = cleanString;

            //Bandage(serial)
            regex = new Regex("bandage (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Bandage($1)");
            rtb_ModedFile.Text = cleanString;

            //AddFriend(serial)
            regex = new Regex("addfriend (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "AddFriend($1)");
            rtb_ModedFile.Text = cleanString;

            //RemoveFriend(serial)
            regex = new Regex("removefriend (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "RemoveFriend($1)");
            rtb_ModedFile.Text = cleanString;

            //InFriendList(serial)
            regex = new Regex("infriendlist (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "InFriendList($1)");
            rtb_ModedFile.Text = cleanString;

            //Snapshot(delay, fullscreen, filename
            regex = new Regex("snapshot (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Snapshot($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            //UseObject(serial, skipqueue)
            regex = new Regex("useobject (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "UseObject($1, $2)");
            rtb_ModedFile.Text = cleanString;
            regex = new Regex("useobject (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "UseObject($1)");
            rtb_ModedFile.Text = cleanString;

            //InRegion(string, serial) 
            regex = new Regex("inregion (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "InRegion($1, $2)");
            rtb_ModedFile.Text = cleanString;

            //SetAbility(name, onoff)
            regex = new Regex("setability (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "SetAbility($1, $2)");
            rtb_ModedFile.Text = cleanString;

            //Dead(serial)
            regex = new Regex("dead (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Dead($1)");
            rtb_ModedFile.Text = cleanString;

            //Paralyzed(serial)
            regex = new Regex("paralyzed (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Paralyzed($1)");
            rtb_ModedFile.Text = cleanString;

            //Poisoned(serial)
            regex = new Regex("poisoned (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Poisoned($1)");
            rtb_ModedFile.Text = cleanString;

            //TargetGround(serial, hue, range)
            regex = new Regex("autotargetground (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "TargetGround($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            //TargetGround(serial, hue, range)
            regex = new Regex("targetground (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "TargetGround($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            //TargetTileRelative(serial, distance, reverse, itemid)
            regex = new Regex("autotargettilerelative (.*) (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "TargetTileRelative($1, $2, $3, $4)");
            rtb_ModedFile.Text = cleanString;
            regex = new Regex("autotargettilerelative (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "TargetTileRelative($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            //TargetTileRelative(serial, distance, reverse, itemid)
            regex = new Regex("targettilerelative (.*) (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "TargetTileRelative($1, $2, $3, $4)");
            rtb_ModedFile.Text = cleanString;
            regex = new Regex("targettilerelative (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "TargetTileRelative($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            //TargetType(serial, hue, range)
            regex = new Regex("autotargettype (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "TargetType($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            //TargetType(serial, hue, range)
            regex = new Regex("targettype (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "TargetType($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            //TargetTileOffset(x, y, z)
            regex = new Regex("autotargettile (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "TargetTileOffset($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            //TargetTileOffset(x, y, z)
            regex = new Regex("autotargettileoffset (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "TargetTileOffset($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            //TargetTile(x, y, z)
            regex = new Regex("targettileoffset (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "TargetTileOffset($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            //FindWand(name, container, charges)
            regex = new Regex("findwand (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "FindWand($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            //CountTypeGround(graphic, hue, range)
            regex = new Regex("counttypeground (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "CountTypeGround($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            //CountType(graphic, offset, hue)
            regex = new Regex("counttype (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "CountType($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("counttype (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "CountType($1, $2)");
            rtb_ModedFile.Text = cleanString;

            //Target(serial, range)
            regex = new Regex("autotargetghost (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Target($1, $2)");
            rtb_ModedFile.Text = cleanString;

            //UseType(serial, hue, container, skipqueue)
            regex = new Regex("usetype (.*) (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "UseType($1, $2, $3, $4)");
            rtb_ModedFile.Text = cleanString;
            regex = new Regex("usetype (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "UseType($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;
            regex = new Regex("usetype (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "UseType($1)");
            rtb_ModedFile.Text = cleanString;

            //MoveType(serial, source, destination, x, y, z, hue, amount)
            regex = new Regex("movetype (.*) (.*) (.*) (.*) (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "MoveType($1, $2, $3, $4, $5, $6, $7, $8)");
            rtb_ModedFile.Text = cleanString;
            regex = new Regex("movetype (.*) (.*) (.*) (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "MoveType($1, $2, $3, $4, $5, $6, $7)");
            rtb_ModedFile.Text = cleanString;
            regex = new Regex("movetype (.*) (.*) (.*) (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "MoveType($1, $2, $3, $4, $5, $6)");
            rtb_ModedFile.Text = cleanString;
            regex = new Regex("movetype (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "MoveType($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            //MoveTypeOffset(serial, location, x, y, z, amount, hue, range)
            regex = new Regex("movetypeoffset (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "MoveTypeOffset($1, $2, $3, $4, $5, $6, $7, $8)");
            rtb_ModedFile.Text = cleanString;
            regex = new Regex("movetypeoffset (.*) (.*) (.*) (.*) (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "MoveTypeOffset($1, $2, $3, $4, $5, $6, $7)");
            rtb_ModedFile.Text = cleanString;
            regex = new Regex("movetypeoffset (.*) (.*) (.*) (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "MoveTypeOffset($1, $2, $3, $4, $5, $6)");
            rtb_ModedFile.Text = cleanString;
            regex = new Regex("moveitemoffset (.*) (.*) (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "MoveItemOffset($1, $2, $3, $4, $5)");
            rtb_ModedFile.Text = cleanString;

            //EquipItem(serial, slot)
            regex = new Regex("equipitem (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "EquipItem($1, $2)");
            rtb_ModedFile.Text = cleanString;

            //SysMessage(string, hue)
            regex = new Regex("sysmsg (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "SysMessage($1, $2)");
            rtb_ModedFile.Text = cleanString;
            regex = new Regex("sysmsg (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "SysMessage($1)");
            rtb_ModedFile.Text = cleanString;

            //HeadMsg(string, serial, hue)
            regex = new Regex("headmsg (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "HeadMsg($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;
            regex = new Regex("headmsg (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "HeadMsg($1, $2)");
            rtb_ModedFile.Text = cleanString;
            regex = new Regex("headmsg (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "HeadMsg($1)");
            rtb_ModedFile.Text = cleanString;

            //GuildMsg(string)
            regex = new Regex("guildmsg (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "GuildMsg($1)");
            rtb_ModedFile.Text = cleanString;

            //PartyMsg(string)
            regex = new Regex("partymsg (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "PartyMsg($1)");
            rtb_ModedFile.Text = cleanString;

            //ChatMsg(string)
            regex = new Regex("chatmsg (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ChatMsg($1)");
            rtb_ModedFile.Text = cleanString;

            //EmoteMsg(string)
            regex = new Regex("emotemsg (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "EmoteMsg($1)");
            rtb_ModedFile.Text = cleanString;

            //YellMsg(string)
            regex = new Regex("yellmsg (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "YellMsg($1)");
            rtb_ModedFile.Text = cleanString;

            //PromptMsg(string)
            regex = new Regex("promptmsg (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "PromptMsg($1)");
            rtb_ModedFile.Text = cleanString;

            //WaitForPrompt(milliseconds)
            regex = new Regex("waitforprompt (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "WaitForPrompt($1)");
            rtb_ModedFile.Text = cleanString;

            //Msg(string, hue)
            regex = new Regex("msg (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Msg($1, $2)");
            rtb_ModedFile.Text = cleanString;

            //InJournal(string, author, hue)
            regex = new Regex("injournal (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "InJournal($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;
            regex = new Regex("injournal (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "InJournal($1, $2)");
            rtb_ModedFile.Text = cleanString;
            regex = new Regex("injournal (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "InJournal($1)");
            rtb_ModedFile.Text = cleanString;

            //Target(serial)
            regex = new Regex("autotargetobject (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Target($1)");
            rtb_ModedFile.Text = cleanString;

            //WaitForTarget(milliseconds)
            regex = new Regex("waitfortarget (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "WaitForTarget($1)");
            rtb_ModedFile.Text = cleanString;

            //Pause(milliseconds)
            regex = new Regex("pause (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Pause($1)");
            rtb_ModedFile.Text = cleanString;

            //PromptAlias(string)
            regex = new Regex("promptalias (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "PromptAlias($1)");
            rtb_ModedFile.Text = cleanString;

            //Target(serial)
            regex = new Regex("target (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Target($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("skill (\"(?:[^\\\\\"]|\\\\\\\\|\\\\\")*\")", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Skill($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("useskill (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "UseSkill($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("moveitem (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "MoveItem($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getfriend (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "GetFriend($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getfriend (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "GetFriend($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getenemy (.*) (.*) (.*) (.*) (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "GetEnemy($1, $2, $3, $4, $5, $6, $7)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getenemy (.*) (.*) (.*) (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "GetEnemy($1, $2, $3, $4, $5, $6)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("getenemy (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "GetEnemy($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("waitforgump (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "WaitForGump($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("replygump (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ReplyGump($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("replygump (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ReplyGump($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("waitforjournal (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "WaitForJournal($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("waitforjournal (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "WaitForJournal($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("waitforjournal (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "WaitForJournal($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("cast (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Cast($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("cast (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Cast($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("buffexists (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "BuffExists($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("graphic (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Graphic($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("serial (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Serial($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("mounted (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Mounted($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("amount (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Amount($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("mount (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Mount($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("timer (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Timer($1)");
            rtb_ModedFile.Text = cleanString;

            ReplaceTxt("maxmana (.*)", "MaxMana($1)", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("maxhits (.*)", "MaxHits($1)", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("maxstam (.*)", "MaxStam($1)", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("mana (.*)", "Mana($1)", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("diffhits ('(?:[^']|'')*')", "DiffHits($1)", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("diffhits ", "DiffHits() ", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("hits (.*)", "Hits($1)", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("stam (.*)", "Stam($1)", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
            ReplaceTxt("if (.*)", "if $1:", RegexOptions.IgnoreCase, rtb_ModedFile, rtb_ModedFile);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
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

        private void gitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/TheDroidYourLookingFor/ClassicAssist-Macro-Converter");
        }

        private void classicAssistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Reetus/ClassicAssist");
        }

        private void classicUoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ClassicUO/ClassicUO");
        }
    }
}
