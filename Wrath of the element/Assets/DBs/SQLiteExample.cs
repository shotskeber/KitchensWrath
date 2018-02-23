using UnityEngine;
using System.Collections;
using System.Data;
using Mono.Data.Sqlite;

/*public class SQLiteExample : MonoBehaviour
{
	public string lookupName;
	public string path;
	public PlayerProfile playerProfile;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.S))
		{
			SavePlayerProfile (playerProfile);
			Debug.Log ("You just saved the player profile!");
		}

		if (Input.GetKeyDown (KeyCode.L))
		{
			playerProfile = LoadPlayerProfile (lookupName);
			Debug.Log ("You just loaded the player profile!");
		}
	}

	void SavePlayerProfile (PlayerProfile profile)
	{
		var command = @"UPDATE profiles SET level = @levelValue, experience = @experienceValue WHERE display_name = @displayNameValue";

		using (var dbConnection = new SqliteConnection ("URI=file:" + Application.dataPath + path))
		{
			using (var dbCommand = dbConnection.CreateCommand ())
			{
				dbConnection.Open ();

				dbCommand.CommandText = command;

				dbCommand.Parameters.Add ("@levelValue", DbType.Int32).Value = profile.level;
				dbCommand.Parameters.Add ("@experienceValue", DbType.Single).Value = profile.experience;
				dbCommand.Parameters.Add ("@displayNameValue", DbType.String).Value = profile.displayName;

				int entries = dbCommand.ExecuteNonQuery ();

				if (entries == 0)
				{
					command = @"INSERT INTO profiles (display_name, level, experience) VALUES (@displayNameValue, @levelValue, @experienceValue)";

					dbCommand.CommandText = command;
					dbCommand.ExecuteNonQuery ();
				}
			}
		}
	}

	PlayerProfile LoadPlayerProfile (string displayName)
	{
		var command = @"SELECT * FROM profiles WHERE display_name = @displayNameValue";
		var profile = new PlayerProfile ();

		using (var dbConnection = new SqliteConnection ("URI=file:" + Application.dataPath + path))
		{
			using (var dbCommand = dbConnection.CreateCommand ())
			{
				dbConnection.Open ();

				dbCommand.CommandText = command;

				dbCommand.Parameters.Add ("@displayNameValue", DbType.String).Value = displayName;

				using (var dbReader = dbCommand.ExecuteReader ())
				{
					while (dbReader.Read ())
					{
						if (dbReader.GetValue (0) != null)
						{
							profile.displayName = dbReader.GetString (0);
							profile.level = dbReader.GetInt32 (1);
							profile.experience = dbReader.GetFloat (2);
						}
					}
				}
			}
		}
		return profile;
	}
}
*/
