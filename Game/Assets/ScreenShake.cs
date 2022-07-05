using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public GameObject camera;

    public IEnumerator screenShake(float duration, float magnitude)
    {
        Vector3 originalPosition = camera.transform.localPosition;
        float elTime = 0f;

        while(elTime < duration)
        {
            camera.transform.localPosition = Random.insideUnitSphere * magnitude;
            elTime += Time.deltaTime;
            yield return null;
        }
        camera.transform.localPosition = originalPosition;
    }


    public void ShakeScreen(float duration, float magnitude)
    {
        StartCoroutine(screenShake(duration, magnitude));
    }
}
