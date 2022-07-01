using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;
    public Color color2 = Color.red;

    private void OnDrawGizmos()
    {
        Vector2 vpoint1 = point1.position;
        Vector2 vpoint2 = point2.position;
        Vector2 vpoint3 = point3.position;
        Vector2 vpoint4 = point4.position;
        Gizmos.color = color2;
        Gizmos.DrawLine(vpoint1, vpoint2);
        Gizmos.DrawLine(vpoint2, vpoint3);
        Gizmos.DrawLine(vpoint3, vpoint4);
        Gizmos.DrawLine(vpoint4, vpoint1);
    }

    public Vector2[] getPoints()
    {
        Vector2[] arr = { point1.position, point2.position, point3.position, point4.position };
        return arr;
    }
}
