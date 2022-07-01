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

    //Auto play
    public Vector2 thinking;
    public bool autoplay;
    public float shotTimer;
    public float tBtShots = 0.5f;

    //Manager
    public bool moving;
    void Start()
    {
        shotTimer = Time.time;
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        mouseSim.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        Vector2 baseToMouse;
        baseToMouse = mouseSim.position;
        Handles.color = Color.green;

        //Normalize vector by dividing by magnitude.
        if (autoplay)
        {
            Handles.color = Color.cyan;
            Handles.DrawLine(player.position, thinking);
        }
        else
        {
            Handles.color = Color.green;
            Handles.DrawLine(player.position, baseToMouse / baseToMouse.magnitude);
            Handles.color = Color.yellow;
            Handles.DrawLine(getSpawnPoint(baseToMouse), baseToMouse / baseToMouse.magnitude * deNormalizer);
        }
    }
#endif
    private void Update()
    {
        if (autoplay)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject closestenemy = null;
            float closestEnemyDist = 100f;
            foreach (GameObject enemy in enemies)
            {
                if (enemy.GetComponent<EnemyAI>().distFromPlayer() < closestEnemyDist)
                {
                    closestenemy = enemy;
                    thinking = closestenemy.transform.position;
                    closestEnemyDist = enemy.GetComponent<EnemyAI>().distFromPlayer();
                }
            }

            Vector2 autoPosition = new Vector3(closestenemy.transform.position.x, closestenemy.transform.position.y, 0);
            player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, player.transform.eulerAngles.y, Mathf.Rad2Deg * playerRotationZ(autoPosition) - 90);
            if (Time.time - shotTimer >= tBtShots)
            {
                shotTimer = Time.time;
                shotsList.Add(shootShot(thinking / thinking.magnitude * deLimiter, getSpawnPoint(thinking)));
            }
        }
        else
        {
            Vector2 baseToMouse = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, player.transform.eulerAngles.y, Mathf.Rad2Deg*playerRotationZ(baseToMouse) - 90);
            if (Input.GetMouseButton(0))
            {
                shotsList.Add(shootShot(baseToMouse / baseToMouse.magnitude * deLimiter, getSpawnPoint(baseToMouse)));
            }
        }
    }

    private Vector2 getSpawnPoint(Vector2 vec)
    {
        Vector2 point;
        point = vec / vec.magnitude;
        return point;
    }
    private GameObject shootShot(Vector2 force, Vector2 spawnPoint)
    {
        localSpawn.position = spawnPoint;
        //GameObject thisShot = Instantiate(shot, new Vector3(Camera.main.ScreenToWorldPoint(spawnPoint).x, Camera.main.ScreenToWorldPoint(spawnPoint).y, 0), Quaternion.identity);
        GameObject thisShot = Instantiate(shot, spawnPoint, Quaternion.identity);
        thisShot.GetComponent<Rigidbody2D>().AddForce(force * forceMult);
        return thisShot;
    }

    private float playerRotationZ(Vector2 baseVec)
    {
        return Mathf.Atan2(baseVec.y, baseVec.x);
    }

}
