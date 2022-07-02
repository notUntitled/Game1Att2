using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public void ReloadLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
