﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collision");
        Destroy(transform.parent.gameObject);
    }

}
