using System.Collections.Generic;
using System.Net.Http;
using HabboBOT.Entities;
using HabboBOT.Entities.Headers;
using Newtonsoft.Json;

internal class SulekHeaders
{
	private static readonly string SulekApi = "https://api.sulek.dev/releases/" + Configuration.Production + "/messages";

	private static Dictionary<string, string> Outgoing = new Dictionary<string, string>();

	private static Dictionary<string, string> Incoming = new Dictionary<string, string>();

	public static async void GetHeaders(bool outgoing = false)
	{
		HttpClient client = new HttpClient();
		dynamic jsonObj = JsonConvert.DeserializeObject(await client.GetStringAsync(SulekApi));
		foreach (dynamic obj in outgoing ? jsonObj.messages.outgoing : jsonObj.messages.incoming)
		{
			string name = obj.name;
			string header = obj.id;
			if (outgoing ? (Outgoing.Count >= 1) : (Incoming.Count >= 1))
			{
				if (!(outgoing ? (!Outgoing.ContainsKey(name)) : (!Incoming.ContainsKey(name))))
				{
					continue;
				}
				if (name.EndsWith("MessageComposer"))
				{
					name = name.Replace("MessageComposer", "");
				}
				else if (name.EndsWith("Composer"))
				{
					name = name.Replace("Composer", "");
				}
				else if (name.EndsWith("Event"))
				{
					name = name.Replace("Event", "");
					if (name.EndsWith("Message"))
					{
						name = name.Replace("Message", "");
					}
				}
				if (name != "CanCreateRoom")
				{
					if (outgoing)
					{
						Outgoing.Add(name, header);
					}
					else
					{
						Incoming.Add(name, header);
					}
				}
			}
			else if (outgoing)
			{
				Outgoing.Add(name, header);
			}
			else
			{
				Incoming.Add(name, header);
			}
		}
		SaveHeaders(outgoing);
	}

	public static void SaveHeaders(bool outgoing = false)
	{
		IniFile iniFile = new IniFile("Headers.ini");
		if (outgoing)
		{
			foreach (KeyValuePair<string, string> item in Outgoing)
			{
				iniFile.Write(item.Key, item.Value, "Outgoing");
			}
			Headers.LoadOutgoing();
			return;
		}
		foreach (KeyValuePair<string, string> item2 in Incoming)
		{
			iniFile.Write(item2.Key, item2.Value, "Incoming");
		}
		Headers.LoadIncoming();
	}

	private static string GetHeaderByName(string header_name, bool isOutgoing)
	{
		return isOutgoing ? Outgoing[header_name] : Incoming[header_name];
	}

	public static ushort GetOutgoingHeaderByName(string name)
	{
		return ushort.Parse(GetHeaderByName(name, isOutgoing: true));
	}

	public static ushort GetIncomingHeaderByName(string name)
	{
		return ushort.Parse(GetHeaderByName(name, isOutgoing: false));
	}
}
