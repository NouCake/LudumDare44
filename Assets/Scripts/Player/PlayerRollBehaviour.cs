using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollBehaviour : MonoBehaviour {

    public float RollTime = 0.5f;
    public float RollDistance = 2;
    public float RollCooldown = 0.75f;

    private float timer;
    private float cooldownTimer;

    private PlayerController controller;
    private PlayerAttackBehaviour attack;
    private SpriteRenderer sprIdle;
    private SpriteRenderer sprRoll;

    void Start() {
        controller = GetComponent<PlayerController>();
        attack = GetComponent<PlayerAttackBehaviour>();
        sprIdle = transform.Find("spr_player").GetComponent<SpriteRenderer>();
        sprRoll = transform.Find("spr_player_rolling").GetComponent<SpriteRenderer>();
        sprRoll.gameObject.SetActive(false);
    }
    
    void Update() {
        
        if(cooldownTimer > 0) {
            cooldownTimer -= Time.deltaTime;
        }

        if(timer > 0) {
            timer -= Time.deltaTime;
            if(timer <= 0) {
                onRollEnd();
            }
        }

        if (canRoll() && Input.GetKeyDown(KeyCode.Space)) {
            onRollStart();
        }

    }
    
    private bool canRoll() {
        return !attack.isAttacking() && cooldownTimer <= 0;
    }

    private void onRollStart() {
        controller.DmgBehav.SetInvincible(RollTime);
        controller.KnockBehav.CustomKnockback(controller.movement.direction, 2, RollTime, RollTime);
        sprRoll.gameObject.SetActive(true);
        sprIdle.gameObject.SetActive(false);
        timer = RollTime;
        cooldownTimer = RollCooldown;
    }

    private void onRollEnd() {
        sprRoll.gameObject.SetActive(false);
        sprIdle.gameObject.SetActive(true);
    }

    public bool isRolling() {
        return timer > 0;
    }

}
