using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private GameObject sphere;
    private Vector3 originalScale;
    private Vector3 startScale;
    private Vector3 endScale;

    private float desiredDuration = 3f;
    private float elapsedTime = 3f;

    private bool[] grab = { false, false };

    private void Start()
    {
        originalScale = transform.localScale;
        startScale = originalScale;
        endScale = originalScale;
    }

    private void Update()
    {
        
        if (grab[0] != grab[1])
        {
            elapsedTime = 0f;
            grab[1] = grab[0];
        }
        if (grab[0] == grab[1] && elapsedTime < desiredDuration)
        {
            elapsedTime += Time.deltaTime;
        }

        float percentageComplete = elapsedTime / desiredDuration;
        transform.localScale = Vector3.Lerp(startScale, endScale, percentageComplete);
    }

    void OnTriggerEnter(Collider other)
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.green;
        startScale = originalScale;
        endScale = originalScale * 2;
        grab[0] = true;
        grab[1] = false;
    }

    void OnTriggerExit(Collider other)
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.red;
        startScale = originalScale * 2;
        endScale = originalScale;
        grab[0] = false;
        grab[1] = true;
    }
}
