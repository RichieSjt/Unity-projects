using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlBoyColorChanger : MonoBehaviour{
    private SpriteRenderer spriteRenderer;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update(){
        
    }

    public void ChangeToRed(){
        spriteRenderer.color = Color.red;
    }

    public void ChangeToWhite(){
        spriteRenderer.color = Color.white;
    }
}
