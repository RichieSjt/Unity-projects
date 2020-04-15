using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour{
    
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private bool isRunning;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update(){
        if(Input.GetKeyUp(KeyCode.Space)){
            isRunning = !isRunning;
            anim.speed = isRunning ? 1 : 0;
            if(!isRunning){
                Debug.Log("Stopped at: " + spriteRenderer.sprite.name);
            }
        }
    }

}
