using Newtonsoft.Json;

namespace HabboBOT.Entities.API
{
  public class PropertyHabbo
  {
    [JsonProperty("figureString")]
    public string FigureString { get; set; }
  }
}
