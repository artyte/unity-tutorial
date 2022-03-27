using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private GameObject sphere;
    private Vector3 bigScale;
    private Vector3 smallScale;

    void getSphere()
    {
        sphere = GameObject.Find("Left Ball");
    }

    private void Start()
    {
        sphere = GameObject.Find("Left Ball");

        smallScale = sphere.transform.localScale / 2;
        bigScale = sphere.transform.localScale * 2;
    }

    void OnTriggerEnter(Collider other)
    {
        sphere.transform.localScale = Vector3.Lerp(sphere.transform.localScale, bigScale, 2.0f * Time.deltaTime);
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.green;
    }

    void OnTriggerExit(Collider other)
    {
        sphere.transform.localScale = Vector3.Lerp(sphere.transform.localScale, smallScale, 2.0f * Time.deltaTime);
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.red;
    }
}
