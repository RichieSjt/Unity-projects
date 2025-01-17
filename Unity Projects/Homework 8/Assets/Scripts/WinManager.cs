﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour{

    public bool playerWon;
    public int diamondsCounter;
    
    public static WinManager instance; 

    private void Start()
    {
        instance = this;
        playerWon = false;
        diamondsCounter = 0;
    }

    public void CheckWin()
    {
        Debug.Log("Diamonds counter: " + diamondsCounter);
        if(diamondsCounter == 3)
        {
            playerWon = true;
            WinnerTextDisplay.instance.displayMessage();
        }
    }
}
