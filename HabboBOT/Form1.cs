using DiscordRPC;
using HabboBOT.Entities;
using HabboBOT.Entities.API;
using HabboBOT.Entities.Headers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp.Server;
using System.Net;
using System.Diagnostics;
using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Text;

using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Web.Helpers;

namespace HabboBOT
{
    public class Form1 : Form
  {
      
        public Dictionary<string, string> accounts = new Dictionary<string, string>();
    public bool isWalkRandom;
    public bool isAntiAfk;
    public bool isSitWalking;
    public bool isInRoom;
    public bool isLooking;
    public Size formNoLogsSize = new Size(996, 512);
    public Size formSize = new Size(1255, 509);
    public Color Btn_Enabled = Color.FromArgb(48, 46, 46);
    public Color Btn_Disabled = Color.FromArgb(73, 70, 70);
    public Handler handler;
    public UserLogin login;
    public string path = "files/cache.json";
    public string path_headers = "headers.json";
    private Point position;
    private string socketLink;
    public WebSocketServer server;
    public Random _random = new Random();
    public DiscordRpcClient client;
    private int accountsCount = File.ReadAllLines("cuentas.txt").Length;
    private IContainer components = (IContainer) null;
    private System.Windows.Forms.Button btnConnection;
    private Panel panel1;
    private Label label1;
    private System.Windows.Forms.Button btnActions;
    private GroupBox groupBox1;
    private Panel panel2;
    private System.Windows.Forms.Button btnBotManager;
    private Label labelExit;
    private Label labelMinimize;
    private Panel panelActions;
    private GroupBox groupBox3;
    private System.Windows.Forms.Button button4;
    private TextBox txtPassword;
    private System.Windows.Forms.Button button3;
    private TextBox txtPetId;
    private GroupBox groupBox5;
    private GroupBox groupBox4;
    private System.Windows.Forms.Button button8;
    private GroupBox groupBox6;
    private TextBox textBox6;
    private System.Windows.Forms.Button button15;
    private System.Windows.Forms.Button button14;
    private ComboBox genderBox;
    private TextBox txtUsername;
    private System.Windows.Forms.Button button13;
    private TextBox txtFriend;
    private System.Windows.Forms.Button button11;
    private TextBox textBox9;
    private Panel panelConnection;
    private GroupBox groupBox8;
    private GroupBox groupBox7;
    public ComboBox comboBox2;
    private ComboBox comboBox3;
    private ComboBox comboBox5;
    private System.Windows.Forms.Button button7;
    private ComboBox comboBox4;
    private System.Windows.Forms.Button button10;
    private System.Windows.Forms.Button btnActions2;
    private CheckBox chkTopMost;
    private CheckBox chkPassword;
    public Label statusIntercept;
    public Label label2;
    private Panel panel4;
    private GroupBox groupBox2;
    private RichTextBox richTextBox1;
    private CheckBox checkBox1;
    public Label label4;
    private Panel panelBotManager;
    private System.Windows.Forms.Button button23;
    private System.Windows.Forms.Button button22;
    private System.Windows.Forms.Button button20;
    public ListView listBots;
    public CheckBox checkBox3;
    public System.Windows.Forms.Button button17;
    public CheckBox checkBox5;
    public CheckBox chkLoadRoom;
    public TextBox txtRoomId;
    private TextBox txtGroupId;
    private System.Windows.Forms.Button button21;
    private GroupBox groupBox10;
    private CheckBox checkBox4;
    private CheckBox checkBox2;
    private TextBox textBox10;
    private TextBox textBox8;
    private System.Windows.Forms.Button button9;
    private GroupBox groupBox9;
    private System.Windows.Forms.Button button24;
    private TextBox txtMotto;
    private System.Windows.Forms.Button button18;
    private GroupBox groupBox11;
    private GroupBox groupBox12;
    public CheckBox hoursBox;
    public CheckBox minutesBox;
    public CheckBox secondsBox;
    private System.Windows.Forms.Button button19;
    private Label label9;
    private TextBox timeText;
    private Label label8;
        private Label label3;
        private Label label7;
    private TextBox mainRoomText;
    private TextBox targetRoom;
    private System.Windows.Forms.Button button12;
    private Panel panelActions2;
    public CheckBox chkPasswordLoadRoom;
    public TextBox txtLoadRoomId;
    private CheckBox sitWalking;
    public TextBox txtApiKey;
    private Label label11;
    private Label label10;
    private TextBox txtSendGemAmount;
    private TextBox txtSendGemUserId;
    private System.Windows.Forms.Button button16;
    private CheckBox checkBox7;
    private CheckBox checkBox6;
    private ColumnHeader columnHeader1;
    private System.Windows.Forms.Button btnSignature;
    private TextBox txtSignature;
    public ListView listSpecificsBot;
    private ColumnHeader columnHeader2;
    private System.Windows.Forms.Button button27;
        

    public Form1()
    {
            MessageBox.Show("Este programa de BOT es un fix de otro source, HabboBOT ha sido distrubuido por AleejkE y es completamente gratuito. Si haz pagado por este programa haz sido estafado...", "HabboBOT - Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.InitializeComponent();
            this.LoadAccounts();
            this.CheckForUpdates();
            this.client = new DiscordRpcClient("1090130373251448842"); // Identificador que desconozco, es para Discord le puse 1
            this.txtRoomId.Visible = false;
            this.txtLoadRoomId.Visible = false;
            this.chkPasswordLoadRoom.Visible = false;
            this.txtApiKey.Visible = false;
            this.server = new WebSocketServer(8080, false);
            this.server.AddWebSocketService<Token.ReceiveTokenService>("/");
            this.server.Start();
            this.handler = new Handler(this);
            this.login = new UserLogin(this);
            this.label3.Text = "Hola, " + HabboBOT.Entities.Configuration.Username;
            this.label4.Text = string.Format("Desconectado: 0/{0}", (object)File.ReadAllLines("cuentas.txt").Length);
            if (this.checkBox1.Checked)
        this.Size = this.formSize;
      else
        this.Size = this.formNoLogsSize;
      DiscordRpcClient client = this.client;
     RichPresence richPresence = new RichPresence();
      richPresence.Buttons = new DiscordRPC.Button[1]
      {
        new DiscordRPC.Button()
        {
          Label = "Discord",
          Url = "https://discord.gg/uhES8HRvnp" // Invitacion a mi Discord de Sorteos, no supe que otro enlace poner.
        }
      };
      richPresence.Details = string.Format("Bots Conectados: {0} / {1}", (object) HabboBOT.Entities.Configuration.bots.Count, (object) this.accountsCount);
      richPresence.State = string.Format("Hotel: habbo{0}", this.comboBox2.SelectedItem);
      richPresence.Timestamps = Timestamps.Now;
      richPresence.Assets = new Assets()
      {
        LargeImageKey = "AleejkE",
      //  LargeImageText = "by " + GetInfo.GetDiscordDeveloperHabboBOT()
      };
     RichPresence presence = richPresence;
      client.SetPresence(presence);
      this.GetCache();
      this.genderBox.SelectedIndex = 1;
      this.panelActions.Size = new Size(this.groupBox1.Width, this.groupBox1.Height);
      this.panelActions.Top = this.groupBox1.Top;
      this.panelActions.Left = this.groupBox1.Left;
      this.panelConnection.Size = new Size(this.groupBox1.Width, this.groupBox1.Height);
      this.panelConnection.Top = this.groupBox1.Top;
      this.panelConnection.Left = this.groupBox1.Left;
      this.panelActions2.Size = new Size(this.groupBox1.Width, this.groupBox1.Height);
      this.panelActions2.Top = this.groupBox1.Top;
      this.panelActions2.Left = this.groupBox1.Left;
      this.panelBotManager.Size = new Size(this.groupBox1.Width, this.groupBox1.Height);
      this.panelBotManager.Top = this.groupBox1.Top;
      this.panelBotManager.Left = this.groupBox1.Left;
      this.panelConnection.BringToFront();
      if (File.Exists("Headers.ini"))
      {
        HabboBOT.Entities.Headers.Headers.LoadIncoming();
        HabboBOT.Entities.Headers.Headers.LoadOutgoing();
      }
      else
      {
        SulekHeaders.GetHeaders();
        SulekHeaders.GetHeaders(true);
      }
      this.UpdateLists();

    }


        public void LoadAccounts()
    {
      if (!File.Exists("cuentas.txt"))
        File.Create("cuentas.txt").Close();
      foreach (string readAllLine in File.ReadAllLines("cuentas.txt"))
      {
        string key = readAllLine.Split(':')[0].Trim();
        string str = readAllLine.Split(':')[1].Trim();
        if ((uint) this.accounts.Count > 0U)
        {
          if (!this.accounts.ContainsKey(key))
            this.accounts.Add(key, str);
        }
        else
          this.accounts.Add(key, str);
      }
    }
        private void Form1_MouseDown(object sender, MouseEventArgs e) => this.position = e.Location;

    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      this.Location = new Point(this.Location.X + (e.Location.X - this.position.X), this.Location.Y + (e.Location.Y - this.position.Y));
    }

    private void ClearSpecificsBot()
    {
      if (this.listSpecificsBot.Items.Count == 0)
        return;
      foreach (ListViewItem listViewItem in this.listSpecificsBot.Items)
      {
        this.listSpecificsBot.Items.Remove(listViewItem);
        this.listBots.Items.Add(listViewItem);
      }
    }

        private void CheckForUpdates()
        {
            if (!(HabboBOT.Entities.Configuration.VERSION != GetInfo.GetHabboBOTVersion()))
                return;
            if (MessageBox.Show("Nueva Actualizacion! Contacta con AleejkE para obtener la ultima version de este programa. Pulsa cualquier boton para cerrar esta ventana...", "HabboBOT - Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.Yes) // Original : MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes
                Process.Start(HabboBOT.Entities.Configuration.DownloadUrl);
            else
                Environment.Exit(1);
        }

        private void RemoveBot()
    {
      if (this.listSpecificsBot.SelectedItems.Count == 0)
        return;
      foreach (ListViewItem selectedItem in this.listSpecificsBot.SelectedItems)
      {
        this.listSpecificsBot.Items.Remove(selectedItem);
        this.listBots.Items.Add(selectedItem);
      }
    }

    private void AddBot()
    {
      if (this.listBots.SelectedItems.Count == 0)
        return;
      foreach (ListViewItem selectedItem in this.listBots.SelectedItems)
      {
        this.listBots.Items.Remove(selectedItem);
        this.listSpecificsBot.Items.Add(selectedItem);
      }
    }

    public void AddBotToList(int Id) => this.listBots.Items.Add(new ListViewItem()
    {
      Text = "BOT " + Id.ToString(),
      Tag = (object) Id
    });

    public void RemoveBotFromList(int Id)
    {
      foreach (ListViewItem listViewItem in this.listBots.Items)
      {
        if ((int) listViewItem.Tag == Id)
        {
          this.listBots.Items.Remove(listViewItem);
          return;
        }
      }
      foreach (ListViewItem listViewItem in this.listSpecificsBot.Items)
      {
        if ((int) listViewItem.Tag == Id)
        {
          this.listSpecificsBot.Items.Remove(listViewItem);
          break;
        }
      }
    }

    public List<int> getUsingBots()
    {
      List<int> intList = new List<int>();
      try
      {
        foreach (ListViewItem listViewItem in this.listSpecificsBot.Items)
          intList.Add((int) listViewItem.Tag);
      }
      catch
      {
      }
      return intList;
    }

    private void button22_Click(object sender, EventArgs e)
    {
      this.AddBot();
      this.UpdateLists();
    }

    private void button20_Click(object sender, EventArgs e)
    {
      this.RemoveBot();
      this.UpdateLists();
    }

    private void button23_Click(object sender, EventArgs e)
    {
      this.ClearSpecificsBot();
      this.UpdateLists();
    }

    private void ExitHover(object sender, EventArgs e)
    {
      this.labelExit.ForeColor = Color.Red;
      this.labelExit.Cursor = Cursors.Hand;
    }

    private void MinimizeHover(object sender, EventArgs e)
    {
      this.labelMinimize.ForeColor = Color.Red;
      this.labelMinimize.Cursor = Cursors.Hand;
    }

    private void ExitLeave(object sender, EventArgs e)
    {
      this.labelExit.ForeColor = Color.White;
      this.labelExit.Cursor = Cursors.Default;
    }

    private void MinimizeLeave(object sender, EventArgs e)
    {
      this.labelMinimize.ForeColor = Color.White;
      this.labelMinimize.Cursor = Cursors.Default;
    }

    private void labelExit_Click(object sender, EventArgs e) => Application.Exit();

    private void labelMinimize_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

    private void SaveCache()
    {
      if (Cache.Get("hotel") != this.comboBox2.Text && this.comboBox2.Text != "")
        Cache.Update("hotel", this.comboBox2.Text);
      if (Cache.Get("api_key") != this.txtApiKey.Text)
        Cache.Update("api_key", this.txtApiKey.Text);
      if (Cache.Get("autoloadroom_id") != this.txtRoomId.Text)
        Cache.Update("autoloadroom_id", this.txtLoadRoomId.Text == "" ? this.txtRoomId.Text : this.txtRoomId.Text + "-" + this.txtLoadRoomId.Text);
      if (bool.Parse(Cache.Get("logs")) != this.checkBox1.Checked)
        Cache.Update("logs", this.checkBox1.Checked.ToString());
      if (bool.Parse(Cache.Get("topmost")) == this.chkTopMost.Checked)
        return;
      Cache.Update("topmost", this.chkTopMost.Checked.ToString());
    }

    private void GetCache()
    {
      string str1 = Cache.Get("autoloadroom_id");
      string str2;
      string str3;
      if (str1.Contains('-'))
      {
        str2 = str1.Split('-')[0];
        str3 = str1.Split('-')[1];
        this.chkPasswordLoadRoom.Checked = true;
      }
      else
      {
        str2 = str1;
        str3 = "";
      }
      this.comboBox2.Text = Cache.Get("hotel");
      this.txtRoomId.Text = str2;
      this.txtLoadRoomId.Text = str3;
      this.chkTopMost.Checked = bool.Parse(Cache.Get("topmost"));
      this.checkBox1.Checked = bool.Parse(Cache.Get("logs"));
      this.txtApiKey.Text = Cache.Get("api_key");
    }

    private void button6_Click(object sender, EventArgs e)
    {
      if (this.btnConnection.BackColor == this.Btn_Enabled)
        this.btnConnection.BackColor = this.Btn_Disabled;
      else if (this.btnActions.BackColor == this.Btn_Enabled)
        this.btnActions.BackColor = this.Btn_Disabled;
      else if (this.btnBotManager.BackColor == this.Btn_Enabled)
        this.btnBotManager.BackColor = this.Btn_Disabled;
      this.btnActions2.BackColor = this.Btn_Enabled;
      this.panelActions2.BringToFront();
    }

    private void button5_Click(object sender, EventArgs e)
    {
      if (this.btnConnection.BackColor == this.Btn_Enabled)
        this.btnConnection.BackColor = this.Btn_Disabled;
      else if (this.btnActions2.BackColor == this.Btn_Enabled)
        this.btnActions2.BackColor = this.Btn_Disabled;
      else if (this.btnBotManager.BackColor == this.Btn_Enabled)
        this.btnBotManager.BackColor = this.Btn_Disabled;
      this.btnActions.BackColor = this.Btn_Enabled;
      this.panelActions.BringToFront();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (this.btnActions.BackColor == this.Btn_Enabled)
        this.btnActions.BackColor = this.Btn_Disabled;
      else if (this.btnActions2.BackColor == this.Btn_Enabled)
        this.btnActions2.BackColor = this.Btn_Disabled;
      else if (this.btnBotManager.BackColor == this.Btn_Enabled)
        this.btnBotManager.BackColor = this.Btn_Disabled;
      this.btnConnection.BackColor = this.Btn_Enabled;
      this.panelConnection.BringToFront();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (this.btnConnection.BackColor == this.Btn_Enabled)
        this.btnConnection.BackColor = this.Btn_Disabled;
      else if (this.btnActions.BackColor == this.Btn_Enabled)
        this.btnActions.BackColor = this.Btn_Disabled;
      else if (this.btnActions2.BackColor == this.Btn_Enabled)
        this.btnActions2.BackColor = this.Btn_Disabled;
      this.btnBotManager.BackColor = this.Btn_Enabled;
      this.panelBotManager.BringToFront();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      try
      {
        string str1 = string.Format("{0}Hey, actualmente tienes {1} bots conectados. Deseas cerrar la aplicacion?", (object) HabboBOT.Entities.Configuration.Username, (object) HabboBOT.Entities.Configuration.bots.Count);
        string str2 = string.Format("{0}Hey, actualmente tienes {1} bots conectados. Deseas cerrar la aplicacion?", (object) HabboBOT.Entities.Configuration.Username, (object) HabboBOT.Entities.Configuration.bots.Count);
        if ((uint) HabboBOT.Entities.Configuration.bots.Count > 0U && MessageBox.Show(HabboBOT.Entities.Configuration.bots.Count > 1 ? str1 : str2, "HabboBOT", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
          e.Cancel = true;
        this.SaveCache();
      }
      catch
      {
      }
    }

    private void button17_ClickAsync(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(this.comboBox2.Text))
      {
        if (this.button17.Text == "Intercept")
        {
          string str = this.comboBox2.SelectedItem.ToString();
          this.socketLink = !(str != ".com") ? "us" : str.Substring(str.Length - 2);
          HabboBOT.Entities.Configuration.loginUrl = "https://www.habbo" + str + "/api/public/authentication/login";
          HabboBOT.Entities.Configuration.webSocketUrl = "game-" + this.socketLink + ".habbo.com";
          HabboBOT.Entities.Configuration.clientUrl = "https://www.habbo" + str + "/api/client/clientv2url";
          HabboBOT.Entities.Configuration.Host = "www.habbo" + str;
          HabboBOT.Entities.Configuration.Origin = "https://www.habbo" + str;
          HabboBOT.Entities.Configuration.Referer = "https://www.habbo" + str + "/hotelv2";
          HabboBOT.Entities.Configuration.ApiUrl = "https://www.habbo" + str + "/api/public";
          HabboBOT.Entities.Configuration.lastHotel = this.comboBox2.SelectedItem.ToString();
          if (this.client.IsInitialized)
            this.client.UpdateState("Hotel: habbo" + HabboBOT.Entities.Configuration.lastHotel);
          this.button17.Text = "Stop";
          this.statusIntercept.Text = "ON";
          this.statusIntercept.ForeColor = Color.LimeGreen;
          if (!(this.txtApiKey.Text != ""))
            return;
          HabboBOT.Entities.Configuration.ApiKey = this.txtApiKey.Text;
          if (this.checkBox3.Checked)
            this.login.Login2Captcha(GetInfo.GetHCaptchaKey());
        }
        else
        {
          this.button17.Text = "Intercept";
          this.statusIntercept.Text = "OFF";
          this.statusIntercept.ForeColor = Color.DarkRed;
        }
      }
      else
      {
        int num = (int) MessageBox.Show("Escoge un Hotel", "HabboBOT - Error");
      }
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox1.Checked)
        this.Size = this.formSize;
      else
        this.Size = this.formNoLogsSize;
    }

    private void richTextBox1_TextChanged(object sender, EventArgs e)
    {
      this.richTextBox1.SelectionStart = this.richTextBox1.Text.Length;
      this.richTextBox1.ScrollToCaret();
    }

    public void Log(string msg, Color color)
    {
      if (this.InvokeRequired)
      {
        this.Invoke((Delegate) new Form1.LogDelegate(this.Log), (object) msg, (object) color);
      }
      else
      {
        this.richTextBox1.SelectionStart = this.richTextBox1.TextLength;
        this.richTextBox1.SelectionLength = 0;
        this.richTextBox1.SelectionColor = color;
        this.richTextBox1.AppendText(this.richTextBox1.TextLength > 0 ? "\n" + msg : msg);
        this.richTextBox1.SelectionColor = this.richTextBox1.ForeColor;
      }
    }

    private void button9_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.checkBox2.Checked)
        {
          if (this.button9.Text == "Detener")
            this.button9.Text = "Caminar";
          this.Walk(false, int.Parse(this.textBox8.Text), int.Parse(this.textBox10.Text));
        }
        else if (this.button9.Text == "Caminar")
        {
          this.button9.Text = "Detener";
          this.WalkRandom(true);
        }
        else
        {
          this.button9.Text = "Caminar";
          this.WalkRandom(false);
        }
      }
      catch
      {
      }
    }

    private void button3_Click_1(object sender, EventArgs e)
    {
      if (this.listSpecificsBot.Items.Count > 0)
        this.handler.SendToAllUsingBots(this.getUsingBots(), (System.Action<Connection>) (bot => bot.SendPacket(Outgoing.OpenFlatConnection, (object) int.Parse(this.textBox9.Text), this.chkPassword.Checked ? (object) this.txtPassword.Text : (object) "", (object) -1)));
      else
        this.handler.SendToAllBots((System.Action<Connection>) (bot => bot.SendPacket(Outgoing.OpenFlatConnection, (object) int.Parse(this.textBox9.Text), this.chkPassword.Checked ? (object) this.txtPassword.Text : (object) "", (object) -1)));
    }

    private void button4_Click_1(object sender, EventArgs e)
    {
      if (this.listSpecificsBot.Items.Count > 0)
        this.handler.SendToAllUsingBots(this.getUsingBots(), (System.Action<Connection>) (bot => bot.SendPacket(Outgoing.OpenFlatConnection, (object) 0, (object) "", (object) -1)));
      else
        this.handler.SendToAllBots((System.Action<Connection>) (bot => bot.SendPacket(Outgoing.OpenFlatConnection, (object) 0, (object) "", (object) -1)));
    }

    private void checkBox4_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox4.Checked)
        this.AntiAfk(true);
      else
        this.AntiAfk(false);
    }

    private void button18_Click(object sender, EventArgs e)
    {
      if (this.listSpecificsBot.Items.Count > 0)
        this.handler.SendToAllUsingBots(this.getUsingBots(), (System.Action<Connection>) (bot => bot.SendPacket(Outgoing.ChangeMotto, this.txtMotto.Text != "" ? (object) this.txtMotto.Text : (object) "HabboBOT by Miscelanous")));
      else
        this.handler.SendToAllBots((System.Action<Connection>) (bot => bot.SendPacket(Outgoing.ChangeMotto, this.txtMotto.Text != "" ? (object) this.txtMotto.Text : (object) "HabboBOT by Miscelanous")));
    }

    private void button11_Click(object sender, EventArgs e)
    {
      if (this.listSpecificsBot.Items.Count > 0)
        this.handler.SendToAllUsingBots(this.getUsingBots(), (System.Action<Connection>) (bot => bot.SendPacket(Outgoing.RequestFriend, (object) this.txtFriend.Text)));
      else
        this.handler.SendToAllBots((System.Action<Connection>) (bot => bot.SendPacket(Outgoing.RequestFriend, (object) this.txtFriend.Text)));
    }

    private async void button13_Click(object sender, EventArgs e)
    {
      string FigureString = await HabboApi.GetFigureString(this.txtUsername.Text);
      string Gender = this.genderBox.SelectedItem.ToString();
      if (this.listSpecificsBot.Items.Count > 0)
        this.handler.SendToAllUsingBots(this.getUsingBots(), (System.Action<Connection>) (bot => bot.SendPacket(Outgoing.UpdateFigureData, (object) Gender, (object) FigureString)));
      else
        this.handler.SendToAllBots((System.Action<Connection>) (bot => bot.SendPacket(Outgoing.UpdateFigureData, (object) Gender, (object) FigureString)));
    }

    public void LogError(string msg) => this.Log(msg, Color.Red);

    public void LogSucess(string msg) => this.Log(msg, Color.LimeGreen);

    private void chkTopMost_CheckedChanged(object sender, EventArgs e) => this.TopMost = !this.TopMost;

    private void button19_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show("El Programador realiza la accion de cronometrar cuanto tiempo en MINUTOS permanecera el BOT en una sala, luego de ese tiempo determinado, los BOTS en uso o todos los BOTS lo dejaran, yendo al ID que decidas en la Sala Principal", "HabboBOT - Programador");
    }

    public void Walk(bool random, int x = 0, int y = 0)
    {
      if ((uint) this.listSpecificsBot.Items.Count > 0U)
        this.handler.SendToAllUsingBots(this.getUsingBots(), (System.Action<Connection>) (bot => bot.SendPacket(Outgoing.MoveAvatar, (object) (random ? bot._random.Next(1, 21) : x), (object) (random ? bot._random.Next(1, 21) : y))));
      else
        this.handler.SendToAllBots((System.Action<Connection>) (bot => bot.SendPacket(Outgoing.MoveAvatar, (object) (random ? bot._random.Next(1, 21) : x), (object) (random ? bot._random.Next(1, 21) : y))));
    }

    public void WalkRandom(bool status)
    {
      this.isWalkRandom = status;
      if (!this.isWalkRandom)
        return;
      new Thread(new ThreadStart(this.WalkRandomThread)).Start();
    }

    public void AntiAfk(bool status)
    {
      this.isAntiAfk = status;
      if (!this.isAntiAfk)
        return;
      new Thread(new ThreadStart(this.AntiAfkThread)).Start();
    }

    public async void AntiAfkThread()
    {
      while (this.isAntiAfk)
      {
        this.Walk(false, 1337, 1337);
        await Task.Delay(TimeSpan.FromMinutes(1.0));
      }
    }

    public void ForceBotInRoom(bool status)
    {
      this.isInRoom = status;
      if (!this.isInRoom)
        return;
      new Thread(new ThreadStart(this.ForceBotInRoomThread)).Start();
    }

    public async void ForceBotInRoomThread()
    {
      if (this.listSpecificsBot.Items.Count > 0)
        this.handler.SendToAllUsingBots(this.getUsingBots(), (System.Action<Connection>) (bot => bot.SendPacket(Outgoing.OpenFlatConnection, (object) int.Parse(this.targetRoom.Text), (object) "", (object) -1)));
      else
        this.handler.SendToAllBots((System.Action<Connection>) (bot => bot.SendPacket(Outgoing.OpenFlatConnection, (object) int.Parse(this.targetRoom.Text), (object) "", (object) -1)));
      this.AntiAfk(true);
      if (!this.isInRoom)
        return;
      if (this.secondsBox.Checked)
        await Task.Delay(TimeSpan.FromSeconds((double) int.Parse(this.timeText.Text)));
      else if (this.minutesBox.Checked)
        await Task.Delay(TimeSpan.FromMinutes((double) int.Parse(this.timeText.Text)));
      else if (this.hoursBox.Checked)
        await Task.Delay(TimeSpan.FromHours((double) int.Parse(this.timeText.Text)));
      if (this.listSpecificsBot.Items.Count > 0)
        this.handler.SendToAllUsingBots(this.getUsingBots(), (System.Action<Connection>) (bot => bot.SendPacket(Outgoing.OpenFlatConnection, (object) int.Parse(this.mainRoomText.Text), (object) "", (object) -1)));
      else
        this.handler.SendToAllBots((System.Action<Connection>) (bot => bot.SendPacket(Outgoing.OpenFlatConnection, (object) int.Parse(this.mainRoomText.Text), (object) "", (object) -1)));
    }

    public void UpdateRichPresence()
    {
      if (!this.checkBox5.Checked || !this.client.IsInitialized)
        return;
      this.client.UpdateDetails(string.Format("Bots Conectados: {0} / {1}", (object) HabboBOT.Entities.Configuration.bots.Count, (object) this.accountsCount));
    }

    private void button12_Click(object sender, EventArgs e)
    {
      if (this.button12.Text == "Iniciar")
      {
        this.button12.Text = "Detener";
        this.ForceBotInRoom(true);
      }
      else
      {
        this.button12.Text = "Iniciar";
        this.ForceBotInRoom(false);
      }
    }

    public static string RandomClothes()
    {
      List<int> intList1 = new List<int>()
      {
        180,
        185,
        190,
        195,
        200,
        205,
        206,
        207,
        208,
        209
      };
      List<int> intList2 = new List<int>()
      {
        14,
        10,
        1,
        8,
        12,
        1369,
        1370,
        19,
        20,
        1371,
        30
      };
      List<int> intList3 = new List<int>()
      {
        100,
        105,
        110,
        115,
        125,
        135,
        145,
        155,
        165,
        170,
        676,
        679,
        681,
        802,
        830,
        889,
        891,
        892,
        893,
        3090
      };
      List<int> intList4 = new List<int>()
      {
        40,
        34,
        35,
        36,
        31,
        32,
        37,
        38,
        43,
        46,
        47,
        48,
        44,
        39,
        45,
        42
      };
      List<int> intList5 = new List<int>()
      {
        90,
        210,
        91,
        66,
        1320,
        68,
        73,
        72,
        71,
        74,
        75,
        76,
        82,
        81,
        80,
        83,
        84,
        85,
        88,
        64
      };
      List<int> intList6 = new List<int>()
      {
        210,
        215,
        220,
        225,
        230,
        235,
        240,
        245,
        250,
        (int) byte.MaxValue,
        262,
        265,
        266,
        267,
        804,
        805,
        806,
        807,
        808,
        809,
        875,
        876,
        877,
        878,
        3030,
        3109,
        3110,
        3111
      };
      List<int> intList7 = new List<int>()
      {
        270,
        275,
        280,
        281,
        285,
        3023,
        3078,
        3088,
        3116,
        3201,
        3216,
        3290
      };
      List<int> intList8 = new List<int>()
      {
        290,
        295,
        300,
        305,
        905,
        906,
        908,
        3068,
        3115
      };
      List<int> intList9 = new List<int>()
      {
        3590,
        3276,
        3147,
        1212,
        1211,
        1210,
        1208,
        1206,
        1205,
        1204,
        1202,
        1201
      };
      StringBuilder stringBuilder = new StringBuilder();
      Random random = new Random();
      for (int index = 0; index < 6; ++index)
      {
        switch (index)
        {
          case 0:
            int num1 = intList4[random.Next(intList4.Count)];
            stringBuilder.Append(string.Format("hr-{0}-{1}.", (object) intList3[random.Next(intList3.Count)], (object) num1));
            break;
          case 1:
            int num2 = intList2[random.Next(intList2.Count)];
            stringBuilder.Append(string.Format("hd-{0}-{1}.", (object) intList1[random.Next(intList1.Count)], (object) num2));
            break;
          case 2:
            int num3 = intList5[random.Next(intList5.Count)];
            stringBuilder.Append(string.Format("ch-{0}-{1}.", (object) intList6[random.Next(intList6.Count)], (object) num3));
            break;
          case 3:
            int num4 = intList5[random.Next(intList5.Count)];
            stringBuilder.Append(string.Format("lg-{0}-{1}.", (object) intList7[random.Next(intList7.Count)], (object) num4));
            break;
          case 4:
            int num5 = intList5[random.Next(intList5.Count)];
            stringBuilder.Append(string.Format("sh-{0}-{1}.", (object) intList8[random.Next(intList8.Count)], (object) num5));
            break;
          case 5:
            int num6 = intList5[random.Next(intList5.Count)];
            stringBuilder.Append(string.Format("fa-{0}-{1}-{2}", (object) intList9[random.Next(intList9.Count)], (object) intList8[random.Next(intList8.Count)], (object) num6));
            break;
        }
      }
      return stringBuilder.ToString();
    }

    public void Sit(bool status)
    {
      if ((uint) this.listSpecificsBot.Items.Count > 0U)
        this.handler.SendToAllUsingBots(this.getUsingBots(), (System.Action<Connection>) (bot => bot.SendPacket(Outgoing.ChangePosture, (object) (status ? 1 : 0))));
      else
        this.handler.SendToAllBots((System.Action<Connection>) (bot => bot.SendPacket(Outgoing.ChangePosture, (object) (status ? 1 : 0))));
    }

    public void Snow1(bool status)
    {
      if ((uint) this.listSpecificsBot.Items.Count > 0U)
        this.handler.SendToAllUsingBots(this.getUsingBots(), (System.Action<Connection>)(bot => bot.SendPacket(Outgoing.Game2ExitGame, (object) true)));
      else
        this.handler.SendToAllBots((System.Action<Connection>)(bot => bot.SendPacket(Outgoing.Game2ExitGame, (object) true)));
    }
    public void Snow2(bool status)
    {
      if ((uint)this.listSpecificsBot.Items.Count > 0U)
                this.handler.SendToAllUsingBots(this.getUsingBots(), (System.Action<Connection>)(bot => bot.SendPacket(Outgoing.Game2QuickJoinGame)));
            else
                this.handler.SendToAllBots((System.Action<Connection>)(bot => bot.SendPacket(Outgoing.Game2QuickJoinGame)));
        }

        public void Lookfds()
    {
      if ((uint) this.listSpecificsBot.Items.Count > 0U)
        this.handler.SendToAllUsingBots(this.getUsingBots(), (System.Action<Connection>) (bot => bot.SendPacket(Outgoing.LookTo, (object) new Random().Next(0, 20), (object) new Random().Next(0, 20))));
      else
        this.handler.SendToAllBots((System.Action<Connection>) (bot => bot.SendPacket(Outgoing.LookTo, (object) new Random().Next(0, 20), (object) new Random().Next(0, 20))));
    }

    private async void SitWalkingThread()
    {
      while (this.isSitWalking)
      {
        this.Snow1(true);
        this.Snow2(true);
        await Task.Delay(10);
      }
    }

    public void SitWalking(bool status)
    {
      this.isSitWalking = status;
      if (!this.isSitWalking)
        return;
      new Thread(new ThreadStart(this.SitWalkingThread)).Start();
    }

    public void Look(bool status)
    {
      this.isLooking = status;
      if (!this.isLooking)
        return;
      new Thread(new ThreadStart(this.Looking)).Start();
    }

    public async void Looking()
    {
      while (this.isLooking)
      {
        this.Lookfds();
        await Task.Delay(500);
      }
    }

    private void button8_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.comboBox3.SelectedItem.ToString() == "")
          return;
        if (this.comboBox3.SelectedItem.ToString() == "Detener Baile")
          this.Dance(0);
        else if (this.comboBox3.SelectedItem.ToString() == "Hab-Hop")
          this.Dance(1);
        else if (this.comboBox3.SelectedItem.ToString() == "The Rollie")
          this.Dance(2);
        else if (this.comboBox3.SelectedItem.ToString() == "Duck Funk")
          this.Dance(3);
        else if (this.comboBox3.SelectedItem.ToString() == "Pogo Mogo")
          this.Dance(4);
        else
          this.Dance(1);
      }
      catch
      {
      }
    }

    private void button7_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.comboBox5.SelectedItem.ToString() == "Besar")
          this.Action(2);
        else if (this.comboBox5.SelectedItem.ToString() == "Reir")
          this.Action(3);
        else if (this.comboBox5.SelectedItem.ToString() == "Sentarse")
          this.Sit(true);
        else if (this.comboBox5.SelectedItem.ToString() == "De pie")
          this.Sit(false);
        else if (this.comboBox5.SelectedItem.ToString() == "Dormir")
        {
          this.Action(5);
        }
        else
        {
          if (!(this.comboBox5.SelectedItem.ToString() == "Saludar"))
            return;
          this.Action(1);
        }
      }
      catch
      {
      }
    }

    public void Dance(int dance)
    {
      if ((uint) this.listSpecificsBot.Items.Count > 0U)
        this.handler.SendToAllUsingBots(this.getUsingBots(), (System.Action<Connection>) (bot => bot.SendPacket(Outgoing.Dance, (object) dance)));
      else
        this.handler.SendToAllBots((System.Action<Connection>) (bot => bot.SendPacket(Outgoing.Dance, (object) dance)));
    }

    public void AutoLoadRoom(Connection connection1)
    {
      if (!this.chkLoadRoom.Checked)
        return;
      this.handler.SendToSpecificConnection(connection1, (System.Action<Connection>) (connection2 => connection2.SendPacket(Outgoing.OpenFlatConnection, (object) int.Parse(this.txtRoomId.Text), this.chkPasswordLoadRoom.Checked ? (object) this.txtLoadRoomId.Text : (object) "", (object) -1)));
    }

    private void button10_Click(object sender, EventArgs e)
    {
      try
      {
        if ((uint) this.listSpecificsBot.Items.Count > 0U)
          this.handler.SendToAllUsingBots(this.getUsingBots(), (System.Action<Connection>) (bot => bot.SendPacket(Outgoing.Sign, (object) this.comboBox4.SelectedIndex)));
        else
          this.handler.SendToAllBots((System.Action<Connection>) (bot => bot.SendPacket(Outgoing.Sign, (object) this.comboBox4.SelectedIndex)));
      }
      catch
      {
      }
    }

    private void richTextBox1_TextChanged_1(object sender, EventArgs e)
    {
      this.richTextBox1.SelectionStart = this.richTextBox1.Text.Length;
      this.richTextBox1.ScrollToCaret();
    }

    private void checkBox5_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox5.Checked)
      {
        if (this.comboBox2.Text == "")
        {
          int num = (int) MessageBox.Show("Escoge un Hotel.", "HabboBOT - Error");
          this.checkBox5.Checked = false;
        }
        else
        {
          this.client.Initialize();
          this.client.UpdateState(string.Format("Hotel: habbo{0}", this.comboBox2.SelectedItem));
          if (HabboBOT.Entities.Configuration.bots.Count < 1)
            return;
          this.UpdateRichPresence();
        }
      }
      else if (this.comboBox2.Text != "")
        this.client.Deinitialize();
    }

    private void chkLoadRoom_CheckedChanged(object sender, EventArgs e)
    {
      if (this.chkLoadRoom.Checked)
      {
        this.txtRoomId.Visible = true;
        this.txtLoadRoomId.Visible = true;
        this.chkPasswordLoadRoom.Visible = true;
      }
      else
      {
        this.txtRoomId.Visible = false;
        this.txtLoadRoomId.Visible = false;
        this.chkPasswordLoadRoom.Visible = false;
      }
    }

    private void button15_Click(object sender, EventArgs e)
    {
      if (this.listSpecificsBot.Items.Count > 0)
        this.handler.SendToAllUsingBots(this.getUsingBots(), (System.Action<Connection>) (bot => bot.SendPacket(Outgoing.RespectUser, (object) int.Parse(this.textBox6.Text))));
      else
        this.handler.SendToAllBots((System.Action<Connection>) (bot => bot.SendPacket(Outgoing.RespectUser, (object) int.Parse(this.textBox6.Text))));
    }

    private void button14_Click(object sender, EventArgs e)
    {
      if (this.listSpecificsBot.Items.Count > 0)
        this.handler.SendToAllUsingBots(this.getUsingBots(), (System.Action<Connection>) (bot => bot.SendPacket(Outgoing.RespectPet, (object) int.Parse(this.txtPetId.Text))));
      else
        this.handler.SendToAllBots((System.Action<Connection>) (bot => bot.SendPacket(Outgoing.RespectPet, (object) int.Parse(this.txtPetId.Text))));
    }

    private void button21_Click(object sender, EventArgs e)
    {
      if (this.listSpecificsBot.Items.Count > 0)
        this.handler.SendToAllUsingBots(this.getUsingBots(), (System.Action<Connection>) (bot => bot.SendPacket(Outgoing.JoinHabboGroup, (object) int.Parse(this.txtGroupId.Text))));
      else
        this.handler.SendToAllBots((System.Action<Connection>) (bot => bot.SendPacket(Outgoing.JoinHabboGroup, (object) int.Parse(this.txtGroupId.Text))));
    }

    private void sitWalking_CheckedChanged_1(object sender, EventArgs e)
    {
      if (this.sitWalking.Checked)
        this.SitWalking(true);
      else
        this.SitWalking(false);
    }

    private void checkBox3_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox3.Checked)
        this.txtApiKey.Visible = true;
      else
        this.txtApiKey.Visible = false;
    }

    private void button16_Click(object sender, EventArgs e)
    {
    }

    public void UpdateLists()
    {
      this.listBots.Columns[0].Text = string.Format("Todos ({0})", (object) this.listBots.Items.Count);
      this.listSpecificsBot.Columns[0].Text = string.Format("Especificos ({0})", (object) this.listSpecificsBot.Items.Count);
    }

    private void button24_ClickAsync(object sender, EventArgs e)
    {
      if (this.listSpecificsBot.Items.Count > 0)
        this.handler.SendToAllUsingBots(this.getUsingBots(), (System.Action<Connection>) (bot => bot.SendPacket(Outgoing.UpdateFigureData, (object) "M", (object) Form1.RandomClothes())));
      else
        this.handler.SendToAllBots((System.Action<Connection>) (bot => bot.SendPacket(Outgoing.UpdateFigureData, (object) "M", (object) Form1.RandomClothes())));
    }

    private void checkBox6_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox6.Checked)
        this.Look(true);
      else
        this.Look(false);
    }

    private void button27_Click(object sender, EventArgs e)
    {
      if ((uint) this.listSpecificsBot.Items.Count > 0U)
        this.handler.SendToAllUsingBots(this.getUsingBots(), (System.Action<Connection>) (bot => bot.SendPacket(Outgoing.RateFlat, (object) 1)));
      else
        this.handler.SendToAllBots((System.Action<Connection>) (bot => bot.SendPacket(Outgoing.RateFlat, (object) 1)));
    }

    private void btnSignature_Click(object sender, EventArgs e)
    {
      string signature = this.txtSignature.Text;
      if ((uint) this.listSpecificsBot.Items.Count > 0U)
        this.handler.SendToAllUsingBots(this.getUsingBots(), (System.Action<Connection>) (bot => bot.SendSignature(signature)));
      else
        this.handler.SendToAllBots((System.Action<Connection>) (bot => bot.SendSignature(signature)));
    }

    private void checkBox7_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox7.Checked)
        this.CountDown(true);
      else
        this.CountDown(false);
    }

    public void Action(int act)
    {
      if ((uint) this.listSpecificsBot.Items.Count > 0U)
        this.handler.SendToAllUsingBots(this.getUsingBots(), (System.Action<Connection>) (bot => bot.SendPacket(Outgoing.AvatarExpression, (object) act)));
      else
        this.handler.SendToAllBots((System.Action<Connection>) (bot => bot.SendPacket(Outgoing.AvatarExpression, (object) act)));
    }

    public async void CountDown(bool status)
    {
      int sign = 10;
      while (sign > -1)
      {
        if (!status)
          break;
        if ((uint) this.listSpecificsBot.Items.Count > 0U)
          this.handler.SendToAllUsingBots(this.getUsingBots(), (System.Action<Connection>) (bot => bot.SendPacket(Outgoing.Sign, (object) sign)));
        else
          this.handler.SendToAllBots((System.Action<Connection>) (bot => bot.SendPacket(Outgoing.Sign, (object) sign)));
        --sign;
        await Task.Delay(1000);
      }
    }

    private async void WalkRandomThread()
    {
      while (this.isWalkRandom)
      {
        this.Walk(true);
        await Task.Delay(1000);
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.btnConnection = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnActions2 = new System.Windows.Forms.Button();
            this.btnBotManager = new System.Windows.Forms.Button();
            this.btnActions = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.statusIntercept = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkTopMost = new System.Windows.Forms.CheckBox();
            this.labelMinimize = new System.Windows.Forms.Label();
            this.labelExit = new System.Windows.Forms.Label();
            this.panelActions = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnSignature = new System.Windows.Forms.Button();
            this.txtSignature = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.txtPetId = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtGroupId = new System.Windows.Forms.TextBox();
            this.button21 = new System.Windows.Forms.Button();
            this.genderBox = new System.Windows.Forms.ComboBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.button13 = new System.Windows.Forms.Button();
            this.txtFriend = new System.Windows.Forms.TextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.button10 = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.button8 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button27 = new System.Windows.Forms.Button();
            this.chkPassword = new System.Windows.Forms.CheckBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.panelConnection = new System.Windows.Forms.Panel();
            this.chkPasswordLoadRoom = new System.Windows.Forms.CheckBox();
            this.txtLoadRoomId = new System.Windows.Forms.TextBox();
            this.txtRoomId = new System.Windows.Forms.TextBox();
            this.chkLoadRoom = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.button17 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panelBotManager = new System.Windows.Forms.Panel();
            this.listSpecificsBot = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.button23 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.listBots = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.sitWalking = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.button24 = new System.Windows.Forms.Button();
            this.txtMotto = new System.Windows.Forms.TextBox();
            this.button18 = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSendGemAmount = new System.Windows.Forms.TextBox();
            this.txtSendGemUserId = new System.Windows.Forms.TextBox();
            this.button16 = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.hoursBox = new System.Windows.Forms.CheckBox();
            this.minutesBox = new System.Windows.Forms.CheckBox();
            this.secondsBox = new System.Windows.Forms.CheckBox();
            this.button19 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.timeText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.mainRoomText = new System.Windows.Forms.TextBox();
            this.targetRoom = new System.Windows.Forms.TextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.panelActions2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panelConnection.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelBotManager.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.panelActions2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnection
            // 
            this.btnConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnConnection.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnConnection.FlatAppearance.BorderSize = 0;
            this.btnConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnection.ForeColor = System.Drawing.Color.White;
            this.btnConnection.Location = new System.Drawing.Point(0, 88);
            this.btnConnection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(223, 55);
            this.btnConnection.TabIndex = 1;
            this.btnConnection.Text = "Conexiones";
            this.btnConnection.UseVisualStyleBackColor = false;
            this.btnConnection.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.panel1.Controls.Add(this.checkBox5);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnActions2);
            this.panel1.Controls.Add(this.btnBotManager);
            this.panel1.Controls.Add(this.btnActions);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnConnection);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 503);
            this.panel1.TabIndex = 5;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox5.ForeColor = System.Drawing.Color.White;
            this.checkBox5.Location = new System.Drawing.Point(123, 470);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(93, 19);
            this.checkBox5.TabIndex = 10;
            this.checkBox5.Text = "DiscordRPC";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(10, 470);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 19);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Logs";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnActions2
            // 
            this.btnActions2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnActions2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnActions2.FlatAppearance.BorderSize = 0;
            this.btnActions2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActions2.ForeColor = System.Drawing.Color.White;
            this.btnActions2.Location = new System.Drawing.Point(0, 210);
            this.btnActions2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnActions2.Name = "btnActions2";
            this.btnActions2.Size = new System.Drawing.Size(223, 55);
            this.btnActions2.TabIndex = 6;
            this.btnActions2.Text = "Acciones II";
            this.btnActions2.UseVisualStyleBackColor = false;
            this.btnActions2.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnBotManager
            // 
            this.btnBotManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnBotManager.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBotManager.FlatAppearance.BorderSize = 0;
            this.btnBotManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBotManager.ForeColor = System.Drawing.Color.White;
            this.btnBotManager.Location = new System.Drawing.Point(0, 271);
            this.btnBotManager.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBotManager.Name = "btnBotManager";
            this.btnBotManager.Size = new System.Drawing.Size(223, 55);
            this.btnBotManager.TabIndex = 4;
            this.btnBotManager.Text = "Admin. de BOTS";
            this.btnBotManager.UseVisualStyleBackColor = false;
            this.btnBotManager.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnActions
            //
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(50, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Hola, AleejkE";
            this.label3.Visible = false;
            // 
            // chkTopMost
            // 
            this.btnActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnActions.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnActions.FlatAppearance.BorderSize = 0;
            this.btnActions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActions.ForeColor = System.Drawing.Color.White;
            this.btnActions.Location = new System.Drawing.Point(0, 149);
            this.btnActions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnActions.Name = "btnActions";
            this.btnActions.Size = new System.Drawing.Size(223, 55);
            this.btnActions.TabIndex = 2;
            this.btnActions.Text = "Acciones";
            this.btnActions.UseVisualStyleBackColor = false;
            this.btnActions.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(46, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "HabboBOT";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(229, 75);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(768, 404);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.statusIntercept);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.chkTopMost);
            this.panel2.Controls.Add(this.labelMinimize);
            this.panel2.Controls.Add(this.labelExit);
            this.panel2.Location = new System.Drawing.Point(229, 6);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(768, 62);
            this.panel2.TabIndex = 7;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(173, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Conectado: 0/0";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusIntercept
            // 
            this.statusIntercept.AutoSize = true;
            this.statusIntercept.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.statusIntercept.ForeColor = System.Drawing.Color.DarkRed;
            this.statusIntercept.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            this.statusIntercept.Location = new System.Drawing.Point(514, 18);
            this.statusIntercept.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusIntercept.Name = "statusIntercept";
            this.statusIntercept.Size = new System.Drawing.Size(57, 25);
            this.statusIntercept.TabIndex = 10;
            this.statusIntercept.Text = "OFF";
            this.statusIntercept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(410, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Intercept:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkTopMost
            // 
            this.chkTopMost.AutoSize = true;
            this.chkTopMost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkTopMost.ForeColor = System.Drawing.Color.White;
            this.chkTopMost.Location = new System.Drawing.Point(13, 24);
            this.chkTopMost.Name = "chkTopMost";
            this.chkTopMost.Size = new System.Drawing.Size(99, 19);
            this.chkTopMost.TabIndex = 8;
            this.chkTopMost.Text = "Siempre Visible";
            this.chkTopMost.UseVisualStyleBackColor = true;
            this.chkTopMost.CheckedChanged += new System.EventHandler(this.chkTopMost_CheckedChanged);
            // 
            // labelMinimize
            // 
            this.labelMinimize.AutoSize = true;
            this.labelMinimize.Font = new System.Drawing.Font("Segoe UI Symbol", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelMinimize.ForeColor = System.Drawing.Color.White;
            this.labelMinimize.Location = new System.Drawing.Point(686, 0);
            this.labelMinimize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMinimize.Name = "labelMinimize";
            this.labelMinimize.Size = new System.Drawing.Size(35, 47);
            this.labelMinimize.TabIndex = 1;
            this.labelMinimize.Text = "_";
            this.labelMinimize.Click += new System.EventHandler(this.labelMinimize_Click);
            this.labelMinimize.MouseLeave += new System.EventHandler(this.MinimizeLeave);
            this.labelMinimize.MouseHover += new System.EventHandler(this.MinimizeHover);
            // 
            // labelExit
            // 
            this.labelExit.AutoSize = true;
            this.labelExit.Font = new System.Drawing.Font("Segoe UI Symbol", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelExit.ForeColor = System.Drawing.Color.White;
            this.labelExit.Location = new System.Drawing.Point(724, 8);
            this.labelExit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelExit.Name = "labelExit";
            this.labelExit.Size = new System.Drawing.Size(34, 40);
            this.labelExit.TabIndex = 0;
            this.labelExit.Text = "X";
            this.labelExit.Click += new System.EventHandler(this.labelExit_Click);
            this.labelExit.MouseLeave += new System.EventHandler(this.ExitLeave);
            this.labelExit.MouseHover += new System.EventHandler(this.ExitHover);
            // 
            // panelActions
            // 
            this.panelActions.Controls.Add(this.groupBox6);
            this.panelActions.Controls.Add(this.groupBox5);
            this.panelActions.Controls.Add(this.groupBox4);
            this.panelActions.Controls.Add(this.groupBox3);
            this.panelActions.Location = new System.Drawing.Point(425, 664);
            this.panelActions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(465, 256);
            this.panelActions.TabIndex = 8;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnSignature);
            this.groupBox6.Controls.Add(this.txtSignature);
            this.groupBox6.Controls.Add(this.textBox6);
            this.groupBox6.Controls.Add(this.button15);
            this.groupBox6.Controls.Add(this.button14);
            this.groupBox6.Controls.Add(this.txtPetId);
            this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox6.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox6.Location = new System.Drawing.Point(401, 197);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox6.Size = new System.Drawing.Size(304, 189);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Extra";
            // 
            // btnSignature
            // 
            this.btnSignature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnSignature.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSignature.FlatAppearance.BorderSize = 0;
            this.btnSignature.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignature.ForeColor = System.Drawing.Color.White;
            this.btnSignature.Location = new System.Drawing.Point(20, 135);
            this.btnSignature.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSignature.Name = "btnSignature";
            this.btnSignature.Size = new System.Drawing.Size(255, 25);
            this.btnSignature.TabIndex = 10;
            this.btnSignature.Text = "Enviar Paquete";
            this.btnSignature.UseVisualStyleBackColor = false;
            this.btnSignature.Click += new System.EventHandler(this.btnSignature_Click);
            // 
            // txtSignature
            // 
            this.txtSignature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.txtSignature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSignature.ForeColor = System.Drawing.Color.White;
            this.txtSignature.Location = new System.Drawing.Point(20, 105);
            this.txtSignature.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSignature.Name = "txtSignature";
            this.txtSignature.Size = new System.Drawing.Size(255, 23);
            this.txtSignature.TabIndex = 9;
            this.txtSignature.Text = "{out:Game2LeaveGame}";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox6.ForeColor = System.Drawing.Color.White;
            this.textBox6.Location = new System.Drawing.Point(158, 29);
            this.textBox6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(116, 23);
            this.textBox6.TabIndex = 8;
            this.textBox6.Text = "UsuarioID";
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button15.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button15.FlatAppearance.BorderSize = 0;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.ForeColor = System.Drawing.Color.White;
            this.button15.Location = new System.Drawing.Point(158, 59);
            this.button15.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(117, 25);
            this.button15.TabIndex = 7;
            this.button15.Text = "Respetar";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button14.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button14.FlatAppearance.BorderSize = 0;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.ForeColor = System.Drawing.Color.White;
            this.button14.Location = new System.Drawing.Point(20, 59);
            this.button14.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(117, 25);
            this.button14.TabIndex = 6;
            this.button14.Text = "Acariciar";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // txtPetId
            // 
            this.txtPetId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.txtPetId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPetId.ForeColor = System.Drawing.Color.White;
            this.txtPetId.Location = new System.Drawing.Point(20, 29);
            this.txtPetId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPetId.Name = "txtPetId";
            this.txtPetId.Size = new System.Drawing.Size(116, 23);
            this.txtPetId.TabIndex = 0;
            this.txtPetId.Text = "MascotaID";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtGroupId);
            this.groupBox5.Controls.Add(this.button21);
            this.groupBox5.Controls.Add(this.genderBox);
            this.groupBox5.Controls.Add(this.txtUsername);
            this.groupBox5.Controls.Add(this.button13);
            this.groupBox5.Controls.Add(this.txtFriend);
            this.groupBox5.Controls.Add(this.button11);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox5.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox5.Location = new System.Drawing.Point(16, 197);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox5.Size = new System.Drawing.Size(317, 189);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Otros";
            // 
            // txtGroupId
            // 
            this.txtGroupId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.txtGroupId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGroupId.ForeColor = System.Drawing.Color.White;
            this.txtGroupId.Location = new System.Drawing.Point(186, 30);
            this.txtGroupId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtGroupId.Name = "txtGroupId";
            this.txtGroupId.Size = new System.Drawing.Size(123, 23);
            this.txtGroupId.TabIndex = 17;
            this.txtGroupId.Text = "GrupoID";
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button21.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button21.FlatAppearance.BorderSize = 0;
            this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button21.ForeColor = System.Drawing.Color.White;
            this.button21.Location = new System.Drawing.Point(186, 59);
            this.button21.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(123, 25);
            this.button21.TabIndex = 16;
            this.button21.Text = "Entrar a Grupo";
            this.button21.UseVisualStyleBackColor = false;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // genderBox
            // 
            this.genderBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genderBox.FormattingEnabled = true;
            this.genderBox.Items.AddRange(new object[] {
            "F",
            "M"});
            this.genderBox.Location = new System.Drawing.Point(142, 115);
            this.genderBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.genderBox.Name = "genderBox";
            this.genderBox.Size = new System.Drawing.Size(43, 23);
            this.genderBox.TabIndex = 15;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.ForeColor = System.Drawing.SystemColors.Window;
            this.txtUsername.Location = new System.Drawing.Point(13, 115);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(127, 23);
            this.txtUsername.TabIndex = 14;
            this.txtUsername.Text = "NickUsuario";
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button13.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button13.FlatAppearance.BorderSize = 0;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.ForeColor = System.Drawing.Color.White;
            this.button13.Location = new System.Drawing.Point(13, 147);
            this.button13.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(157, 25);
            this.button13.TabIndex = 13;
            this.button13.Text = "Cambiar Look";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // txtFriend
            // 
            this.txtFriend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.txtFriend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFriend.ForeColor = System.Drawing.Color.White;
            this.txtFriend.Location = new System.Drawing.Point(13, 30);
            this.txtFriend.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFriend.Name = "txtFriend";
            this.txtFriend.Size = new System.Drawing.Size(157, 23);
            this.txtFriend.TabIndex = 10;
            this.txtFriend.Text = "NickUsuario";
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button11.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button11.FlatAppearance.BorderSize = 0;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(13, 59);
            this.button11.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(157, 25);
            this.button11.TabIndex = 9;
            this.button11.Text = "Enviar Soli. Amistad";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBox5);
            this.groupBox4.Controls.Add(this.button7);
            this.groupBox4.Controls.Add(this.comboBox4);
            this.groupBox4.Controls.Add(this.button10);
            this.groupBox4.Controls.Add(this.comboBox3);
            this.groupBox4.Controls.Add(this.button8);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Location = new System.Drawing.Point(401, 16);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox4.Size = new System.Drawing.Size(304, 162);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Acciones";
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "Besar",
            "Reir",
            "Sentarse",
            "Dormir",
            "Saludar"});
            this.comboBox5.Location = new System.Drawing.Point(112, 74);
            this.comboBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(80, 23);
            this.comboBox5.TabIndex = 20;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(7, 72);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(110, 25);
            this.button7.TabIndex = 19;
            this.button7.Text = "Accion";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "Corazon",
            "Calavera",
            "Exclamacion ",
            "Pelota",
            ":)",
            "Tarjeta Roja",
            "Tarjeta Amarilla"});
            this.comboBox4.Location = new System.Drawing.Point(112, 118);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(80, 23);
            this.comboBox4.TabIndex = 18;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button10.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(7, 117);
            this.button10.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(104, 25);
            this.button10.TabIndex = 17;
            this.button10.Text = "Signos";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Duck Funk",
            "Hab-Hop",
            "Pogo Mogo",
            "The Rollie",
            "Detener Baile"});
            this.comboBox3.Location = new System.Drawing.Point(111, 29);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(80, 23);
            this.comboBox3.TabIndex = 16;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button8.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(6, 28);
            this.button8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(110, 25);
            this.button8.TabIndex = 6;
            this.button8.Text = "Bailes";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button27);
            this.groupBox3.Controls.Add(this.chkPassword);
            this.groupBox3.Controls.Add(this.textBox9);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.txtPassword);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Location = new System.Drawing.Point(16, 16);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(317, 162);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Salas";
            // 
            // button27
            // 
            this.button27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button27.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button27.FlatAppearance.BorderSize = 0;
            this.button27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button27.ForeColor = System.Drawing.Color.White;
            this.button27.Location = new System.Drawing.Point(140, 110);
            this.button27.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(162, 25);
            this.button27.TabIndex = 13;
            this.button27.Text = "Dar Me Gusta";
            this.button27.UseVisualStyleBackColor = false;
            this.button27.Click += new System.EventHandler(this.button27_Click);
            // 
            // chkPassword
            // 
            this.chkPassword.AutoSize = true;
            this.chkPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkPassword.ForeColor = System.Drawing.Color.White;
            this.chkPassword.Location = new System.Drawing.Point(136, 62);
            this.chkPassword.Name = "chkPassword";
            this.chkPassword.Size = new System.Drawing.Size(73, 19);
            this.chkPassword.TabIndex = 12;
            this.chkPassword.Text = "Clave";
            this.chkPassword.UseVisualStyleBackColor = true;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox9.ForeColor = System.Drawing.Color.White;
            this.textBox9.Location = new System.Drawing.Point(7, 29);
            this.textBox9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(116, 23);
            this.textBox9.TabIndex = 11;
            this.textBox9.Text = "ID";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(7, 90);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(116, 25);
            this.button4.TabIndex = 6;
            this.button4.Text = "Salir de Sala";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.ForeColor = System.Drawing.SystemColors.Menu;
            this.txtPassword.Location = new System.Drawing.Point(128, 30);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(92, 23);
            this.txtPassword.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(7, 59);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 25);
            this.button3.TabIndex = 5;
            this.button3.Text = "Cargar la Sala";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // panelConnection
            // 
            this.panelConnection.Controls.Add(this.chkPasswordLoadRoom);
            this.panelConnection.Controls.Add(this.txtLoadRoomId);
            this.panelConnection.Controls.Add(this.txtRoomId);
            this.panelConnection.Controls.Add(this.chkLoadRoom);
            this.panelConnection.Controls.Add(this.groupBox8);
            this.panelConnection.Controls.Add(this.groupBox7);
            this.panelConnection.Location = new System.Drawing.Point(252, 987);
            this.panelConnection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelConnection.Name = "panelConnection";
            this.panelConnection.Size = new System.Drawing.Size(271, 94);
            this.panelConnection.TabIndex = 0;
            // 
            // chkPasswordLoadRoom
            // 
            this.chkPasswordLoadRoom.AutoSize = true;
            this.chkPasswordLoadRoom.ForeColor = System.Drawing.Color.White;
            this.chkPasswordLoadRoom.Location = new System.Drawing.Point(670, 297);
            this.chkPasswordLoadRoom.Name = "chkPasswordLoadRoom";
            this.chkPasswordLoadRoom.Size = new System.Drawing.Size(76, 19);
            this.chkPasswordLoadRoom.TabIndex = 11;
            this.chkPasswordLoadRoom.Text = "Clave";
            this.chkPasswordLoadRoom.UseVisualStyleBackColor = true;
            // 
            // txtLoadRoomId
            // 
            this.txtLoadRoomId.Location = new System.Drawing.Point(668, 268);
            this.txtLoadRoomId.Name = "txtLoadRoomId";
            this.txtLoadRoomId.Size = new System.Drawing.Size(78, 23);
            this.txtLoadRoomId.TabIndex = 10;
            this.txtLoadRoomId.Text = "Clave";
            // 
            // txtRoomId
            // 
            this.txtRoomId.Location = new System.Drawing.Point(533, 268);
            this.txtRoomId.Name = "txtRoomId";
            this.txtRoomId.Size = new System.Drawing.Size(129, 23);
            this.txtRoomId.TabIndex = 9;
            this.txtRoomId.Text = "ID";
            // 
            // chkLoadRoom
            // 
            this.chkLoadRoom.AutoSize = true;
            this.chkLoadRoom.ForeColor = System.Drawing.Color.White;
            this.chkLoadRoom.Location = new System.Drawing.Point(533, 247);
            this.chkLoadRoom.Name = "chkLoadRoom";
            this.chkLoadRoom.Size = new System.Drawing.Size(118, 19);
            this.chkLoadRoom.TabIndex = 8;
            this.chkLoadRoom.Text = "Auto-Cargar Sala";
            this.chkLoadRoom.UseVisualStyleBackColor = true;
            this.chkLoadRoom.CheckedChanged += new System.EventHandler(this.chkLoadRoom_CheckedChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.comboBox2);
            this.groupBox8.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox8.Location = new System.Drawing.Point(533, 118);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox8.Size = new System.Drawing.Size(203, 123);
            this.groupBox8.TabIndex = 7;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Hotel";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            ".com.br",
            ".com",
            ".fr",
            ".de",
            ".it",
            ".es",
            ".nl",
            ".fi"});
            this.comboBox2.Location = new System.Drawing.Point(35, 51);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(140, 23);
            this.comboBox2.TabIndex = 0;
            this.comboBox2.Tag = "?";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtApiKey);
            this.groupBox7.Controls.Add(this.checkBox3);
            this.groupBox7.Controls.Add(this.button17);
            this.groupBox7.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox7.Location = new System.Drawing.Point(52, 63);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox7.Size = new System.Drawing.Size(463, 255);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Conexion";
            // 
            // txtApiKey
            // 
            this.txtApiKey.Location = new System.Drawing.Point(81, 57);
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.Size = new System.Drawing.Size(287, 23);
            this.txtApiKey.TabIndex = 7;
            this.txtApiKey.Text = "API Key";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(187, 86);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(76, 19);
            this.checkBox3.TabIndex = 6;
            this.checkBox3.Text = "2Captcha";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button17.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button17.FlatAppearance.BorderSize = 0;
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button17.ForeColor = System.Drawing.Color.White;
            this.button17.Location = new System.Drawing.Point(81, 111);
            this.button17.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(287, 55);
            this.button17.TabIndex = 5;
            this.button17.Text = "Intercept";
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.button17_ClickAsync);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Location = new System.Drawing.Point(994, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(260, 498);
            this.panel4.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 495);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Logs";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(7, 15);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBox1.Size = new System.Drawing.Size(247, 478);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged_1);
            // 
            // panelBotManager
            // 
            this.panelBotManager.Controls.Add(this.listSpecificsBot);
            this.panelBotManager.Controls.Add(this.button23);
            this.panelBotManager.Controls.Add(this.button22);
            this.panelBotManager.Controls.Add(this.button20);
            this.panelBotManager.Controls.Add(this.listBots);
            this.panelBotManager.Location = new System.Drawing.Point(1020, 622);
            this.panelBotManager.Name = "panelBotManager";
            this.panelBotManager.Size = new System.Drawing.Size(763, 399);
            this.panelBotManager.TabIndex = 12;
            // 
            // listSpecificsBot
            // 
            this.listSpecificsBot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.listSpecificsBot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listSpecificsBot.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listSpecificsBot.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listSpecificsBot.ForeColor = System.Drawing.Color.White;
            this.listSpecificsBot.HideSelection = false;
            this.listSpecificsBot.Location = new System.Drawing.Point(498, 21);
            this.listSpecificsBot.Name = "listSpecificsBot";
            this.listSpecificsBot.Size = new System.Drawing.Size(143, 366);
            this.listSpecificsBot.TabIndex = 26;
            this.listSpecificsBot.UseCompatibleStateImageBehavior = false;
            this.listSpecificsBot.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Specific";
            this.columnHeader2.Width = 130;
            // 
            // button23
            // 
            this.button23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button23.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button23.FlatAppearance.BorderSize = 0;
            this.button23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button23.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button23.ForeColor = System.Drawing.Color.White;
            this.button23.Location = new System.Drawing.Point(288, 247);
            this.button23.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(159, 51);
            this.button23.TabIndex = 9;
            this.button23.Text = "<<";
            this.button23.UseVisualStyleBackColor = false;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button22.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button22.FlatAppearance.BorderSize = 0;
            this.button22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button22.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button22.ForeColor = System.Drawing.Color.White;
            this.button22.Location = new System.Drawing.Point(288, 87);
            this.button22.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(159, 51);
            this.button22.TabIndex = 8;
            this.button22.Text = ">";
            this.button22.UseVisualStyleBackColor = false;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button20.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button20.FlatAppearance.BorderSize = 0;
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button20.ForeColor = System.Drawing.Color.White;
            this.button20.Location = new System.Drawing.Point(288, 141);
            this.button20.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(159, 51);
            this.button20.TabIndex = 7;
            this.button20.Text = "<";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // listBots
            // 
            this.listBots.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.listBots.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBots.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listBots.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBots.ForeColor = System.Drawing.Color.White;
            this.listBots.HideSelection = false;
            this.listBots.Location = new System.Drawing.Point(73, 21);
            this.listBots.Name = "listBots";
            this.listBots.Size = new System.Drawing.Size(143, 366);
            this.listBots.TabIndex = 25;
            this.listBots.UseCompatibleStateImageBehavior = false;
            this.listBots.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Todos";
            this.columnHeader1.Width = 130;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.sitWalking);
            this.groupBox10.Controls.Add(this.checkBox2);
            this.groupBox10.Controls.Add(this.textBox10);
            this.groupBox10.Controls.Add(this.textBox8);
            this.groupBox10.Controls.Add(this.button9);
            this.groupBox10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox10.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox10.Location = new System.Drawing.Point(41, 33);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox10.Size = new System.Drawing.Size(317, 162);
            this.groupBox10.TabIndex = 11;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Caminar";
            // 
            // sitWalking
            // 
            this.sitWalking.AutoSize = true;
            this.sitWalking.Location = new System.Drawing.Point(223, 22);
            this.sitWalking.Name = "sitWalking";
            this.sitWalking.Size = new System.Drawing.Size(87, 19);
            this.sitWalking.TabIndex = 26;
            this.sitWalking.Text = "SnowBlock";
            this.sitWalking.UseVisualStyleBackColor = true;
            this.sitWalking.CheckedChanged += new System.EventHandler(this.sitWalking_CheckedChanged_1);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(106, 54);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(86, 19);
            this.checkBox2.TabIndex = 24;
            this.checkBox2.Text = "Usar Cordenadas";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(150, 25);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(43, 23);
            this.textBox10.TabIndex = 23;
            this.textBox10.Text = "Y";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(106, 25);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(44, 23);
            this.textBox8.TabIndex = 22;
            this.textBox8.Text = "X";
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button9.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(20, 100);
            this.button9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(272, 32);
            this.button9.TabIndex = 21;
            this.button9.Text = "Caminar";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(7, 22);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(74, 19);
            this.checkBox4.TabIndex = 25;
            this.checkBox4.Text = "Anti-AFK";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.checkBox7);
            this.groupBox9.Controls.Add(this.checkBox6);
            this.groupBox9.Controls.Add(this.button24);
            this.groupBox9.Controls.Add(this.checkBox4);
            this.groupBox9.Controls.Add(this.txtMotto);
            this.groupBox9.Controls.Add(this.button18);
            this.groupBox9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox9.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox9.Location = new System.Drawing.Point(426, 33);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox9.Size = new System.Drawing.Size(304, 162);
            this.groupBox9.TabIndex = 12;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Acciones";
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(7, 68);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(89, 19);
            this.checkBox7.TabIndex = 27;
            this.checkBox7.Text = "Conteo";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(7, 43);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(60, 19);
            this.checkBox6.TabIndex = 26;
            this.checkBox6.Text = "Rotar";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // button24
            // 
            this.button24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button24.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button24.FlatAppearance.BorderSize = 0;
            this.button24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button24.ForeColor = System.Drawing.Color.White;
            this.button24.Location = new System.Drawing.Point(43, 106);
            this.button24.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(222, 31);
            this.button24.TabIndex = 14;
            this.button24.Text = "Ropa Aleatoria";
            this.button24.UseVisualStyleBackColor = false;
            this.button24.Click += new System.EventHandler(this.button24_ClickAsync);
            // 
            // txtMotto
            // 
            this.txtMotto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.txtMotto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMotto.ForeColor = System.Drawing.Color.White;
            this.txtMotto.Location = new System.Drawing.Point(108, 26);
            this.txtMotto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMotto.Name = "txtMotto";
            this.txtMotto.Size = new System.Drawing.Size(157, 23);
            this.txtMotto.TabIndex = 13;
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button18.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button18.FlatAppearance.BorderSize = 0;
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.ForeColor = System.Drawing.Color.White;
            this.button18.Location = new System.Drawing.Point(108, 54);
            this.button18.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(157, 25);
            this.button18.TabIndex = 12;
            this.button18.Text = "Cambiar Mision";
            this.button18.UseVisualStyleBackColor = false;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.label11);
            this.groupBox11.Controls.Add(this.label10);
            this.groupBox11.Controls.Add(this.txtSendGemAmount);
            this.groupBox11.Controls.Add(this.txtSendGemUserId);
            this.groupBox11.Controls.Add(this.button16);
            this.groupBox11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox11.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox11.Location = new System.Drawing.Point(41, 221);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox11.Size = new System.Drawing.Size(317, 175);
            this.groupBox11.TabIndex = 13;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Gemas";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(171, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 15);
            this.label11.TabIndex = 18;
            this.label11.Text = "Cantidad de Gemas";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 15);
            this.label10.TabIndex = 17;
            this.label10.Text = "ID de Usuario";
            // 
            // txtSendGemAmount
            // 
            this.txtSendGemAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.txtSendGemAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSendGemAmount.ForeColor = System.Drawing.Color.White;
            this.txtSendGemAmount.Location = new System.Drawing.Point(171, 60);
            this.txtSendGemAmount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSendGemAmount.Name = "txtSendGemAmount";
            this.txtSendGemAmount.Size = new System.Drawing.Size(123, 23);
            this.txtSendGemAmount.TabIndex = 16;
            // 
            // txtSendGemUserId
            // 
            this.txtSendGemUserId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.txtSendGemUserId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSendGemUserId.ForeColor = System.Drawing.Color.White;
            this.txtSendGemUserId.Location = new System.Drawing.Point(24, 60);
            this.txtSendGemUserId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSendGemUserId.Name = "txtSendGemUserId";
            this.txtSendGemUserId.Size = new System.Drawing.Size(123, 23);
            this.txtSendGemUserId.TabIndex = 15;
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button16.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button16.FlatAppearance.BorderSize = 0;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.ForeColor = System.Drawing.Color.White;
            this.button16.Location = new System.Drawing.Point(22, 102);
            this.button16.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(272, 25);
            this.button16.TabIndex = 14;
            this.button16.Text = "Enviar Gemas";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.hoursBox);
            this.groupBox12.Controls.Add(this.minutesBox);
            this.groupBox12.Controls.Add(this.secondsBox);
            this.groupBox12.Controls.Add(this.button19);
            this.groupBox12.Controls.Add(this.label9);
            this.groupBox12.Controls.Add(this.timeText);
            this.groupBox12.Controls.Add(this.label8);
            this.groupBox12.Controls.Add(this.label7);
            this.groupBox12.Controls.Add(this.mainRoomText);
            this.groupBox12.Controls.Add(this.targetRoom);
            this.groupBox12.Controls.Add(this.button12);
            this.groupBox12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox12.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox12.Location = new System.Drawing.Point(426, 222);
            this.groupBox12.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox12.Size = new System.Drawing.Size(304, 174);
            this.groupBox12.TabIndex = 14;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Programar";
            // 
            // hoursBox
            // 
            this.hoursBox.AutoSize = true;
            this.hoursBox.Location = new System.Drawing.Point(158, 123);
            this.hoursBox.Name = "hoursBox";
            this.hoursBox.Size = new System.Drawing.Size(58, 19);
            this.hoursBox.TabIndex = 33;
            this.hoursBox.Text = "Horas";
            this.hoursBox.UseVisualStyleBackColor = true;
            // 
            // minutesBox
            // 
            this.minutesBox.AutoSize = true;
            this.minutesBox.Location = new System.Drawing.Point(83, 123);
            this.minutesBox.Name = "minutesBox";
            this.minutesBox.Size = new System.Drawing.Size(69, 19);
            this.minutesBox.TabIndex = 32;
            this.minutesBox.Text = "Minutos";
            this.minutesBox.UseVisualStyleBackColor = true;
            // 
            // secondsBox
            // 
            this.secondsBox.AutoSize = true;
            this.secondsBox.Location = new System.Drawing.Point(7, 123);
            this.secondsBox.Name = "secondsBox";
            this.secondsBox.Size = new System.Drawing.Size(70, 19);
            this.secondsBox.TabIndex = 31;
            this.secondsBox.Text = "Segundos";
            this.secondsBox.UseVisualStyleBackColor = true;
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button19.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button19.FlatAppearance.BorderSize = 0;
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.ForeColor = System.Drawing.Color.White;
            this.button19.Location = new System.Drawing.Point(269, 11);
            this.button19.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(35, 35);
            this.button19.TabIndex = 30;
            this.button19.Text = "?";
            this.button19.UseVisualStyleBackColor = false;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 15);
            this.label9.TabIndex = 29;
            this.label9.Text = "Tiempo";
            // 
            // timeText
            // 
            this.timeText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.timeText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timeText.ForeColor = System.Drawing.Color.White;
            this.timeText.Location = new System.Drawing.Point(19, 92);
            this.timeText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.timeText.Name = "timeText";
            this.timeText.Size = new System.Drawing.Size(98, 23);
            this.timeText.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(131, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "Sala Objetivo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "Sala Principal";
            // 
            // mainRoomText
            // 
            this.mainRoomText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.mainRoomText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainRoomText.ForeColor = System.Drawing.Color.White;
            this.mainRoomText.Location = new System.Drawing.Point(19, 39);
            this.mainRoomText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.mainRoomText.Name = "mainRoomText";
            this.mainRoomText.Size = new System.Drawing.Size(98, 23);
            this.mainRoomText.TabIndex = 15;
            // 
            // targetRoom
            // 
            this.targetRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.targetRoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.targetRoom.ForeColor = System.Drawing.Color.White;
            this.targetRoom.Location = new System.Drawing.Point(125, 39);
            this.targetRoom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.targetRoom.Name = "targetRoom";
            this.targetRoom.Size = new System.Drawing.Size(98, 23);
            this.targetRoom.TabIndex = 14;
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button12.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button12.FlatAppearance.BorderSize = 0;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.ForeColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(131, 85);
            this.button12.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(165, 32);
            this.button12.TabIndex = 12;
            this.button12.Text = "Iniciar";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // panelActions2
            // 
            this.panelActions2.Controls.Add(this.groupBox12);
            this.panelActions2.Controls.Add(this.groupBox11);
            this.panelActions2.Controls.Add(this.groupBox9);
            this.panelActions2.Controls.Add(this.groupBox10);
            this.panelActions2.Location = new System.Drawing.Point(30, 546);
            this.panelActions2.Name = "panelActions2";
            this.panelActions2.Size = new System.Drawing.Size(246, 214);
            this.panelActions2.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.panelBotManager);
            this.Controls.Add(this.panelActions2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panelConnection);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "HabboBOT";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelActions.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panelConnection.ResumeLayout(false);
            this.panelConnection.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panelBotManager.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.panelActions2.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private delegate void LogDelegate(string msg, Color color);
    }
}
