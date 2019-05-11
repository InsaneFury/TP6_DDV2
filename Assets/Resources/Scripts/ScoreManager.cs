using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{

    public int score = 0;
    public int lives = 3;

    public override void Awake()
    {
        base.Awake();
    }

    public void AddScore(int _score)
    {
        score += _score;
    }
}
