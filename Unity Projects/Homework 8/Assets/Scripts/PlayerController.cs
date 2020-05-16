using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Item"))
        {
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Water"))
        {
            Destroy(other.gameObject);
        }
    }

}
