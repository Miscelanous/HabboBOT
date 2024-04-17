using System.IO;
using Newtonsoft.Json;

internal class Cache
{
	private static dynamic jsonLoaded = JsonConvert.DeserializeObject(File.ReadAllText("cache.json"));

	public static void Update(string key, string new_value)
	{
		jsonLoaded[key] = new_value;
		string contents = JsonConvert.SerializeObject(jsonLoaded, (Formatting)1);
		File.WriteAllText("cache.json", contents);
	}

	public static string Get(string key)
	{
		return jsonLoaded[key];
	}
}