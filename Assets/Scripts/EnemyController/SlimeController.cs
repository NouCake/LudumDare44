using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : CharController {

    protected override void init() {
        BaseStats = new Stats(8, 5);
    }

}
