using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerTextDisplay : MonoBehaviour{
    
    public static WinnerTextDisplay instance;
    public Text winnerMsg;

    private void Start() {
        instance = this;
        winnerMsg = GetComponent<Text>();
    }

    public void displayMessage(){
        winnerMsg.enabled = true;
    }
}
