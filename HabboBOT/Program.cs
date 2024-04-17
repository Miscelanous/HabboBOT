using HabboBOT.Entities;
using HabboBOT.Entities.Auth;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HabboBOT
{
  internal static class Program
  {
    [STAThread]
    public static async Task Main()
    {
      Application.Run((Form)new Form1());
     // Program.CreatePath("cache.json", "{\n  \"username\": \"\",\n  \"password\": \"\",\n  \"hotel\": \".es\",\n  \"logs\": true,\n  \"topmost\": false,\n  \"api_key\": \"\",\n  \"autoloadroom_id\": 0\n}");
      Program.CreatePath("cuentas.txt", "email:password");
      Application.SetHighDpiMode(HighDpiMode.SystemAware);
      Application.EnableVisualStyles();
            Application.Run((Form)new Form1());
            Application.SetCompatibleTextRenderingDefault(false);
        }

    private static void CreatePath(string path, string template)
    {
      if (!File.Exists(path))
      {
        File.Create(path).Close();
        File.WriteAllText(path, template);
      }
      if (!(File.ReadAllText(path) == ""))
        return;
      File.WriteAllText(path, template);
    }
  }
}
