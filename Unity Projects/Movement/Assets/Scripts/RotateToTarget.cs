using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : MonoBehaviour{

    public GameObject objectToRotate;
    public GameObject target;
    public float degreesOffset = 0;

    void Update(){
        Vector3 vectorToTarget = target.transform.position - objectToRotate.transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle + degreesOffset, objectToRotate.transform.forward);
        objectToRotate.transform.rotation = Quaternion.Slerp(objectToRotate.transform.rotation, q, Time.deltaTime * 1000);
    }

}
