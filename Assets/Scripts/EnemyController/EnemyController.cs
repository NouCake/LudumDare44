using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharController {

    protected override void init() {
        BaseStats = new Stats(4, 4);
    }

    protected override void ControllerUpdate() {
        //Debug.Log(body.velocity);
    }

}
