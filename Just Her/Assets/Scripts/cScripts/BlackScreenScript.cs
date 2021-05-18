using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BlackScreenScript : MonoBehaviour
{
    static GameObject screenInstance;
    public Canvas blackScreenCanvas;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (screenInstance == null)
        {
            screenInstance = gameObject;
            blackScreenCanvas = gameObject.GetComponent<Canvas>();
            if (GameObject.Find("NewUICamera(Clone)") == true)
            {
                blackScreenCanvas.worldCamera = GameObject.Find("NewUICamera(Clone)").GetComponent<Camera>();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
