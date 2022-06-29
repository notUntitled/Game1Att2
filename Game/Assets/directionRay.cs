using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class directionRay : MonoBehaviour
{
    public Transform player;
    private Vector3 mousePosition;
    public float deNormalizer = 1;
    public GameObject shot;
    public List<GameObject> shotsList;
    public Transform localSpawn;
    public float maxDis = 10;
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Vector2 baseToMouse;
        baseToMouse = Input.mousePosition;
        Handles.color = Color.green;

        //Normalize vector by dividing by magnitude.
        Handles.DrawLine(player.position, baseToMouse / baseToMouse.magnitude);
        Handles.color = Color.red;
        Handles.DrawLine(getSpawnPoint(baseToMouse), baseToMouse / baseToMouse.magnitude * deNormalizer);

        if (Input.GetMouseButtonDown(0))
        {
            shotsList.Add(shootShot(mousePosition, getSpawnPoint(baseToMouse)));
        }
    }

    private Vector2 getSpawnPoint(Vector2 vec){
        Vector2 point;
        point = vec / vec.magnitude;
        return point;
    }
    private GameObject shootShot(Vector2 mousePos, Vector2 spawnPoint){
        localSpawn.position = spawnPoint;
        GameObject thisShot = Instantiate(shot, localSpawn);
        Vector2.MoveTowards(thisShot.transform.position, mousePos, maxDis);
        return thisShot;
    }
#endif
}
