using System;
using System.Collections.Generic;
using System.Net.Http;

namespace HabboBOT.Entities.API
{
  internal class Send
  {
    public static async void SendToWebHook()
    {
      using (HttpClient client = new HttpClient())
      {
        client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "");
        client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        Dictionary<string, string> bodycontent = new Dictionary<string, string>();
        string message = string.Format("```asciidoc\r\n[{0}] :: Logou no aplicativo\r\n[IP] :: {1}\r\n[Data/Hora] :: {2}\r\n[HWID] :: {3}\r\n```", (object) Configuration.Username, (object) GetInfo.GetIp(), (object) DateTime.Now.ToLocalTime(), (object) GetInfo.GetHWID());
        bodycontent.Add("content", message);
        HttpResponseMessage httpResponseMessage = await client.PostAsync("", (HttpContent) new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>) bodycontent));
        bodycontent = (Dictionary<string, string>) null;
        message = (string) null;
      }
    }
  }
}
