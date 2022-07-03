using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    [Range(0,1)]
    public float lerp;
    public float enemySpeedLimiter;
    private float health;
    public directionRay manager;
    public Vector2 spawnPos;
    public EventHandler eventHandler;
    public void spawnEnemy(float health, int type, Vector2 spawnPoint)
    {
        setHealth(health);
        spawnPos = spawnPoint;
    }

    private void Start()
    {
        eventHandler = GameObject.Find("EventHandler").GetComponent<EventHandler>();
        player = GameObject.Find("Player");
        manager = player.GetComponent<directionRay>();
    }
    void Update()
    {
        if (manager.moving)
        {
            lerp += .2f / enemySpeedLimiter * Time.deltaTime;
            if(manager.moving && !manager.timePause && !manager.pause && !manager.dead && !manager.levelComplete)
            enemy.transform.position = Vector2.Lerp(spawnPos, player.transform.position, lerp);
        }

        }

        public void DamageEnemy(float damage)
    {
        if (health - damage <= 0)
        {
            PlayerStats playerStats = player.GetComponent<PlayerStats>();
            GameObject.Destroy(enemy);
            eventHandler.setKillCount(eventHandler.getKillCount() + 1);
            Debug.Log("Destroyed enemy");
            playerStats.setPoints(playerStats.getPoints() + 1);
            //Overkill
        }
        else
        {
            setHealth(health - damage);
        }
    }

    public float getHealth()
    {
        return health;
    }

    private void setHealth(float health)
    {
        this.health = health;
    }

    public float distFromPlayer()
    {
        return (enemy.transform.position - player.transform.position).magnitude;
    }

}
