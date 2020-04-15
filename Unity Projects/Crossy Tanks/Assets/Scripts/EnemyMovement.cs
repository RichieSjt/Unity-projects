using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour{
    public bool MovesRight = true;
    private float direction;

    void Start(){
        if(MovesRight)
            direction = 0.1f * 0.2f;
        else
            direction = -0.1f * 0.2f;
    }

    void Update(){
        gameObject.transform.Translate(new Vector3(direction, 0, 0));
    }
    
}
