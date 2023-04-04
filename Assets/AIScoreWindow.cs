/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIScoreWindow : MonoBehaviour
{

    private Text highscoreText;
    private Text scoreText;
    public GameObject AI;
    private void Awake()
    {
        scoreText = transform.Find("scoreText").GetComponent<Text>();
        highscoreText = transform.Find("highscoreText").GetComponent<Text>();
    }

    private void Start()
    {
        highscoreText.text = "AI HIGHSCORE: " + Score.GetHighscore().ToString();
        Bird.GetInstance().OnDied += ScoreWindow_OnDied;
        Bird.GetInstance().OnStartedPlaying += ScoreWindow_OnStartedPlaying;
        Hide();
    }

    private void ScoreWindow_OnStartedPlaying(object sender, System.EventArgs e)
    {
        Show();
    }

    private void ScoreWindow_OnDied(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void Update()
    {

        if (!AI.GetComponent<Bird2>().IsDeath)
        {
            scoreText.text = Level.GetInstance().GetPipesPassedCount().ToString();
        }
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

}
