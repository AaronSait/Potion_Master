using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    public bool Play, Exit, Howto, Back, MainMenu, yes, no;
    public GameObject howToPan, MainMenuPan, AreYouShorePan, hudPan;
    public Text highScore;
    // Start is called before the first frame update
    void Start()
    {
        Play = false;
        Exit = false;
        Howto = false;
        Back = false;
        MainMenu = false;
        yes = false;
        no = false;
        AreYouShorePan.SetActive(false);
        if (highScore != null)
            highScore.text = PlayerPrefs.GetInt("HighScore",0)+"";
    }

    // Update is called once per frame
    void Update()
    {
        if (Play)
        {
            SceneManager.LoadScene(1);
        }
        if (Exit)
        {
            AreYouShorePan.SetActive(true);
            if (yes)
                Application.Quit();
            else if (no)
            {
                AreYouShorePan.SetActive(false);
                no = false;
                Exit = false;
            }
        }
        if (Howto)
        {
            howToPan.SetActive(true);
            MainMenuPan.SetActive(false);
            Howto = false;
        }
        if (Back)
        {
            howToPan.SetActive(false);
            MainMenuPan.SetActive(true);
            Back = false;
        }
        if (MainMenu)
        {
            Time.timeScale = 0.0f;
            AreYouShorePan.SetActive(true);
            if (hudPan != null)
                hudPan.SetActive(false);
            if (yes)
            {
                Time.timeScale = 1.0f;
                SceneManager.LoadScene(0);
            }
            else if (no)
            {
                AreYouShorePan.SetActive(false);
                if (hudPan != null)
                    hudPan.SetActive(true);
                no = false;
                MainMenu = false;
                Time.timeScale = 1.0f;
            }
        }

    }

    public void mainMenuBtn()
    {
        MainMenu = true;
    }
    public void backBtn()
    {
        Back = true;
    }
    public void playBtn()
    {
        Play = true;
    }
    public void exitBtn()
    {
        Exit = true;
    }
    public void howToBtn()
    {
        Howto = true;
    }
    public void yesBtn()
    {
        yes = true;
    }
    public void noBtn()
    {
        no = true;
    }
}
