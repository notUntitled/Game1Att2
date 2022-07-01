using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float baseDamage;
    private float baseHealth;
    private float gold;
    private int baseShots;
    public int points;
    private void Start()
    {
        baseDamage = 3;
        baseHealth = 5;
        gold = 0;
        baseShots = 1;
    }

    //Functionality

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag == "Enemy")
        {
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
        Debug.Log("Dead");
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
    }
}
