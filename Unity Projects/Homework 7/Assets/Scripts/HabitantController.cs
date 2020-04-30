using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabitantController : MonoBehaviour{
    private Rigidbody2D rb;
    private Vector3 shootDirection;
    public float speed = 2f;

    public void Setup(Vector3 shootDirection){
        this.shootDirection = shootDirection;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(shootDirection * speed, ForceMode2D.Impulse);
    }

}
