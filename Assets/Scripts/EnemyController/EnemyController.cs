using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharController {

    public Vector2 EnemyStats = Vector2.zero;
    private AttackBehaviour attack;

    protected override void init() {
        BaseStats = new Stats((int)EnemyStats.x, (int)EnemyStats.y);
        attack = GetComponent<AttackBehaviour>();
    }

}
