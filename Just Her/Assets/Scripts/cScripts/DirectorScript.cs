using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;
using Naninovel.UI;
using Naninovel.Commands;
using System;
using UnityEngine.SceneManagement;
public class DirectorScript : MonoBehaviour
{
    static GameObject directorInstance;
    public static DirectorScript directorSingleton;
    public IScriptPlayer scriptPlayer;
    IStateManager stateManager;
    [HideInInspector] public string scriptName;
    public GameObject[] interactiveObjectsArray;
    CameraMovement cameraScript;
    // SaveManager saveManager;
    BlackScreenScript blackScreenScript;
    public Shader highlightShader;
    public Shader defaultShader;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (directorInstance == null)
        {
            blackScreenScript = GameObject.Find("BlackScreenCanvas").GetComponentInChildren<BlackScreenScript>();
            SceneManager.activeSceneChanged += SearchScripts;
            stateManager = Engine.GetService<IStateManager>();
            /*saveManager = gameObject.GetComponent<SaveManager>();
            stateManager.AddOnGameSerializeTask(saveManager.SerializeState);
            stateManager.AddOnGameDeserializeTask(saveManager.DeserializeState);*/
            directorSingleton = this;
            directorInstance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
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
        stateManager = Engine.GetService<IStateManager>();
        blackScreenScript.blackScreenCanvas.worldCamera = GameObject.Find("NewUICamera(Clone)").GetComponent<Camera>();
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
