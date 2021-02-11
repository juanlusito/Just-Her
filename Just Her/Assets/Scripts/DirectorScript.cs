using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;
using System;
using Naninovel.Commands;
public class DirectorScript : MonoBehaviour
{
    public IScriptPlayer scriptPlayer = Engine.GetService<IScriptPlayer>();
    public ObjectInteraction[] interactionScriptArray;
    [HideInInspector]
    public GameObject cameraObject;
    public string currentLabel;
    void Start()
    {
        interactionScriptArray = FindObjectsOfType(typeof(ObjectInteraction)) as ObjectInteraction[];
    }
    void Update()
    {
        currentLabel = scriptPlayer.PlayedScript.GetLabelForLine(scriptPlayer.PlayedIndex);
        if (scriptPlayer.PlayedCommand.ToString() == "Naninovel.Commands.Stop")
        {
            AddCameraScript();
            foreach (ObjectInteraction interactionScript in interactionScriptArray)
            {
                interactionScript.enabled = true;
            }
        }
    }
    void AddCameraScript()
    {
        if (cameraObject == null)
        {
            cameraObject = GameObject.Find("Main Camera");
            if (cameraObject.GetComponent<CameraMovement>() == false)
            {
                cameraObject.AddComponent<CameraMovement>();
            }
        }
    }
}
