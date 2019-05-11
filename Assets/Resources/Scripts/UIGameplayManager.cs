using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameplayManager : Singleton<UIGameplayManager>
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    ScoreManager mScore;

    public override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        mScore = ScoreManager.Get();
        scoreText.text = mScore.score.ToString();
        livesText.text = mScore.lives.ToString();
    }

    void Update()
    {
        setScore();
        setLives();
    }

    public void setScore()
    {
        if (scoreText.text != mScore.score.ToString())
        {
            scoreText.text = mScore.score.ToString();
        }  
    }

    public void setLives()
    {
        if (livesText.text != mScore.lives.ToString())
        {
            livesText.text = mScore.lives.ToString();
        }
    }
}
