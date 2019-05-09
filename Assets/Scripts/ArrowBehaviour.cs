using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour {

    //public float ShotSpeed = 5.0f;
    public float Lifespan = 3.0f;
    private Rigidbody2D body;
    private DamageableInformation info;

    private void Start() {
        body = GetComponent<Rigidbody2D>();
        Debug.Log("Hello my body is " + body);
    }

    public void Shoot(CharController cha, Vector2 direction, float ShotSpeed) {
        GetComponent<Rigidbody2D>().velocity = direction * ShotSpeed;
        transform.localEulerAngles = Vector3.forward * (Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI - 90);
        info = new DamageableInformation(cha, transform, cha.TotalStats);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "damageable") {
            CharController cha = collision.GetComponentInParent<CharController>();
            if (cha == null) {
                Debug.Log(collision.name + " does not have CharController");
                return;
            }
            if (transform.tag == cha.tag) return;
            DealDamage(cha);
        }
    }

    private void DealDamage(CharController other) {
        other.DmgBehav.DealPhysicalDamage(info);
        gameObject.SetActive(false);
    }

}
