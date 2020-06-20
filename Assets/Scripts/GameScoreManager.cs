using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScoreManager : MonoBehaviour
{ 
    public int Score = 0;
    public int Miss = 0; 
    public Action incrementScore;
    public Action incrementMiss;

    public TextMeshPro Scoreboard;
    // Start is called before the first frame update
    void Start()
    {
        incrementScore = HandleIncrementScore;
        incrementMiss = HandleIncrementMiss;
    }

    // Update is called once per frame
    void Update()
    {
        Scoreboard.SetText(string.Format("Score: {0}", Score));
    }


    public void HandleIncrementScore() {
        Score += 1;
    }

    public void HandleIncrementMiss() {
        Miss += 1;
    }
}
