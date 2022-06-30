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
    public float deLimiter = 1;
    [SerializeField]
    public GameObject shot;
    public List<GameObject> shotsList;
    public Transform localSpawn;
    public float maxDis = 10;
    public float forceMult = 40;
    public Transform mouseSim; 

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        mouseSim.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        Vector2 baseToMouse;
        baseToMouse = mouseSim.position;
        Handles.color = Color.green;

        //Normalize vector by dividing by magnitude.
        Handles.DrawLine(player.position, baseToMouse / baseToMouse.magnitude);
        Handles.color = Color.yellow;
        Handles.DrawLine(getSpawnPoint(baseToMouse), baseToMouse / baseToMouse.magnitude * deNormalizer);
    }

    private void Update()
    {
        Vector2 baseToMouse = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        if (Input.GetMouseButtonDown(0))
        {
            shotsList.Add(shootShot(baseToMouse/baseToMouse.magnitude * deLimiter, getSpawnPoint(baseToMouse)));
        }
    }

    private Vector2 getSpawnPoint(Vector2 vec){
        Vector2 point;
        point = vec / vec.magnitude;
        return point;
    }
    private GameObject shootShot(Vector2 force, Vector2 spawnPoint){
        localSpawn.position = spawnPoint;
        //GameObject thisShot = Instantiate(shot, new Vector3(Camera.main.ScreenToWorldPoint(spawnPoint).x, Camera.main.ScreenToWorldPoint(spawnPoint).y, 0), Quaternion.identity);
        GameObject thisShot = Instantiate(shot, spawnPoint, Quaternion.identity);
        thisShot.GetComponent<Rigidbody2D>().AddForce(force*forceMult);
        return thisShot;
    }
#endif
}
