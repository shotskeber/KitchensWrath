using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class SQLunlock : MonoBehaviour
{

    int challengeId = 17;
    public Sprite[] skins;
    public GameObject challengeSprite;

    void Start()
    {
        skins = Resources.LoadAll<Sprite>("UI/challenges/unlocked");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            UnlockChallenge(challengeId);
            Debug.Log("You unlocked challenge: " + challengeId);
        }
    }

    public void UnlockChallenge(int idChallenge)
    {
        for (int e = 0; e < skins.Length; e++)
        {
            if (skins[e].name == idChallenge.ToString())
            {
                GameObject temp = Instantiate(challengeSprite, new Vector3(0f, 8f, 0f), Quaternion.identity);
                temp.GetComponent<SpriteRenderer>().sprite = skins[e];
                break;
            }
        }
        var command = @"UPDATE challenges SET finished = 1 WHERE id = @idChallenge";

        using (var dbConnection = new SqliteConnection("URI=file:" + Application.dataPath + "/StreamingAssets/main.db"))
        {
            using (var dbCommand = dbConnection.CreateCommand())
            {
                dbConnection.Open();

                dbCommand.CommandText = command;

                dbCommand.Parameters.Add("@idChallenge", DbType.Int32).Value = idChallenge;
                int entries = dbCommand.ExecuteNonQuery();
                UnlockSkin(idChallenge+4);

            }
        }
    }

    void UnlockSkin(int idSkin)
    {
        var command = @"UPDATE skins SET unlocked = 1 WHERE idSkin = @idSkin";

        using (var dbConnection = new SqliteConnection("URI=file:" + Application.dataPath + "/StreamingAssets/main.db"))
        {
            using (var dbCommand = dbConnection.CreateCommand())
            {
                dbConnection.Open();

                dbCommand.CommandText = command;

                dbCommand.Parameters.Add("@idSkin", DbType.Int32).Value = idSkin;
                int entries = dbCommand.ExecuteNonQuery();

            }
        }
    }

    
}