﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepBackgroundMusic : MonoBehaviour{
    
    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

}
