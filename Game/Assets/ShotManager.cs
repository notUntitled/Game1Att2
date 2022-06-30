using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotManager : MonoBehaviour
{
    public GameObject playerref;
    public GameObject shot;
    public Camera cam;
    private CircleCollider2D collida;
    private float damage;

    private void Start()
    {
        playerref = GameObject.Find("Player");
        damage = playerref.GetComponent<PlayerStats>().getBaseDamage();
        collida = shot.GetComponent<CircleCollider2D>();
    }
    void Update()
    {
        if (!inCameraView(shot))
        {
            GameObject.Destroy(shot);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collida.gameObject);
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject enemy = collision.gameObject;
            Debug.Log("Shot an enemy with health: " + enemy.GetComponent<EnemyAI>().getHealth() + " \n Damage Done: " + getDamage());
            enemy.GetComponent<EnemyAI>().DamageEnemy(getDamage());
        }
    }

    public bool inCameraView(GameObject shot)
    {
        Vector2 basepos = cam.transform.position;

        //Check if x or y of shot is greater than the camera's range. {U/R}
        if (shot.transform.position.x > (basepos.x + cam.orthographicSize * 2) || shot.transform.position.y > (basepos.y + cam.aspect * 3))
        {
            return false;
        } //Check if x or y of shot is less than the camera's range. {D/L}
        else if (shot.transform.position.x < (basepos.x - cam.orthographicSize * 2) || shot.transform.position.y < (basepos.y - cam.aspect * 3))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private float getDamage()
    {
        return damage;
    }
}