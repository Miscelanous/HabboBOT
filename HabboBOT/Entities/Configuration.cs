using System.Collections.Generic;

namespace HabboBOT.Entities
{
  internal class Configuration
  {
    public static string webSocketUrl;
    public static string loginUrl;
    public static string clientUrl;
    public static string Host;
    public static string Origin;
    public static string Referer;
    public static string Username;
    public static string Password;
    public static string ApiUrl;
    public static string lastHotel;
    public static string ApiKey;
    public static string logs;
    public static bool isAdmin;
    public static bool VERIFY_HWID = false;
    public static List<Connection> bots = new List<Connection>();
    public static string VERSION = "1.2"; // Actual version del programa
    public static string DownloadUrl = "https://raw.githubusercontent.com/zzdubstepzz/release/main/version?v=" + Configuration.VERSION; // Version en Internet, indica cuando hay una nueva release. (Original: https://github.com/zzdubstepzz/release/blob/main/version)
    public static string Production = "WIN63-202304181922-68514878"; // Actual Production/AIR dedicado y usandose.
  }
}
