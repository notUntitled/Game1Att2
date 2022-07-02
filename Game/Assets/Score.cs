using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public float score;
    public PlayerStats stats;
    public TMPro.TextMeshProUGUI text;

    private void Start()
    {

    }

    public void updateScore(int score)
    {
        this.score = score;
        string textAdd = "";
        if (score / 10 < 1)
        {
            textAdd = "000";
        }
        else if (score / 100 < 1)
        {
            textAdd = "0";
        }
        else if (score / 1000 < 1)
        {
            textAdd = "0";
        }
        text.text = textAdd + score.ToString();
    }
}
