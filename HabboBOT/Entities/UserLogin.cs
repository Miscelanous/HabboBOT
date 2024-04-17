using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using TwoCaptcha.Captcha;

namespace HabboBOT.Entities
{
  public class UserLogin
  {
    public static Form1 _main;
    public int count = 0;
    public static Handler handler;
    public bool isLogging;

    public UserLogin(Form1 form)
    {
      UserLogin._main = form;
      UserLogin.handler = new Handler(form);
    }

    public static async void Login(string token)
    {
      try
      {
        if ((uint) UserLogin._main.accounts.Count <= 0U || UserLogin._main.checkBox3.Checked || !(UserLogin._main.button17.Text == "Stop"))
          return;
        KeyValuePair<string, string> keyValuePair = UserLogin._main.accounts.First<KeyValuePair<string, string>>();
        string email = keyValuePair.Key;
        keyValuePair = UserLogin._main.accounts.First<KeyValuePair<string, string>>();
        string password = keyValuePair.Value;
        string auth = "{\"captchaToken\":\"" + token + "\",\"email\":\"" + email + "\",\"password\":\"" + password + "\"}";
        using (HttpClient client = new HttpClient())
        {
          client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36 OPR/98.0.0.0");
          client.DefaultRequestHeaders.Add("Host", Configuration.Host);
          client.DefaultRequestHeaders.Add("Origin", Configuration.Origin);
          client.DefaultRequestHeaders.Add("Referer", Configuration.Referer);
          HttpResponseMessage authenticationResponse = await client.PostAsync(Configuration.loginUrl, (HttpContent) new StringContent(auth, Encoding.UTF8, "application/json"));
          if (authenticationResponse.StatusCode == HttpStatusCode.OK)
          {
            HttpResponseMessage clientResponse = await client.PostAsync(Configuration.clientUrl, (HttpContent) new StringContent(""));
            if (clientResponse.StatusCode == HttpStatusCode.OK)
            {
              ++Handler.Id;
              string body = await client.GetStringAsync("https://" + Configuration.Host + "/api/ssoToken");
              SSOToken data = JsonConvert.DeserializeObject<SSOToken>(body);
              Connection connection = new Connection(data.ssoToken, Handler.Id);
              UserLogin.handler.StartConnection(connection);
              if (UserLogin._main.accounts.Count >= 1)
              {
                Dictionary<string, string> accounts = UserLogin._main.accounts;
                keyValuePair = UserLogin._main.accounts.First<KeyValuePair<string, string>>();
                string key = keyValuePair.Key;
                accounts.Remove(key);
              }
              body = (string) null;
              data = (SSOToken) null;
              connection = (Connection) null;
            }
            clientResponse = (HttpResponseMessage) null;
          }
          else
          {
            string str = await authenticationResponse.Content.ReadAsStringAsync();
            string message = JsonConvert.DeserializeObject<LoginError>(str).message;
            str = (string) null;
            if (message == "login.invalid_password")
              UserLogin._main.LogError(string.Format("[BOT {0}] Invalid Account.", (object) Handler.Id));
            else
              UserLogin._main.LogError(string.Format("[BOT {0}] Error: {1}", (object) Handler.Id, (object) message));
            if (UserLogin._main.accounts.Count >= 1)
            {
              Dictionary<string, string> accounts = UserLogin._main.accounts;
              keyValuePair = UserLogin._main.accounts.First<KeyValuePair<string, string>>();
              string key = keyValuePair.Key;
              accounts.Remove(key);
            }
            message = (string) null;
          }
          authenticationResponse = (HttpResponseMessage) null;
        }
        email = (string) null;
        password = (string) null;
        auth = (string) null;
      }
      catch
      {
      }
    }

    public async void Login2Captcha(string key)
    {
      try
      {
        HCaptcha hCaptcha = new HCaptcha();
        if ((uint) UserLogin._main.accounts.Count > 0U)
        {
          string[] strArray = File.ReadAllLines("cuentas.txt");
          for (int index = 0; index < strArray.Length; ++index)
          {
            string account = strArray[index];
            string email = account.Split(':')[0];
            string password = account.Split(':')[1];
            if (UserLogin._main.button17.Text == "Stop")
            {
              TwoCaptcha.TwoCaptcha solver = new TwoCaptcha.TwoCaptcha(Configuration.ApiKey);
              hCaptcha.SetSiteKey(key);
              hCaptcha.SetUrl(Configuration.ApiUrl + "/captcha");
              await solver.Solve((TwoCaptcha.Captcha.Captcha) hCaptcha);
              string code = hCaptcha.Code;
              string auth = "{\"captchaToken\":\"" + code + "\",\"email\":\"" + email + "\",\"password\":\"" + password + "\"}";
              using (HttpClient client = new HttpClient())
              {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36 OPR/98.0.0.0");
                client.DefaultRequestHeaders.Add("Host", Configuration.Host);
                client.DefaultRequestHeaders.Add("Origin", Configuration.Origin);
                client.DefaultRequestHeaders.Add("Referer", Configuration.Referer);
                HttpResponseMessage authenticationResponse = await client.PostAsync(Configuration.loginUrl, (HttpContent) new StringContent(auth, Encoding.UTF8, "application/json"));
                if (authenticationResponse.StatusCode == HttpStatusCode.OK)
                {
                  HttpResponseMessage clientResponse = await client.PostAsync(Configuration.clientUrl, (HttpContent) new StringContent(""));
                  if (clientResponse.StatusCode == HttpStatusCode.OK)
                  {
                    ++Handler.Id;
                    string body = await client.GetStringAsync("https://" + Configuration.Host + "/api/ssoToken");
                    SSOToken data = JsonConvert.DeserializeObject<SSOToken>(body);
                    Connection connection = new Connection(data.ssoToken, Handler.Id);
                    UserLogin.handler.StartConnection(connection);
                    body = (string) null;
                    data = (SSOToken) null;
                    connection = (Connection) null;
                  }
                  clientResponse = (HttpResponseMessage) null;
                }
                this.RemoveAccount();
                authenticationResponse = (HttpResponseMessage) null;
              }
              solver = (TwoCaptcha.TwoCaptcha) null;
              code = (string) null;
              auth = (string) null;
            }
            email = (string) null;
            password = (string) null;
            account = (string) null;
          }
          strArray = (string[]) null;
        }
        hCaptcha = (HCaptcha) null;
      }
      catch
      {
      }
    }

    private void RemoveAccount()
    {
      if (UserLogin._main.accounts.Count < 1)
        return;
      UserLogin._main.accounts.Remove(UserLogin._main.accounts.First<KeyValuePair<string, string>>().Key);
    }
  }
}
