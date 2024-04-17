using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace HabboBOT.Entities.API
{
  internal class HabboApi
  {
    public static async Task<string> GetFigureString(string username)
    {
      string figureString = "";
      try
      {
        using (HttpClient wc = new HttpClient())
        {
          wc.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36 OPR/98.0.0.0");
          string data = await wc.GetStringAsync(Configuration.ApiUrl + "/users?name=" + username);
          figureString = data != "" ? JsonConvert.DeserializeObject<PropertyHabbo>(data).FigureString : "tnc";
          data = (string) null;
        }
      }
      catch
      {
      }
      string str = figureString;
      figureString = (string) null;
      return str;
    }
  }
}
