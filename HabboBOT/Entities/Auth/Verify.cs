using HabboBOT.Entities.API;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HabboBOT.Entities.Auth
{
  internal class Verify
  {
    private static async Task<string> DataFromUser(string username, string password)
    {
      string str;
      using (HttpClient client = new HttpClient())
      {
        client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36 OPR/98.0.0.0");
        Dictionary<string, string> dataCred = new Dictionary<string, string>()
        {
          {
            nameof (username),
            username
          },
          {
            nameof (password),
            password
          }
        };
        HttpResponseMessage postRequest = await client.PostAsync("https://w3.inverse.cl/api/auth", (HttpContent) new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>) dataCred)); // Original : https://lbotsv3-dubszera.vercel.app/api/auth
                string Body = await postRequest.Content.ReadAsStringAsync();
        str = Body;
      }
      return str;
    }

    public static async Task<bool> UserExpired(string username, string password)
    {
      string src = await Verify.DataFromUser(username, password);
      bool expired = JsonConvert.DeserializeObject<JsonFR>(src).expired;
      src = (string) null;
      return expired;
    }

    public static async Task<bool> userExists(string username, string password)
    {
      string src = await Verify.DataFromUser(username, password);
      bool success = JsonConvert.DeserializeObject<JsonFR>(src).success;
      src = (string) null;
      return success;
    }

    public static async Task<bool> isAdmin(string username, string password)
    {
      string src = await Verify.DataFromUser(username, password);
      bool isAdmin = JsonConvert.DeserializeObject<JsonFR>(src).isAdmin;
      src = (string) null;
      return isAdmin;
    }

    public static async Task<bool> VerifyHWID(string username, string password)
    {
      if (!Configuration.VERIFY_HWID)
        return false;
      string src = await Verify.DataFromUser(username, password);
      JsonFR data = JsonConvert.DeserializeObject<JsonFR>(src);
      if (data.hwid != "")
        return GetInfo.GetHWID() != data.hwid;
      HttpClient client = new HttpClient();
      string json = "{\"admin_login\": { \"username\": \"marc\", \"password\": \"123456\" }, \"username\": username,  \"user_data\": { \"hwid\": " + GetInfo.GetHWID() + " } }";
      HttpResponseMessage httpResponseMessage = await client.PutAsync("https://w3.inverse.cl/api/auth", (HttpContent) new StringContent(json)); // Original : https://lbotsv3-dubszera.vercel.app/api/auth
            return false;
    }
  }
}
