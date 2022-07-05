using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
    public int nextLevel;

    private void Start()
    {
       
    }
    public void GoNextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevel);
    }
}
