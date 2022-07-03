using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    [SerializeField]
    public GameObject enemy;
    public Camera cam;
    public float lastTime;
    public int round;
    public int camDelim;
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform spawn4;
    public int boundvariable;
    public float timeBetweenSpawn = 1f;
    private void Start()
    {
        lastTime = Time.time;
        round = 1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(enemy.transform.position, player.transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        //Every x seconds
        if (Time.time - lastTime >= timeBetweenSpawn)
        {
            lastTime = Time.time;
            spawnEnemy(5);
        }
    }

    public GameObject spawnEnemy(float health)
    {
        Vector2 posStore = randSpawner2();
        GameObject thisenemy = Instantiate(enemy, posStore, Quaternion.identity);
        thisenemy.GetComponent<EnemyAI>().spawnEnemy(health, 0, posStore);
        return thisenemy;
    }

    /*public Vector3 randomPosition()
    {
        Vector3 pos;
        Vector3 basepos = cam.transform.position;
        float height = cam.orthographicSize;
        float width = cam.aspect * height;

        //pos = new Vector3(Random.Range(basepos.x + width + Random.Range(1, camDelim), basepos.x - width + Random.Range(1, camDelim)), Random.Range(basepos.y + cam.orthographicSize * camDelim, basepos.y - cam.orthographicSize * camDelim), 0);
        pos = new Vector3(Random.Range(basepos.x - width, basepos.x + width), Random.Range(basepos.y - height, basepos.y + height));


        if (pos.x < basepos.x + boundvariable && pos.x > basepos.x - boundvariable && pos.y < basepos.y + boundvariable && pos.x > basepos.y - boundvariable && pos.y < basepos.y + boundvariable && pos.y > basepos.y - boundvariable)
         {
             if (pos.x < basepos.x + boundvariable && pos.x > basepos.x - boundvariable && pos.y < basepos.y + boundvariable && pos.x > basepos.y - boundvariable)
             {
                 int addOSub = (int)Random.Range(0, 2);

                 switch (addOSub)
                 {
                     case 0:
                         pos.x += Random.Range(boundvariable * 2, boundvariable * 4);
                         break;

                     case 1:
                         pos.x -= Random.Range(boundvariable * 2, boundvariable * 4);
                         break;

                     default:
                         pos.x -= Random.Range(boundvariable * 2, boundvariable * 4);
                         break;
                 }
             }
             if (pos.y < basepos.y + boundvariable && pos.y > basepos.y - boundvariable)
             {
                 int addOSub = (int)Random.Range(0, 2);

                 switch (addOSub)
                 {
                     case 0:
                         pos.y += Random.Range(boundvariable * 2, boundvariable * 4);
                         break;

                     case 1:
                         pos.y -= Random.Range(boundvariable * 2, boundvariable * 4);
                         break;

                     default:
                         pos.y -= Random.Range(boundvariable * 2, boundvariable * 4);
                         break;
                 }
             }
         }
        return pos;
    }*/

    /*public Vector3 xSpawner()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        Vector3 basepos = cam.transform.position;
        float height = cam.orthographicSize;
        float width = cam.aspect * height;

        int xDet = (int)Random.Range(0, 2);
        int yDet = (int)Random.Range(0, 2);
        switch (xDet)
        {
            case 0: //positive
                pos.x = basepos.x + width + camDelim;
                break;
            case 1: //negative
                pos.x = basepos.x - width - camDelim;
                break;

                //no default req
        }
        switch (yDet)
        {
            case 0: //positive
                pos.y = basepos.y + height + camDelim;
                break;
            case 1: //negative
                pos.y = basepos.y - height - camDelim;
                break;
                //no default req
        }
        return pos;
    }*/

    /*public Vector3 randSpawner()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        Vector3 basepos = cam.transform.position;
        float height = cam.orthographicSize;
        float width = cam.aspect * height;

        int xDet = (int)Random.Range(0, 2);
        int yDet = (int)Random.Range(0, 2);
        switch (xDet)
        {
            case 0: //positive
                pos.x = (int)Random.Range(basepos.x - width - camDelim, basepos.x + width + camDelim);
                break;
            case 1: //negative
                pos.x = (int)Random.Range(basepos.x - width, basepos.x - width - camDelim);
                break;

                //no default req
        }
        switch (yDet)
        {
            case 0: //positive
                pos.y = (int)Random.Range(basepos.y + height, basepos.y + height + camDelim);
                break;
            case 1: //negative
                pos.y = (int)Random.Range(basepos.y - height, basepos.y - height - camDelim);
                break;
                //no default req
        }

        return pos;
    }*/

    public Vector3 randSpawner2()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        Vector2 basepos = cam.transform.position;

        int spawnPos = (int)Random.Range(0, 4);
        Vector2[] points = {  };
        switch (spawnPos)
        {
            case 0: //R
                
                points = spawn1.GetComponent<BoxManager>().getPoints();
                Debug.Log("Spawned in quadrant 1");
                pos.x = Random.Range(basepos.x + points[0].x, basepos.x + points[1].x);
                pos.y = Random.Range(basepos.y + points[0].y, basepos.y + points[3].y);
                break;
            case 1: //O
                points = spawn2.GetComponent<BoxManager>().getPoints();
                Debug.Log("Spawned in quadrant 2");
                pos.x = Random.Range(basepos.x + points[0].x, basepos.x + points[1].x);
                pos.y = Random.Range(basepos.y + points[0].y, basepos.y + points[3].y);
                break;
            case 2: //Y
                points = spawn3.GetComponent<BoxManager>().getPoints();
                Debug.Log("Spawned in quadrant 3");
                pos.x = Random.Range(basepos.x + points[0].x, basepos.x + points[3].x);
                pos.y = Random.Range(basepos.y + points[0].y, basepos.y + points[1].y);
                break;
            case 3: //G
                points = spawn4.GetComponent<BoxManager>().getPoints();
                Debug.Log("Spawned in quadrant 4");
                pos.x = Random.Range(basepos.x + points[0].x, basepos.x + points[3].x);
                pos.y = Random.Range(basepos.y + points[0].y, basepos.y + points[1].y);
                break;
        }

        return pos;
    }
}
