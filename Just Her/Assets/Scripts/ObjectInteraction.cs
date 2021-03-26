using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ObjectInteraction : MonoBehaviour
{
    public string scriptName;
    public Texture2D magnifierTexture;
    [HideInInspector] public GameObject pressedObject;
    DirectorScript directorScript;
    CameraMovement cameraScript;
    delegate void ClickedAction();
    event ClickedAction clickEvents;
    void Start()
    {
        cameraScript = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        directorScript = FindObjectOfType<DirectorScript>();
        clickEvents += cameraScript.SetDirection;
        clickEvents += directorScript.DisableObjectInteraction;
    }
    public void OnMouseDown()
    {
        cameraScript.pressedObject = gameObject;
        directorScript.scriptName = scriptName;
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
