using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionArrowBehaviour : MonoBehaviour {
    
    void Update() {

        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * 180 / Mathf.PI - 90;
        transform.localEulerAngles = Vector3.forward * angle;

    }
}
