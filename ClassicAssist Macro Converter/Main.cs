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
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("@", "");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("!", "");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("//", "#");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("stop", "Stop()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("weight", "Weight()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("direction", "Direction()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("grabitem", "GrabItem()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("guildbutton", "GuildButton()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("helpbutton", "HelpButton()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("logoutbutton", "LogoutButton()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("questsbutton", "QuestsButton()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("fly ", "Fly() ");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("land", "Land()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("cancelautotarget", "CancelAutoTarget()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("canceltarget", "CancelTarget()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("autoloot", "AutoLoot()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("cancelprompt", "CancelPrompt()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("autotargetlast", "AutoTargetLast()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("bandageself", "BandageSelf()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("autotargetself", "AutoTargetSelf()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("resync", "Resync()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("ping", "Ping()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("clearignorelist", "ClearIgnoreList()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("hotkeys", "Hotkeys()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("info", "Info()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("clearjournal", "ClearJournal()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("else\n", "else:\n");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("elseif", "elif");

            //FindObject
            Regex regex = new Regex("findobject (.*) (.*) (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            string cleanString = regex.Replace(rtb_ModedFile.Text, "FindObject($1, $2, $3, $4, $5)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("findobject (.*) (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "FindObject($1, $2, $3, $4)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("findobject (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "FindObject($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("findobject (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "FindObject($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("findobject '(.*)'", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "FindObject($1)");
            rtb_ModedFile.Text = cleanString;

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

            regex = new Regex("findtype '(.*)'", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "FindType($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("createtimer (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "CreateTimer($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("removetimer (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "RemoveTimer($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("settimer (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "SetTimer($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("timerexists (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "TimerExists($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("timermsg (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "TimerMsg($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("timer (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Timer($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("paperdoll (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "PaperDoll($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("clearlist (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ClearList($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("inlist (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "InList($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("createlist (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "CreateList($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("listexists (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ListExists($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("removelist (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "RemoveList($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("poplist (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "PopList($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("pushlist (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "PushList($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("list (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "List($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("yellowhits (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "YellowHits($1)");
            rtb_ModedFile.Text = cleanString;
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("maxmana", "MaxMana()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("maxhits", "MaxHits()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("mana", "Mana()");
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("hits", "Hits()");

            regex = new Regex("targetexists '(.*)'", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "TargetExists($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("gumpexists '(.*)'", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "GumpExists($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("ingump (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "InGump($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("ingump (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "InGump($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("waitingfortarget '(.*)'", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "WaitingForTarget($1)");
            rtb_ModedFile.Text = cleanString;
            rtb_ModedFile.Text = rtb_ModedFile.Text.Replace("waitingfortarget", "WaitingForTarget()");

            regex = new Regex("ignoreobject (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "IgnoreObject($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("playmacro (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "PlayMacro($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("virtue (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Virtue($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("inparty (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "InParty($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("inrange (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "InRange($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("property (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Property($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("property (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Property($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("flying (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Flying($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("undress (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Undress($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("dress (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Dress($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("organizer (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Organizer($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("buy (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Buy($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("sell (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Sell($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("findalias (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "FindAlias($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("setalias (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "SetAlias($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("setalias (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "SetAlias($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("unsetalias (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "UnsetAlias($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("distance (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Distance($1)");
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

            regex = new Regex("addfriend (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "AddFriend($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("removefriend (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "RemoveFriend($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("infriendlist (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "InFriendList($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("snapshot (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Snapshot($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("useobject (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "UseObject($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("inregion (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "InRegion($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("setability (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "SetAbility($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("setability (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "SetAbility($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("dead (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Dead($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("paralyzed (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Paralyzed($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("poisoned (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Poisoned($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("autotargetground (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "AutoTargetGround($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("targetground (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "TargetGround($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("autotargettilerelative (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "AutoTargetTileRelative($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("targettilerelative (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "TargetTileRelative($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("autotargettype (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "AutoTargetType($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("targettype (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "TargetType($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("autotargettile (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "AutoTargetTile($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("autotargettile (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "AutoTargetTile($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("autotargettileoffset (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "AutoTargetTileOffset($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("findwand (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "FindWand($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("counttypeground (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "CountTypeGround($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("counttype (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "CountType($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("counttype (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "CountType($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("autotargetghost (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "AutoTargetGhost($1, $2)");
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

            regex = new Regex("movetypeoffset (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "MoveTypeOffset($1, $2, $3, $4, $5, $6, $7, $8, $9)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("moveitemoffset (.*) (.*) (.*) (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "MoveItemOffset($1, $2, $3, $4, $5, $6)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("equipitem (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "EquipItem($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("sysmsg (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "SysMsg($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("headmsg (.*) (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "HeadMsg($1, $2, $3)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("headmsg (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "HeadMsg($1, $2)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("guildmsg (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "GuildMsg($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("partymsg (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "PartyMsg($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("chatmsg (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "ChatMsg($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("emotemsg (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "EmoteMsg($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("yellmsg (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "YellMsg($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("promptmsg (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "PromptMsg($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("waitforprompt (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "WaitForPrompt($1)");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("msg (.*) (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Msg($1, $2)");
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

            regex = new Regex("if (.*)", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "if $1:");
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

            regex = new Regex("cast '(.*)' '(.*)'", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Cast('$1', '$2')");
            rtb_ModedFile.Text = cleanString;

            regex = new Regex("cast '(.*)'", RegexOptions.IgnoreCase);
            cleanString = regex.Replace(rtb_ModedFile.Text, "Cast('$1')");
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
