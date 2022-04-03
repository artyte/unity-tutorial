using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Vector3 originalScale;

    private float desiredDuration = 3f;
    private float elapsedTime = 3f;

    private bool balloon;

    [SerializeField]
    private AnimationCurve curve;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void Update()
    {
        if (balloon)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;
            transform.localScale = Vector3.Lerp(originalScale, originalScale * 2, curve.Evaluate(percentageComplete));
        } else
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;
            transform.localScale = Vector3.Lerp(originalScale * 2, originalScale, curve.Evaluate(percentageComplete));
        }

        if (elapsedTime > desiredDuration)
        {
            elapsedTime = desiredDuration;
        }
    }

    void OnTriggerEnter(Collider collided)
    {
        if (collided.gameObject.name == "Plane")
        {
            expand();
            elapsedTime = desiredDuration - elapsedTime;
        }
    }

    void OnTriggerExit(Collider justSeperated)
    {
        if (justSeperated.gameObject.name == "Plane")
        {
            contract();
            elapsedTime = desiredDuration - elapsedTime;
        }
    }

    void expand()
    {
        Renderer sphere = GetComponent<Renderer>();
        sphere.material.color = Color.green;
        balloon = true;
        
    }

    void contract()
    {
        Renderer sphere = GetComponent<Renderer>();
        sphere.material.color = Color.red;
        balloon = false;
    }
}
