using UnityEngine;

public class MyUtility {
    
    public static Vector2 GetAxisOriented(Vector2 dir) {
        if(dir.x * dir.x > dir.y * dir.y) {
            dir.y = 0;
            dir.x = dir.x > 0 ? 1 : -1;
        } else {
            dir.x = 0;
            dir.y = dir.y > 0 ? 1 : -1;
        }

        return dir;
    }

    public static int GetAxisOrientedAngle(Vector2 dir) {
        if (dir.x * dir.x > dir.y * dir.y) {
            return dir.x > 0 ? -90 : 90;
        } else {
            return dir.y > 0 ? 0 : 180;
        }
    }

}
