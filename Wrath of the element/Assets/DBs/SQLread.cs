using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;


public class SQLread : MonoBehaviour {

	public List<SkinProfile> skins = new List<SkinProfile> ();
	public List<ChallengeProfile> challenges = new List<ChallengeProfile> ();
	public List<StatsProfile> stats = new List<StatsProfile>();

    void FixedUpdate ()
	{
		skins = LoadSkins ();
		challenges = LoadChallenges ();
		stats = LoadStats ();
	}

	List<SkinProfile> LoadSkins ()
	{
		skins.Clear ();
		var command = @"SELECT * FROM skins ORDER BY idSkin";
		var profile = new SkinProfile ();

		using (var dbConnection = new SqliteConnection ("URI=file:" + Application.dataPath + "/DBs/main.db"))
		{
			using (var dbCommand = dbConnection.CreateCommand ())
			{
				dbConnection.Open ();

				dbCommand.CommandText = command;

				using (var dbReader = dbCommand.ExecuteReader ())
				{
					while (dbReader.Read ())
					{
						if (dbReader.GetValue (0) != null)
						{
							var skin = new SkinProfile ();
							skin.idSkin = dbReader.GetInt32(0);
							skin.unlocked = dbReader.GetInt32  (3);

							skins.Add (skin);
						}
					}
				}
			}
		}
		return skins;
	}
	List<ChallengeProfile> LoadChallenges ()
	{
		challenges.Clear ();
		var command = @"SELECT * FROM challenges ORDER BY id";
		var profile = new ChallengeProfile ();

		using (var dbConnection = new SqliteConnection ("URI=file:" + Application.dataPath + "/DBs/main.db"))
		{
			using (var dbCommand = dbConnection.CreateCommand ())
			{
				dbConnection.Open ();

				dbCommand.CommandText = command;

				using (var dbReader = dbCommand.ExecuteReader ())
				{
					while (dbReader.Read ())
					{
						if (dbReader.GetValue (0) != null)
						{
							var challenge = new ChallengeProfile ();
							challenge.id = dbReader.GetInt32(0);
							challenge.desc = dbReader.GetString (1);
							challenge.type = dbReader.GetString (2);
							challenge.finished = dbReader.GetInt32  (3);

							challenges.Add (challenge);
						}
					}
				}
			}
		}
		return challenges;
	}
	List<StatsProfile> LoadStats ()
	{
		stats.Clear ();
		var command = @"SELECT * FROM pstats ORDER BY playerId";
		var profile = new StatsProfile ();

		using (var dbConnection = new SqliteConnection ("URI=file:" + Application.dataPath + "/DBs/main.db"))
		{
			using (var dbCommand = dbConnection.CreateCommand ())
			{
				dbConnection.Open ();

				dbCommand.CommandText = command;

				using (var dbReader = dbCommand.ExecuteReader ())
				{
					while (dbReader.Read ())
					{
						if (dbReader.GetValue (0) != null)
						{
							var stat = new StatsProfile ();
							stat.playerId = dbReader.GetInt32(0);
							stat.matchesWon = dbReader.GetInt32(1);
							stat.gamesFinished = dbReader.GetInt32(2);
							stat.survivedWind = dbReader.GetInt32(3);
							stat.surviveFire = dbReader.GetInt32(4);
							stat.survivedMeat = dbReader.GetInt32(5);
							stat.dashes = dbReader.GetInt32(6);
							stat.dashHit = dbReader.GetInt32(7);
							stat.saltCarry = dbReader.GetInt32(8);

							stats.Add (stat);
						}
					}
				}
			}
		}
		return stats;
	}

}
