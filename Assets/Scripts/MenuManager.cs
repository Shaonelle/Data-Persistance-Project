using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public TMP_InputField inputField;
    public TMP_Text bestResultText;
    public string playerName;

    private string bestPlayerName;
    private int bestScore;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadBestResult();
        bestResultText.text = $"Best Score : {bestPlayerName} : {bestScore}";
    }
    public void GetPlayerName()
    {
        playerName = inputField.text;
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayerName;
        public int bestScore;
    }
    private void LoadBestResult()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.bestPlayerName;
            bestScore = data.bestScore;
        }
    }
}
