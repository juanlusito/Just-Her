using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;
using System;
public class DirectorScript : MonoBehaviour
{
    public IScriptPlayer scriptPlayer = Engine.GetService<IScriptPlayer>();
    public GameObject[] interactiveObjectsArray;
    [HideInInspector]
    public GameObject cameraObject;
    public string currentLabel;
    void Start()
    {
        interactiveObjectsArray = GameObject.FindGameObjectsWithTag("InteractiveObject");
    }
    void Update()
    {
        /*currentLabel = scriptPlayer.PlayedScript.GetLabelForLine(scriptPlayer.PlayedIndex);
        Debug.Log(currentLabel);
        if (scriptPlayer.PlayedCommand.ToString() == "Naninovel.Commands.Stop")
        {
            AddCameraScript();
            foreach (ObjectInteraction interactionScript in interactionScriptArray)
            {
                interactionScript.enabled = true;
            }
        }*/
    }
    /*void AddCameraScript()
    {
        if (cameraObject == null)
        {
            cameraObject = GameObject.Find("Main Camera");
            if (cameraObject.GetComponent<CameraMovement>() == false)
            {
                cameraObject.AddComponent<CameraMovement>();
            }
        }
    }*/
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
}
