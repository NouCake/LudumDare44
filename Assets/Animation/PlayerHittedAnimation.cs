using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHittedAnimation : MonoBehaviour {

    public Color col1;
    public Color col2;

    private Color colBase;
    private Color colNone;
    public SpriteRenderer ren;

    public float tick = 0.2f;
    public int blinks = 3;
    private int bl = 0;
    private float timer;
    private bool running;

    private void Start() {
        colBase = ren.color;
        colNone = new Color(colBase.r, colBase.g, colBase.b, 0);
        running = false;
    }

    private void Update() {
        if (running) {

            int last = (int)(timer / tick);
            timer += Time.deltaTime;
            int cur = (int)(timer / tick);
            if (last != cur)
            {
                switch (cur)
                {
                    case 1:
                        frame1();
                        break;
                    case 2:
                        frame2();
                        break;
                    case 3:
                        frame3();
                        break;
                    case 4:
                        frame4();
                        break;
                    case 5:
                        frame3();
                        timer -= 2 * tick;
                        bl++;
                        if (bl > blinks) running = false;
                        //running = false;
                        break;
                }
            }
        }

    }

    public void StartAnimation() {
        timer = 0.1f;
        running = true;
        bl = 0;
    }

    private void frame1() {
        ren.color = col1;
    }

    private void frame2() {
        ren.color = col2;
    }

    private void frame3() {
        ren.color = colBase;
    }

    private void frame4() {
        ren.color = colNone;
    }

}
