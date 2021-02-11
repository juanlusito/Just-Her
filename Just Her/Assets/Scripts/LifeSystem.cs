using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeSystem : MonoBehaviour
{
    DirectorScript directorScript;
    [HideInInspector]
    public Slider slider;
    void Start()
    {
        directorScript = FindObjectOfType<DirectorScript>();
        slider = FindObjectOfType<Slider>();
    }
}