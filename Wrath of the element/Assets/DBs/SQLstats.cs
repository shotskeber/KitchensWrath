using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class SQLstats : MonoBehaviour {

    public void addMatch(float id)
    {
        var command = @"UPDATE pstats SET matchesWon = matchesWon + 1 WHERE playerId = @idPlayer";

        using (var dbConnection = new SqliteConnection("URI=file:" + Application.dataPath + "/StreamingAssets/main.db"))
        {
            using (var dbCommand = dbConnection.CreateCommand())
            {
                dbConnection.Open();

                dbCommand.CommandText = command;

                dbCommand.Parameters.Add("@idPlayer", DbType.Int32).Value = id;
                int entries = dbCommand.ExecuteNonQuery();

            }
        }
    }
    public void addGame(float id)
    {
        var command = @"UPDATE pstats SET gamesFinished = gamesFinished + 1 WHERE playerId = @idPlayer";

        using (var dbConnection = new SqliteConnection("URI=file:" + Application.dataPath + "/StreamingAssets/main.db"))
        {
            using (var dbCommand = dbConnection.CreateCommand())
            {
                dbConnection.Open();

                dbCommand.CommandText = command;

                dbCommand.Parameters.Add("@idPlayer", DbType.Int32).Value = id;
                int entries = dbCommand.ExecuteNonQuery();

            }
        }
    }
    

}
