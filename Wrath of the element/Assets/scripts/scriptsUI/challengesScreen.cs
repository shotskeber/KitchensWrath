using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data;
using Mono.Data.Sqlite;

public class challengesScreen : MonoBehaviour {

    // Use this for initialization
    public Sprite[] skins;
    public Sprite[] skins_locked;

    public List<ChallengeProfile> skinStatus = new List<ChallengeProfile>();
    public List<GameObject> challengesSprites = new List<GameObject>();

    void Start () {
        skins = Resources.LoadAll<Sprite>("UI/challenges/unlocked");
        skins_locked = Resources.LoadAll<Sprite>("UI/challenges/locked");
        LoadSkins();
        foreach(GameObject i in challengesSprites)
        {
            if (lockCheck(float.Parse(i.name))){
                for (int e = 0; e < skins_locked.Length; e++)
                {
                    if (skins_locked[e].name == i.name)
                    {
                        i.GetComponent<Image>().sprite = skins_locked[e];
                        break;
                    }
                }
            }
            else
            {
                for (int e = 0; e < skins.Length; e++)
                {
                    if (skins[e].name == i.name)
                    {
                        i.GetComponent<Image>().sprite = skins[e];
                        break;
                    }
                }
            }
        }
    }
    List<ChallengeProfile> LoadSkins()
    {
        skinStatus.Clear();
        var command = @"SELECT * FROM challenges ORDER BY id";
        var profile = new ChallengeProfile();

        using (var dbConnection = new SqliteConnection("URI=file:" + Application.dataPath + "/StreamingAssets/main.db"))
        {
            using (var dbCommand = dbConnection.CreateCommand())
            {
                dbConnection.Open();

                dbCommand.CommandText = command;

                using (var dbReader = dbCommand.ExecuteReader())
                {
                    while (dbReader.Read())
                    {
                        if (dbReader.GetValue(0) != null)
                        {
                            var skin = new ChallengeProfile();
                            skin.id = dbReader.GetInt32(0);
                            skin.finished = dbReader.GetInt32(3);

                            skinStatus.Add(skin);
                        }
                    }
                }
            }
        }
        return skinStatus;
    }
    bool lockCheck(float id)
    {
        bool islocked = true;
        foreach (ChallengeProfile i in skinStatus)
        {
            if (i.id == id)
            {
                if (i.finished == 1)
                {
                    islocked = false;
                    break;
                }
                else
                {
                    islocked = true;
                    break;
                }
            }
        }
        return islocked;
    }
}
