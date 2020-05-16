using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            WinManager.instance.diamondsCounter += 1;
            Debug.Log("Picking up diamond");
            Debug.Log(WinManager.instance.diamondsCounter);
            WinManager.instance.CheckWin();
        }
        if(other.gameObject.CompareTag("Water") || other.gameObject.CompareTag("Enemy"))
        {
            transform.position=new Vector3(-3, 2, 6);
        }
    }

}
