using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotManager : MonoBehaviour
{
    public GameObject shot;
    public Camera cam;
    public CircleCollider2D collider;
    private void Start()
    {
        collider = shot.GetComponent<CircleCollider2D>();
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
        Destroy(collider.gameObject);
        Destroy(collision.gameObject);
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
}
