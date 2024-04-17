using Microsoft.Win32;
using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace HabboBOT.Entities.API
{
  internal class GetInfo
  {
        public static string GetHabboBOTVersion()
        {
            string address = "https://raw.githubusercontent.com/zzdubstepzz/release/main/version?v=" + new Random().Next(1, 323313).ToString(); // https://raw.githubusercontent.com/zzdubstepzz/release/main/version?v= - Original

            // 1. Usar HTTPS
            //address = address.Replace("http://", "https://");

            // 2. Usar um User-Agent customizado
            using (WebClient webClient = new WebClient())
            {
                webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36 OPR/98.0.0.0");
                webClient.Headers.Add("Content-Type", "application/json");
                byte[] responseData = webClient.DownloadData(address);
                return Encoding.UTF8.GetString(responseData).Trim();
            }
        }

    public static string GetIp()
    {
      string address = "https://api.ipify.org/";
      using (WebClient webClient = new WebClient())
        return webClient.DownloadString(address).Trim();
    }

    public static string GetHWID()
    {
      string name1 = "SOFTWARE\\Microsoft\\Cryptography";
      string name2 = "MachineGuid";
      using (RegistryKey registryKey1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
      {
        using (RegistryKey registryKey2 = registryKey1.OpenSubKey(name1))
          return registryKey2.GetValue(name2).ToString();
      }
    }

    public static string GetHCaptchaKey()
    {
      string address = Configuration.ApiUrl + "/captcha";
      using (WebClient webClient = new WebClient())
      {
        webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36 OPR/98.0.0.0");
        return Regex.Match(webClient.DownloadString(address).Trim(), "<div class=\"h-captcha\" data-sitekey=\"(.+?)\"").Groups[1].Value;
      }
    }
  }
}
