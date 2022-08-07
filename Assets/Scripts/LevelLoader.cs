using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int buildNum;
    public string SceneName;
    //Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        //scene = SceneManager.GetActiveScene();
        //Debug.Log("Active Scene name is: " + scene.name + "\nActive Scene index: " + scene.buildIndex);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        GameObject collided = collider.gameObject;
        Debug.Log(collided.name);
        if (collided.name == "Ball" || collided.name == "LeftHand Controller" || collided.name == "RightHand Controller")
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
