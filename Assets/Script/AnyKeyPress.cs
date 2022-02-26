using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyKeyPress : MonoBehaviour
{
    public int toSceneIndex;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(toSceneIndex);
        }
    }
}
