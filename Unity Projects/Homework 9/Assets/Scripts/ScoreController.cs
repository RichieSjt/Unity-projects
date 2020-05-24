using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;
    public Text[] scoreLabels;

    public static int currentScore;
    public int bestScore;

    private void Start()
    {
        instance = this;
        scoreLabels = GetComponentsInChildren<Text>();
        CompareScores();
    }

    void Update(){
        scoreLabels[0].text = "Score: " + currentScore;
    }

    public void IncrementScore()
    {
        currentScore += 1;
        if(currentScore % 5 == 0)
        {
            BoardController.instance.height += 1;
            BoardController.instance.width += 1;

            int height = BoardController.instance.height;
            int width = BoardController.instance.width;
            
            DestroyPreviousBoard();
            BoardController.instance.GenerateBoard(height,width);
        }
        else
        {
            int height = BoardController.instance.height;
            int width = BoardController.instance.width;

            DestroyPreviousBoard();
            BoardController.instance.GenerateBoard(height,width);
        }
    }

    public void CompareScores(){
        if(currentScore >= bestScore)
        {
            bestScore = currentScore;
        }
        currentScore = 0;
        scoreLabels[1].text = "Best score: " + bestScore;
    }
    
    public void DestroyPreviousBoard(){
        GameObject[] des = GameObject.FindGameObjectsWithTag("Tile");
        foreach (var tile in des)
        {
            Destroy(tile);
        }
    }
    
}
