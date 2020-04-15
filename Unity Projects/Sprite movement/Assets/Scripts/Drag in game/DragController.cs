using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour{

    bool isDragging;

    private void Update() {
        if(isDragging){
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mouseWorldPosition);
        }
    }

    private void OnMouseDown() {
        isDragging = true;
    }
    private void OnMouseUp() {
        isDragging = false;
    }

}
