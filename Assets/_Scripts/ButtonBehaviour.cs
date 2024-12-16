using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public TMP_Text debugLabel;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButtonPress()
    {
        SceneManager.LoadScene("Play");
    }

    public void OnBackToMenuButtonPress()
    {
        SceneManager.LoadScene("Menu");
    }

    // To exit the game/app
    public void OnQuitApplicationButtonPress()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_ANDROID
                System.Diagnostics.Process.GetCurrentProcess().Kill();
        #else
                Application.Quit(); 
        #endif
    }

    public void onButtonPress(string buttonType)
    {
        switch (buttonType)
        {
            case "feed":
                debugLabel.text = "Feeding!";
                break;
            case "clean":
                debugLabel.text = "Cleaning!";
                break;
            case "play":
                debugLabel.text = "Playing!";
                break;
            case "health":
                debugLabel.text = "Healthing!";
                break;
            case "poop":
                debugLabel.text = "Pooping!";
                break;
            case "read":
                debugLabel.text = "Reading!";
                break;
            default:
                break;
        }
    }
}
