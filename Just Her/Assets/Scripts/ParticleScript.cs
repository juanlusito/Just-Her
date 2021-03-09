using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ParticleScript : MonoBehaviour
{
    ParticleSystem particleSystem;
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            
        }
    }
}
