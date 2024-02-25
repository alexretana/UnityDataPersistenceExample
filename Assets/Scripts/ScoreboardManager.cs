using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreboardManager : MonoBehaviour
{
    public static ScoreboardManager Instance;

    public string playerName;
    public string highScoreHolder;
    public int highScore;

    //Data Intended to Persist Sessions
    [System.Serializable]
    class HighScoreData
    {
        public string highScoreHolder;
        public int highScore;
    }

    //Singleton Behavior
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Instance.playerName = "Winner";
        LoadHighScore();
    }

    public void UpdatePlayerName(string NewName)
    {
        playerName = NewName;
    }

    public void SaveHighScore()
    {
        HighScoreData data = new HighScoreData();
        data.highScoreHolder =  highScoreHolder;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);

            highScoreHolder = data.highScoreHolder;
            highScore = data.highScore;
            highScore = data.highScore;
        }
    }
}
