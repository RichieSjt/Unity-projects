using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetManager : MonoBehaviour{
    public static bool playerLost;
    private Image reset;

    private void Start() {
        reset = GetComponent<Image>();
    }

    private void Update() {
        if(playerLost)
        {
            reset.enabled = true;
        }
    }

    public void Reset(){
        BoardController.instance.GenerateBoard(3, 3);
        BoardController.instance.counter = 0;
        reset.enabled = false;
        playerLost = false;
    }

}
