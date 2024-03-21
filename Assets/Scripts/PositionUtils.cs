using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionUtils
{
    public static Vector3 ClampXPosition(Vector3 position, float xmin, float xmax)
    {
        float newX = Mathf.Clamp(position.x, xmin, xmax);
        position = new Vector3(newX, position.y, position.z);
        return position;
    }
}
