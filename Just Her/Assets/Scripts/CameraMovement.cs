using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraMovement : MonoBehaviour
{
    [HideInInspector] public GameObject pressedObject;
    Camera camera;
    // Variable para la rotación de cámara
    Vector3 targetDirection;
    Quaternion defaultRotation;
    Quaternion nextRotation;
    public float rotationSpeed = 5;
    // Variables para el zoom
    public float objectFovValue = 25;
    float defaultFovValue;
    public float zoom_InDuration;
    float zoom_InTime;
    public float zoom_OutDuration;
    float zoom_OutTime;
    DirectorScript directorScript;
    // Bool para indicar el fin del zoom-in
    [HideInInspector] public bool hasZoom_InEnded;
    void Start()
    {
        camera = GetComponent<Camera>();
        directorScript = FindObjectOfType<DirectorScript>();
        defaultRotation = transform.rotation;
        defaultFovValue = camera.fieldOfView;
    }
    public void SetDirection()
    {
        targetDirection = pressedObject.transform.position - transform.position;
        nextRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        StartCoroutine("ZoomIn");
    }
    IEnumerator ZoomIn()
    {
        while (zoom_InTime < zoom_InDuration)
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, objectFovValue, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, rotationSpeed * Time.deltaTime);
            zoom_InTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        hasZoom_InEnded = true;
        zoom_InTime = 0;
    }
    IEnumerator ZoomOut()
    {
        while (zoom_OutTime < zoom_OutDuration)
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, defaultFovValue, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, defaultRotation, rotationSpeed * Time.deltaTime);
            zoom_OutTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        zoom_OutTime = 0;
        directorScript.EnableObjectInteraction();
    }
}
