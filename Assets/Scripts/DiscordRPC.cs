// Avoxel284
// Discord RPC script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class DiscordRPC : MonoBehaviour {
	public Discord.Discord discord;

	void Start() {
		discord = new Discord.Discord(1034009159168966666, (System.UInt64)Discord.CreateFlags.Default);
		var activityManager = discord.GetActivityManager();
		var activity = new Discord.Activity {
			State = "Probably being chased by Andre",
			Assets = {
				LargeImage = "icon"
			}
		};
		activityManager.UpdateActivity(activity, (res) => {

		});
	}

	void Update() {
		discord.RunCallbacks();
	}

	void OnDisable() {
		discord.Dispose();
	}
}