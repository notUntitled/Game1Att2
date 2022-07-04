using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float baseDamage;
    private float totalHealth;
    private float baseHealth; // current health no modifiers
    private float gold;
    private int baseShots;
    public int points;
    public Score score;
    public float atkSpd;
    public directionRay player;
    public HealthManager healthManager;
    public ParticleSystem hitPar;

    private void Start()
    {
        totalHealth = 10;
        atkSpd = .3f;
        baseDamage = 3;
        baseHealth = totalHealth;
        gold = 0;
        baseShots = 1;
    }

    //Functionality

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag == "Enemy")
        {
            hitPar.Play();
            Debug.Log("Enemy collided");
            setBaseHealth(baseHealth - collision.gameObject.GetComponent<EnemyAI>().getHealth());
            GameObject.Destroy(collision.gameObject);
            if (baseHealth <= 0)
            {
                playerDead();
            }
        }
    }

    private void playerDead()
    {
        player.playerDied();

    }

    //Getter



    public float getBaseDamage()
    {
        return baseDamage;
    }

    public float getBaseHealth()
    {
        return baseHealth;
    }

    public float getTotalHealth()
    {
        return totalHealth;
    }

    public float getGold()
    {
        return gold;
    }

    public float getBaseShots()
    {
        return baseShots;
    }

    public int getPoints()
    {
        return points;
    }

    public float getAtkSpd()
    {
        return atkSpd;
    }
    //Setters

    private void setBaseDamage(float newDamage)
    {
        baseDamage = newDamage;
    }

    private void setBaseHealth(float newhealth)
    {
        Debug.Log("Previous Health: " + baseHealth);
        baseHealth = newhealth;
        Debug.Log("New health: " + baseHealth);
        healthManager.updateHealthBar(getBaseHealth()/getTotalHealth());
    }

    public void getTotalHealth(float newTotalhealth)
    {
        totalHealth = newTotalhealth;
    }

    private void setGold(float newgold)
    {
        gold = newgold;
    }

    private void setBaseShots(int newBaseShots)
    {
        baseShots = newBaseShots;
    }

    public void setPoints(int newPoints)
    {
        points = newPoints;
        score.updateScore(points);
    }
    public void setAtkspd(float newAtkSpd)
    {
        atkSpd = newAtkSpd;
    }
}
