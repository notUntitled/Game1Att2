using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
    public string nextLevel;

    private void Start()
    {
        nextLevel = "Stage1";
    }
    public void GoNextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevel);
    }
}
