using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ObjectInteraction : MonoBehaviour
{
    public string scriptName;
    public Texture2D magnifierTexture;
    [HideInInspector] public GameObject pressedObject;
    public float objectFOV_Value = 25;
    CameraMovement cameraScript;
    delegate void ClickedAction();
    event ClickedAction clickEvents;
    //List<GameObject> children;
    //public List<Material> materialList;
    //public List<Material> childrenMaterials;
    //Material[] objectMaterials;
    void Start()
    {
        //children = new List<GameObject>();
        //materialList = new List<Material>();
        //childrenMaterials = new List<Material>();
        //objectMaterials = gameObject.GetComponent<Renderer>().materials;
        cameraScript = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        //if (gameObject.GetComponent<MeshFilter>() != null)
        //{
        //    for (int i = 0; i < objectMaterials.Length; i++)
        //    {
        //        childrenMaterials.Add(objectMaterials[i]);
        //    }
        //}
        //if (transform.childCount > 0)
        //{
        //    for (int i = 0; i < transform.childCount; i++)
        //    {
        //        children.Add(transform.GetChild(i).gameObject);
        //    }
        //    foreach (GameObject gameObject in children)
        //    {
        //        childrenMaterials.Add(gameObject.GetComponent<Material>());
        //    }
        //}
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
        //foreach (Material material in childrenMaterials)
        //{
        //    material.shader = DirectorScript.directorSingleton.highlightShader;
        //}
    }
    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        //foreach (Material material in childrenMaterials)
        //{
        //    material.shader = DirectorScript.directorSingleton.defaultShader;
        //}
    }
}
