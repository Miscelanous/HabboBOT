using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HabboBOT;
using HabboBOT.Entities;

public class Handler
{
	public Form1 _main;

	public bool isWalkRandom;

	public bool isAntiAfk;

	public bool isSitWalking;

	public static int Id;

	public Handler(Form1 main)
	{
		_main = main;
	}

	public void StartConnection(Connection Connection)
	{
		Connection.OnConnectionStarted += delegate
		{
			Configuration.bots.Add(Connection);
			_main.LogSucess($"[BOT {Id}] Conectado.");
			_main.label4.Invoke((Action)delegate
			{
				_main.label4.Text = string.Format("Conectado: {0}/{1}", Configuration.bots.Count, File.ReadAllLines("cuentas.txt").Length);
			});
			_main.Invoke((Action)delegate
			{
				_main.AddBotToList(Id);
			});
			_main.Invoke((Action)delegate
			{
				_main.UpdateRichPresence();
			});
			_main.Invoke((Action)delegate
			{
				_main.UpdateLists();
			});
			if (_main.chkLoadRoom.Checked)
			{
				_main.Invoke((Action)delegate
				{
					_main.AutoLoadRoom(Connection);
				});
			}
		};
		Connection.OnConnectionStopped += delegate
		{
			Id--;
			Configuration.bots.Remove(Connection);
			_main.LogError($"[BOT {Id} Desconectado.");
			_main.label4.Invoke((Action)delegate
			{
				_main.label4.Text = string.Format("Conectado: {0}/{1}", Configuration.bots.Count, File.ReadAllLines("cuentas.txt").Length);
			});
			_main.Invoke((Action)delegate
			{
				_main.RemoveBotFromList(Id);
			});
			_main.Invoke((Action)delegate
			{
				_main.UpdateRichPresence();
			});
			_main.Invoke((Action)delegate
			{
				_main.UpdateLists();
			});
		};
		Connection.Connect();
	}

	public void SendToAllBots(Action<Connection> callback)
	{
		foreach (Connection item in Configuration.bots.Where((Connection bot) => bot.isConnected))
		{
			callback(item);
		}
	}

	public void SendToAllUsingBots(List<int> ids, Action<Connection> callback)
	{
		foreach (Connection item in from bot in Configuration.bots
									select (bot) into bot
									where ids.Contains(bot.id)
									select bot)
		{
			callback(item);
		}
	}

	public void SendToSpecificConnection(Connection connection, Action<Connection> conn)
	{
		conn(connection);
	}
}
