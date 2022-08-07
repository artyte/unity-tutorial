using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int buildNum = 1;
    public string SceneName = "Level2";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        GameObject collided = collider.gameObject;
        if (collided.name == "Ball")
        {
            SceneManager.LoadScene(buildNum);
        }
    }
}