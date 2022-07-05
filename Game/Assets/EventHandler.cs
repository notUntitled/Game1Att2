using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{

    public bool start;
    public TMPro.TextMeshProUGUI objective;
    [Range(0f, 1f)]
    public float transparLerp;
    public Color32 colorC;
    public int killCount;
    public int totalKills;
    public TMPro.TextMeshProUGUI killCounter;
    public directionRay player;
    public UnityEngine.UI.Image StageCompleteSc;
    public TMPro.TextMeshProUGUI stageText;
    public float levelLerp;
    public float firstPos;
    void Start()
    {
        firstPos = StageCompleteSc.rectTransform.position.x;
        player = GameObject.Find("Player").GetComponent<directionRay>();
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

        if (player.levelComplete && levelLerp <= 1f)
        {
            levelLerp += .01f;
            StageCompleteSc.rectTransform.position = new Vector2(firstPos, Mathf.Lerp(StageCompleteSc.rectTransform.position.y, 900, levelLerp));
        }
        else if(levelLerp >= 1f)
        {
            stageText.gameObject.SetActive(true);
        }

    }

    public int getKillCount()
    {
        return killCount;
    }
    public void setKillCount(int newKc)
    {
        killCount = newKc;
        killCounter.text = killCount + "/" + totalKills;
        if(killCount >= totalKills)
        {
            levelComplete();
        }
    }

    public void levelComplete()
    {
        player.spawning = false;
        player.levelComplete = true;
        Debug.Log("Level Complete");
        StageCompleteSc.gameObject.SetActive(true);
        
    }
}
