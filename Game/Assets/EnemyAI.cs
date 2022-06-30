using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public float lerp;
    public float enemySpeedLimiter;
    // Update is called once per frame

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        lerp += .01f/enemySpeedLimiter * Time.deltaTime;
        enemy.transform.position = Vector2.Lerp(enemy.transform.position, player.transform.position, lerp);
     
    }
}
