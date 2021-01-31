using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;
public class ObjectInteraction : MonoBehaviour
{
    Renderer renderer;
    public string label;
    [HideInInspector]
    public bool isClicked;
    DirectorScript directorScript;
    void Start()
    {
        renderer = GetComponent<Renderer>();
        directorScript = FindObjectOfType<DirectorScript>();
    }
    public void OnMouseDown()
    {
        isClicked = true;
        Script playedScript = directorScript.scriptPlayer.PlayedScript;
        directorScript.scriptPlayer.PreloadAndPlayAsync(playedScript.Name, label: label);
    }
    void OnMouseEnter()
    {
        renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 0.5f);
    }
    void OnMouseExit()
    {
        renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 1f);
    }
}
