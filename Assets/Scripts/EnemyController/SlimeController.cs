using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : CharController {

    protected override void init() {
        stats = new CharStats(5, 4, 4);
    }

}
