using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ObjectInteraction : MonoBehaviour
{
    public string scriptName;
    public Texture2D magnifierTexture;
    [HideInInspector] public GameObject pressedObject;
    CameraMovement cameraScript;
    delegate void ClickedAction();
    event ClickedAction clickEvents;
    void Start()
    {
        cameraScript = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        clickEvents += DirectorScript.directorSingleton.DisableObjectInteraction;
        clickEvents += cameraScript.SetDirection;
    }
    public void OnMouseDown()
    {
        cameraScript.pressedObject = gameObject;
        DirectorScript.directorSingleton.scriptName = scriptName;
        clickEvents();
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
