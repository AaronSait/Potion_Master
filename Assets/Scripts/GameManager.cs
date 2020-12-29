using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text ScoreText;
    public Text TimerText;

    private float timer = 240f;
    private int points = 0; public int getPoint() { return points; } public void addToPoints(int p) { points += p; }
    private int numberOfHappyCustomers = 0; public int getNoHappyCust() { return numberOfHappyCustomers; } public void addToHappyCust(int p) { numberOfHappyCustomers += p; }
    private int numberOfSadCustomers = 0; public int getNoSadCust() { return numberOfHappyCustomers; } public void addToSadCust(int p) { numberOfSadCustomers += p; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        ScoreText.text = "" + points;
        TimerText.text = "" + (int)timer;

        if (timer <= 0f)
        {
            if (PlayerPrefs.GetInt("HighScore", 0) < points)
            {
                PlayerPrefs.SetInt("HighScore", points);
                //PlayerPrefs.SetInt("JA", 1);
            }
            else
            {
                //PlayerPrefs.SetInt("JA", 0);
            }
            SceneManager.LoadScene(0);
        }
    }
}
