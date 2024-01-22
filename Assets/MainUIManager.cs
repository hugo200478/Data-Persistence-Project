using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    // We need a static Instnace because we want to give the variable of the Name oft the Player to
    // the other Scene
    public static MainUIManager Instance;
    public string PlayerName;
    public string PlayerNameHS;
    public int HighScore;
   
    public InputField NameInputField;

    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        LoadHighScore();
       

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int HighScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerNameHS;
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        //C:\Users\Hugo\AppData\LocalLow\DefaultCompany\SimpleBreakout
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerNameHS = data.PlayerName;
            HighScore = data.HighScore;
        }
    }


}
