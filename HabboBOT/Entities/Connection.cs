using HabboBOT.Entities.Headers;
using Sulakore.Cryptography;
using Sulakore.Cryptography.Ciphers;
using Sulakore.Network;
using Sulakore.Network.Protocol;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HabboBOT.Entities
{
  public class Connection
  {
    public Random _random;
    private readonly HKeyExchange _keyExchange;
    private HNode _hnode;
    public bool isConnected;
    private RC4 _crypto;
    public string _sso;
    public int id;

    public event EventHandler OnConnectionStarted;

    public event EventHandler OnConnectionStopped;

    public Connection(string sso, int idd)
    {
      this.id = idd;
      this._sso = sso;
      this._random = new Random();
      this._keyExchange = new HKeyExchange(65537, "C5DFF029848CD5CF4A84ADEFB2DA6685704920D5EBE8850B82C419A97B95302DE3B8021F37719FEBD4B3516E04D1E4702E74C468C9FF4BBBB5DD44A1E3A08687EDBEF7C30A176F7C8C83226A77F7982F7442D884D8149E924C486F43035C07B9167EA998416919DA4116D5E0598C11BA1542B4160136F04135C06EDF80170245E73C0DAD63895F52DCED3735582C5852744C8EC40AF576F26A9C8DC5B64ED3DAD40EFAAC6A76A1F5C2A422A8A4691F8991356467BDA61E1D34D0F35531058C8F741E4661ACFCB15C806A996AC312A8D33BF45079B89E11787537B37364749B883BDBFDE51A1A55086CF16159F5DEBCC76342AC2EF6950DA0C70C5845C97DFD49");
        }

        public async void Connect()
    {
      HNode hnode = await HNode.ConnectAsync(Configuration.webSocketUrl, 30000);
      this._hnode = hnode;
      hnode = (HNode) null;
      ValueTask<int> valueTask = this._hnode.SendAsync(Outgoing.ClientHello, (object) Configuration.Production, (object)"FLASH13", (object) 6, (object) 4);
      int num1 = await valueTask;
      valueTask = this._hnode.SendAsync(Outgoing.InitDiffieHandshake);
      int num2 = await valueTask;
      HPacket msg = await this._hnode.ReceiveAsync();
      this.HandlePacket(msg);
      msg = (HPacket) null;
    }

    public async void SendPacket(ushort id, params object[] values)
    {
      int num = await this._hnode.SendAsync(id, values);
    }

    public async void SendSignature(string signature)
    {
      Regex pattern = new Regex("{(?<kind>out|in):(?<value>[^}]*)\\}", RegexOptions.IgnoreCase);
      MatchCollection matches = pattern.Matches(signature);
      ushort id = 0;
      foreach (Match match in matches)
      {
        string value = match.Groups["value"].Value;
        string kind = match.Groups["kind"].Value.ToLower();
        string str = kind;
        string str1 = str;
        if (!(str1 == "out"))
        {
          if (str1 == "in")
            id = (ushort) typeof (Incoming).GetProperty(value).GetValue((object) null);
        }
        else
          id = (ushort) typeof (Outgoing).GetProperty(value).GetValue((object) null);
        str = (string) null;
        signature = signature.Replace(match.Value, string.Format("{{id:{0}}}", (object) id));
        value = (string) null;
        kind = (string) null;
      }
      if (id <= (ushort) 0 && matches.Count != 0)
      {
        pattern = (Regex) null;
        matches = (MatchCollection) null;
      }
      else
      {
        int num = await this._hnode.SendAsync((Memory<byte>) HPacket.ToBytes((HFormat) HFormat.EvaWire, signature));
        pattern = (Regex) null;
        matches = (MatchCollection) null;
      }
    }

    private async void HandlePacket(HPacket msg)
    {
      try
      {
        if (msg == null)
          return;
        if ((int) msg.Id == (int) Incoming.Ping)
        {
          int num1 = await this._hnode.SendAsync(Outgoing.Pong);
        }
        else if ((int) msg.Id == (int) Incoming.InitDiffieHandshake)
        {
          this._keyExchange.VerifyDHPrimes(msg.ReadUTF8(), msg.ReadUTF8());
          this._keyExchange.Padding = PKCSPadding.RandomByte;
          int num2 = await this._hnode.SendAsync(Outgoing.CompleteDiffieHandshake, (object) this._keyExchange.GetPublicKey());
        }
        else if ((int) msg.Id == (int) Incoming.CompleteDiffieHandshake)
        {
          this._crypto = new RC4(this._keyExchange.GetSharedKey(msg.ReadUTF8()));
          this._hnode.Encrypter = (IStreamCipher) this._crypto;
          int num3 = await this._hnode.SendAsync(Outgoing.VersionCheck, (object) 401, (object) "app://", (object) "https://www.habbo.es/gamedata/external_variables/1");
          ValueTask<int> valueTask = this._hnode.SendAsync(Outgoing.UniqueID, (object) "", (object) this.GenMID(), (object)"WIN/50,2,2,1");
          int num4 = await valueTask;
          valueTask = this._hnode.SendAsync(Outgoing.SSOTicket, (object) this._sso, (object) this._random.Next(4000, 12000));
          int num5 = await valueTask;
        }
        else if ((int) msg.Id == (int) Incoming.AuthenticationOK)
        {
          ValueTask<int> valueTask = this._hnode.SendAsync(Outgoing.GetCurrentTimingCode, (object) "2013 -05-08 13:00,gamesmaker;2013-05-11 13:00");
          int num6 = await valueTask;
          valueTask = this._hnode.SendAsync(Outgoing.GetBonusRareInfo);
          int num7 = await valueTask;
          valueTask = this._hnode.SendAsync(Outgoing.InfoRetrieve);
          int num8 = await valueTask;
          valueTask = this._hnode.SendAsync(Outgoing.EventLog, (object) "Login", (object) "socket", (object) "client.auth_ok", (object) "", (object) 0);
          int num9 = await valueTask;
          valueTask = this._hnode.SendAsync(Outgoing.GetCfhStatus);
          int num10 = await valueTask;
          valueTask = this._hnode.SendAsync(Outgoing.GetMOTD);
          int num11 = await valueTask;
          valueTask = this._hnode.SendAsync(Outgoing.MessengerInit);
          int num12 = await valueTask;
          valueTask = this._hnode.SendAsync(Outgoing.NewNavigatorInit);
          int num13 = await valueTask;
          valueTask = this._hnode.SendAsync(Outgoing.ScrGetUserInfo, (object) "habbo_club");
          int num14 = await valueTask;
          valueTask = this._hnode.SendAsync(Outgoing.GetBadgePointLimits);
          int num15 = await valueTask;
          valueTask = this._hnode.SendAsync(Outgoing.GetSoundSettings);
          int num16 = await valueTask;
          valueTask = this._hnode.SendAsync(Outgoing.GetUnreadForumsCount);
          int num17 = await valueTask;
          EventHandler connectionStarted = this.OnConnectionStarted;
          if (connectionStarted != null)
            connectionStarted((object) this, EventArgs.Empty);
          this.isConnected = true;
          connectionStarted = (EventHandler) null;
        }
        /*else if ((int)msg.Id == (int)Incoming.Game2StageLoad)
        {
          int num18 = await this._hnode.SendAsync(Outgoing.Game2LoadStageReady, (object)"100");
        }*/
                Console.WriteLine(msg.Id.ToString());
        HPacket msg1 = await this._hnode.ReceiveAsync();
        this.HandlePacket(msg1);
        msg1 = (HPacket) null;
      }
      catch
      {
        EventHandler connectionStopped = this.OnConnectionStopped;
        if (connectionStopped != null)
          connectionStopped((object) this, EventArgs.Empty);
        this.isConnected = false;
        connectionStopped = (EventHandler) null;
      }
    }

    private string GenMID(int length = 32)
    {
      using (RNGCryptoServiceProvider cryptoServiceProvider = new RNGCryptoServiceProvider())
      {
        byte[] numArray = new byte[length];
        cryptoServiceProvider.GetBytes(numArray);
        using (MD5 md5 = MD5.Create())
        {
          byte[] hash = md5.ComputeHash(numArray);
          StringBuilder stringBuilder = new StringBuilder();
          foreach (byte num in hash)
            stringBuilder.Append(num.ToString("x2"));
          return "~" + stringBuilder.ToString();
        }
      }
    }
  }
}
