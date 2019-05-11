using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {


    private Transform Wall_L;
    private Transform Wall_R;
    private Transform Wall_F;
    private Transform Wall_B;
    private Transform Roof;

    void Start() {
        Wall_L = transform.Find("Wall_L");
        Wall_R = transform.Find("Wall_R");
        Wall_F = transform.Find("Wall_F");
        Wall_B = transform.Find("Wall_B");
        Roof = transform.Find("Roof");
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerStay(Collider other) {
        Debug.Log("Hello World!");
        if(other.tag == "Player")
        {
            Wall_F.gameObject.SetActive(false);
            Roof.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Wall_F.gameObject.SetActive(true);
        Roof.gameObject.SetActive(true);
    }
}
