using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Item"))
        {
            WinManager.instance.diamondsCounter += 1;
            WinManager.instance.CheckWin();
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Water") || other.gameObject.CompareTag("Enemy"))
        {
            transform.position=new Vector3(-3, 2, 6);
        }
    }

}
