using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public UnityEngine.UI.Image healthbar1;
    public UnityEngine.UI.Image healthbar2;
    public PlayerStats stats;
    public float percenHealth;
    [Range(0f,1f)]
    public float lerpalot;
    public bool increasingLerp;
    public float multiplier;

    private void Start()
    {
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if (increasingLerp)
        {
            lerpalot += .005f * multiplier;
            healthFX();
        }
        else
        {
            lerpalot = 0f;
        }

        if (lerpalot >= 1f) {
            increasingLerp = false;
        }
    }

    //OPTIMIZATION: Make both of the healthbars use the same function.
    public void updateHealthBar(float t)
    {
        if (t < 0)
        {
            t = 0;
        }
        percenHealth = t;
        healthbar1.rectTransform.sizeDelta = new Vector2(t * healthbar1.rectTransform.sizeDelta.x, healthbar1.rectTransform.sizeDelta.y);
        healthbar1.rectTransform.localPosition = new Vector3(0f, healthbar1.rectTransform.localPosition.y, healthbar1.rectTransform.localPosition.z);
        increasingLerp = true;
        healthFX();
    }

    public void healthFX()
    {
        healthbar2.rectTransform.sizeDelta = new Vector2(Mathf.Lerp(healthbar2.rectTransform.sizeDelta.x, healthbar1.rectTransform.sizeDelta.x, lerpalot), healthbar2.rectTransform.sizeDelta.y);

        healthbar2.rectTransform.localPosition = new Vector3(0f, healthbar2.rectTransform.localPosition.y, healthbar2.rectTransform.localPosition.z);
        
    }
}
