using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Gesture currentGestrue;
    public GestureDetector detector;
    public Spawner compSpawner;
    public Spawner playerSpawner;
    public Text scoreText;
    public Text gameText;
    public GameObject Player1;
    public GameObject Player2;
    private float counter = 0;
    private (int, int, int) score = (0, 0, 0); //wins, losses, ties
    private bool gameGoing = false;
    private Gesture playerGesture;
    private int winner; //0 = player 1 = comp 2 = tie

    public void setGesture()
    {
        currentGestrue = detector.previousGesture;
    }

    public void StartCountdown()
    {
        counter = 3;
        gameGoing = true;
    }

    public void Update()
    {
        if (counter > 0 && gameGoing)
        {
            counter -= Time.deltaTime;
            gameText.text = Math.Round(counter).ToString();

        }
        else if(counter <= 0 && gameGoing)
        {
            gameGoing = false;
            gameText.text = "Go";
            playerGesture = detector.previousGesture;
            CheckWinner();
        }
    }

    private void CheckWinner()
    {
        winner = 0;
        var compGesture = detector.gestures[UnityEngine.Random.Range(0, 2)];
        Debug.Log($"You: {playerGesture.name}, Comp: {compGesture.name}");
        switch (playerGesture.name)
        {
            case "Rock":
                playerSpawner.Spawn(0);
                break;
            case "Paper":
                playerSpawner.Spawn(1);
                break;
            case "Scissors":
                playerSpawner.Spawn(2);
                break;
        }
        switch (compGesture.name)
        {
            case "Rock":
                compSpawner.Spawn(0);
                switch (playerGesture.name)
                {
                    case "Paper":
                        winner = 0;
                        break;
                    case "Scissors":
                        winner = 1;
                        break;
                    case "Rock":
                        winner = 2;
                        break;
                }
                break;
            case "Paper":
                compSpawner.Spawn(1);
                switch (playerGesture.name)
                {
                    case "Paper":
                        winner = 2;
                        break;
                    case "Scissors":
                        winner = 0;
                        break;
                    case "Rock":
                        winner = 1;
                        break;
                }
                break;
            case "Scissors":
                compSpawner.Spawn(2);
                switch (playerGesture.name)
                {
                    case "Paper":
                        winner = 1;
                        break;
                    case "Scissors":
                        winner = 2;
                        break;
                    case "Rock":
                        winner = 0;
                        break;
                }
                break;
        }
        switch (winner)
        {
            case 0: //player wins
                score.Item1++;
                gameText.text = $"You Win!! You: {playerGesture.name} Comp: {compGesture.name}";
                scoreText.text = $"Score: W - {score.Item1} L - {score.Item2} T - {score.Item3}";
                Player1.tag = "Winner";
                Player2.tag = "Loser";
                break;
            case 1:
                score.Item2++;
                gameText.text = $"You Lose! You: {playerGesture.name} Comp: {compGesture.name}";
                scoreText.text = $"Score: W - {score.Item1} L - {score.Item2} T - {score.Item3}";
                Player2.tag = "Winner";
                Player1.tag = "Loser";
                break;
            case 2:
                score.Item3++;
                gameText.text = $"Tie! You both played: {playerGesture.name}";
                scoreText.text = $"Score: W - {score.Item1} L - {score.Item2} T - {score.Item3}";
                break;
        }
    }
}
