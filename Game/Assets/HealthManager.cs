using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public UnityEngine.UI.Image healthbar1;
    public UnityEngine.UI.Image healthbar2;
    public PlayerStats stats;
    public float test;
    public float percenHealth;
    [Range(0f,1f)]
    public float lerpalot;

    private void Start()
    {
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    private void Update()
    {
    }

    //OPTIMIZATION: Make both of the healthbars use the same function.
    public void updateHealthBar(UnityEngine.UI.Image healthbar, float a, float b, float t)
    {
        if (t < 0)
        {
            t = 0;
        }
        percenHealth = t;
        float lerped = Mathf.Lerp(a, b, t);
        healthbar.rectTransform.sizeDelta = new Vector2(t * healthbar.rectTransform.sizeDelta.x, healthbar.rectTransform.sizeDelta.y);
        healthbar.rectTransform.localPosition = new Vector3(-150, healthbar.rectTransform.localPosition.y, healthbar.rectTransform.localPosition.z);
        healthFX();
    }

    /*public void healthFX()
    {
        healthbar.rectTransform.sizeDelta = new Vector2(t * healthbar.rectTransform.sizeDelta.x, healthbar.rectTransform.sizeDelta.y);

        healthbar2.rectTransform.localPosition = new Vector3(-150, healthbar2.rectTransform.localPosition.y, healthbar2.rectTransform.localPosition.z);
        lerpalot = 0;
    }*/
}
