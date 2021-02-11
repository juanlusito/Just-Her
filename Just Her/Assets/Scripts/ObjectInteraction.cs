using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;
public class ObjectInteraction : MonoBehaviour
{
    public string scriptName;
    DirectorScript directorScript;
    public Texture2D magnifierTexture;
    void Start()
    {
        directorScript = FindObjectOfType<DirectorScript>();
    }
    public void OnMouseDown()
    {
        directorScript.scriptPlayer.PreloadAndPlayAsync(scriptName);
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
