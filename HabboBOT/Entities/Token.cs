using WebSocketSharp;
using WebSocketSharp.Server;

namespace HabboBOT.Entities
{
  public class Token : WebSocketBehavior
  {
    public class ReceiveTokenService : WebSocketBehavior
    {
      protected override void OnMessage(MessageEventArgs e) => UserLogin.Login(e.Data);
    }
  }
}
