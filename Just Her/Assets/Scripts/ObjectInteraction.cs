using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ObjectInteraction : MonoBehaviour
{
    public string scriptName;
    DirectorScript directorScript;
    public Texture2D magnifierTexture;
    [HideInInspector]
    public GameObject pressedObject;
    CameraMovement cameraScript;
    delegate void ClickedAction();
    event ClickedAction cameraEvent;
    void Start()
    {
        directorScript = GameObject.Find("Director").GetComponent<DirectorScript>();
        cameraScript = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        cameraEvent += cameraScript.ZoomCamera;
    }
    public void OnMouseDown()
    {
        cameraEvent();
        // directorScript.scriptPlayer.PreloadAndPlayAsync(scriptName);
    }
    void OnMouseEnter()
    {
        Cursor.SetCursor(magnifierTexture, Vector2.zero, CursorMode.Auto);
    }
    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
