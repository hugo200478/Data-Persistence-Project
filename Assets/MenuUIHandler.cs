using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{

    private string input;
    public InputField NameInputField;
    public Text BestScore;
    public Text ErrorText;


    // Start is called before the first frame update
    void Start()
    {
        NameInputField.text = MainUIManager.Instance.PlayerName;
        BestScore.text = "Best Score: " + MainUIManager.Instance.PlayerNameHS + " :" + MainUIManager.Instance.HighScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {

        if (NameInputField.text == "")
        {
            ErrorText.text = "Der Name fehlt!";
        }else
        {
            //NameInputField.text = MainUIManager.Instance.PlayerName;
           
            if (input == null)
            {
                input = NameInputField.text;
                SceneManager.LoadScene(1);
                MainUIManager.Instance.PlayerName = input;
            }else
            {
                SceneManager.LoadScene(1);
                MainUIManager.Instance.PlayerName = input;
            }
            ErrorText.text = "";

        }
    }
    public void ReadStringInput(string s)
    {
        MainUIManager.Instance.PlayerName = s;
        input = s;
        ErrorText.text = "";
        //Debug.Log(input);
    }

    public void Exit()
    {
        //Save HighScore before exit
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
  
}
