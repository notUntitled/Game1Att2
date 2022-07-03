using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHandler : MonoBehaviour
{
    public bool start;
    public TMPro.TextMeshProUGUI objective;
    [Range(0f, 1f)]
    public float transparLerp;
    public Color32 colorC;
    void Start()
    {
        directionRay player = GameObject.Find("Player").GetComponent<directionRay>();
        start = false;
    }

    private void Update()
    {
        colorC = new Color(objective.color.r, objective.color.g, objective.color.b, Mathf.Lerp(1, 0, transparLerp));
        if (!start)
        {
            Time.timeScale = 0;
        }

        if (start && transparLerp <= 1f)
        {
            
            transparLerp += .001f;
            objective.color = colorC;
        }

        if (!start && Input.GetMouseButtonDown(0))
        {
            start = true;
            Time.timeScale = 1;
        }
        
    }
}
