using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float baseDamage;
    private float baseHealth;
    private float gold;
    private int baseShots;

    private void Start()
    {
        baseDamage = 3;
        baseHealth = 5;
        gold = 0;
        baseShots = 1;
    }
    //Getter-Setter

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

    //Setters

    private void setBaseDamage(float newDamage)
    {
        baseDamage = newDamage;
    }

    private void setBaseHealth(float newhealth)
    {
        baseHealth = newhealth;
    }

    private void setGold(float newgold)
    {
        gold = newgold;
    }

    private void setBaseShots(int newBaseShots)
    {
        baseShots = newBaseShots;
    }
}
