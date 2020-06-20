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

    public cubeSpawner cubeSpawner;
    // Start is called before the first frame update
    void Start()
    {
        incrementScore = HandleIncrementScore;
        incrementMiss = HandleIncrementMiss;

        //Fetch the AudioSource from the GameObject
        GetComponent<AudioSource>().Stop();
        //Ensure the toggle is set to true for the music to play at start-up
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

    public void startGame() {
        GetComponent<AudioSource>().Play();
        cubeSpawner.gameActive = true;
    }

    public void pauseGame() {
        GetComponent<AudioSource>().Pause();
        cubeSpawner.gameActive = false;
    }

    public void unpauseGame() {
        GetComponent<AudioSource>().UnPause();
        cubeSpawner.gameActive = true;
    }

    public void stopGame() {
        GetComponent<AudioSource>().Stop();
        cubeSpawner.gameActive = false;
    }
}
