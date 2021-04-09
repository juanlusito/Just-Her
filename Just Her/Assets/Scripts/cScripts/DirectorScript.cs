using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;
using Naninovel.UI;
using System;
using UnityEngine.SceneManagement;
public class DirectorScript : MonoBehaviour
{
    public static DirectorScript directorSingleton;
    public IScriptPlayer scriptPlayer;
    [HideInInspector] public string scriptName;
    public GameObject[] interactiveObjectsArray;
    CameraMovement cameraScript;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        directorSingleton = this;
        SceneManager.activeSceneChanged += SearchScripts;
    }
    void Update()
    {
        if (cameraScript != null)
        {
            if (cameraScript.hasZoom_InEnded == true)
            {
                scriptPlayer.PreloadAndPlayAsync(scriptName);
                cameraScript.hasZoom_InEnded = false;
            }
        }
    }
    void SearchScripts (Scene currentScene, Scene newScene)
    {
        if (GameObject.Find("Main Camera") == true)
        {
            cameraScript = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        }
        interactiveObjectsArray = GameObject.FindGameObjectsWithTag("InteractiveObject");
        scriptPlayer = Engine.GetService<IScriptPlayer>();
    }
    public void EnableObjectInteraction()
    {
        foreach (GameObject interactiveObject in interactiveObjectsArray)
        {
            Collider collider = interactiveObject.GetComponent<Collider>();
            collider.enabled = true;
        }
    }
    public void DisableObjectInteraction()
    {
        foreach (GameObject interactiveObject in interactiveObjectsArray)
        {
            Collider collider = interactiveObject.GetComponent<Collider>();
            collider.enabled = false;
        }
    }
    public void StartZoomOut()
    {
        if (cameraScript != null)
        {
            cameraScript.StartCoroutine("ZoomOut");
        }
    }
}
