using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveController : MonoBehaviour{
    private Transform previousParent;

    private void OnCollisionEnter2D(Collision2D collision) {
        previousParent = collision.gameObject.transform.parent;
        collision.gameObject.transform.parent = gameObject.transform;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        collision.gameObject.transform.parent = previousParent;
    }

}
