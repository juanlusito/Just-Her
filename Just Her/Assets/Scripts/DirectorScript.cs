using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;
using Naninovel.Commands;
public class DirectorScript : MonoBehaviour
{
    public IScriptPlayer scriptPlayer = Engine.GetService<IScriptPlayer>();
    public ObjectInteraction[] interactionScriptArray;
    [HideInInspector]
    public GameObject cameraObject;
    void Start()
    {
        interactionScriptArray = Object.FindObjectsOfType(typeof(ObjectInteraction)) as ObjectInteraction[];
    }
    void Update()
    {
        Command currentCommand = scriptPlayer.PlayedCommand;
        if (currentCommand.ToString() == "Naninovel.Commands.Stop")
        {
            AddCameraScript();
            foreach (ObjectInteraction interactionScript in interactionScriptArray)
            {
                interactionScript.enabled = !interactionScript.enabled;
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
