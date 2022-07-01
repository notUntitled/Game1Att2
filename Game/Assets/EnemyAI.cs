using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public float lerp;
    public float enemySpeedLimiter;
    private float health;

    public void spawnEnemy(float health, int type)
    {
        setHealth(health);
    }

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        while (player.GetComponent<directionRay>().moving)
        {
            lerp += .01f / enemySpeedLimiter * Time.deltaTime;
            enemy.transform.position = Vector2.Lerp(enemy.transform.position, player.transform.position, lerp);
        }

        }

        public void DamageEnemy(float damage)
    {
        if (health - damage <= 0)
        {
            PlayerStats playerStats = player.GetComponent<PlayerStats>();
            GameObject.Destroy(enemy);
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
