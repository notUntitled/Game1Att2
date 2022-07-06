using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopScreen;
    public GameObject baseScreen;
    public void OnShopClick()
    {
        baseScreen.SetActive(!baseScreen.activeSelf);
        shopScreen.SetActive(!shopScreen.activeSelf);
    }
}
