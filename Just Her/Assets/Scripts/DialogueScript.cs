using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel.UI;
public class DialogueScript : MonoBehaviour
{
    DirectorScript directorScript;
    [HideInInspector] public RevealableTextPrinterPanel dialogueTextScript;
    void Start()
    {
        dialogueTextScript = GetComponent<RevealableTextPrinterPanel>();
    }
    void Update()
    {
        if (directorScript == null)
        {
            directorScript = FindObjectOfType<DirectorScript>();
            if (directorScript != null)
            {
                dialogueTextScript.onHide.AddListener(directorScript.StartZoomOut);
            }
        }
    }
}
