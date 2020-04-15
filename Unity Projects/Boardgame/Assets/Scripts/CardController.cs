using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour{
    public GameManagerController manager; 
    public SpriteRenderer spriteRenderer;
    public Sprite front;
    public Sprite back;
    public int spriteIndex;

    public bool isShowingFront = false;

    void Start(){
        
    }
    void Update(){
        Debug.Log("Cards up: " + manager.cardsUp);
    }
    private void OnMouseDown() {
        if (isShowingFront)
            ShowBack();
        else
            ShowFront();
    }

    public void ShowFront() {
        spriteRenderer.sprite = front;
        isShowingFront = true;
        manager.cardsUp++;
    }
    public void ShowBack() {
        spriteRenderer.sprite = back;
        isShowingFront = false;
        manager.cardsUp--;
    }
}
