using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    [SerializeField]
    public GameObject enemy;
    public float health;
    public Camera cam;
    public float lastTime;
    public int round;
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
        if (Time.time-lastTime >= timeBetweenSpawn)
        {
            lastTime = Time.time;
            spawnEnemy(round);
            Debug.Log("Spawning Enemy");
        }
    }

    public GameObject spawnEnemy(float health)
    {
        GameObject thisenemy = Instantiate(enemy, randomPosition(), Quaternion.identity);
        return thisenemy;
    }

    public Vector3 randomPosition()
    {
        Vector3 pos;
        Vector3 basepos = cam.transform.position;
        pos = new Vector3(Random.Range(basepos.x + cam.orthographicSize * 2, basepos.x - cam.orthographicSize * 2), Random.Range(basepos.y + cam.aspect * 3, basepos.y - cam.aspect * 3), 0);
        if(pos.x < basepos.x + 2 && pos.x > basepos.x - 2 && pos.y < basepos.y + 2 && pos.x > basepos.y - 2 && pos.y < basepos.y + 2 && pos.y > basepos.y - 2) 
        {
            if (pos.x < basepos.x + 2 && pos.x > basepos.x - 2 && pos.y < basepos.y + 2 && pos.x > basepos.y - 2)
            {
                int addOSub = (int)Random.Range(0, 2);
               
                switch (addOSub)
                {
                    case 0:
                        pos.x += Random.Range(4, 8);
                        break;

                    case 1:
                        pos.x -= Random.Range(4, 8);
                        break;

                    default:
                        pos.x -= Random.Range(4, 8);
                        break;
                }
            }
            if (pos.y < basepos.y + 2 && pos.y > basepos.y - 2)
            {
                int addOSub = (int)Random.Range(0, 2);
                
                switch (addOSub)
                {
                    case 0:
                        pos.y += Random.Range(4, 8);
                        break;

                    case 1:
                        pos.y -= Random.Range(4, 8);
                        break;

                    default:
                        pos.y -= Random.Range(4, 8);
                        break;
                }
            }
        }
        return pos;
    }
}
