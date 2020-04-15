using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWin : MonoBehaviour
{
    public GameObject banner;
    void Start()
    {
        banner.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D hitInfo) {
        if(hitInfo.tag == "Player") {
            banner.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
