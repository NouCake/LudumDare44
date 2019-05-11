using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    public float Speed = 1;
    public float RotSpeed = 180;
    public float ShootSpeed = 10;
    public float ShotsPerSecond = 5;
    private float timer;

    public Transform ship;
    private Rigidbody body;
    public GameObject shoot;

    void Start() {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKey(KeyCode.A)) {
            ship.transform.localEulerAngles += Vector3.up * RotSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) {
            ship.transform.localEulerAngles -= Vector3.up * RotSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space)) {
            body.velocity = ship.transform.forward * Speed;
        } else {
            body.velocity = Vector3.zero;
        }


        if (Input.GetKey(KeyCode.Return)) {
            if(timer > 0) {
                timer -= Time.deltaTime;
            } else {
                GameObject shot = Instantiate(shoot);
                shot.transform.position = transform.position;
                shot.GetComponent<Rigidbody>().velocity = ship.forward * ShootSpeed;
                timer = 1 / ShotsPerSecond;
            }
        }
    }
}
