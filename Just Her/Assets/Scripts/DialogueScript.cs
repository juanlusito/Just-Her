using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel.UI;
public class DialogueScript : MonoBehaviour
{
    DirectorScript directorScript;
    RevealableTextPrinterPanel dialogueTextScript;
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
                dialogueTextScript.onShow.AddListener(directorScript.DisableObjectInteraction);
                dialogueTextScript.onHide.AddListener(directorScript.EnableObjectInteraction);
            }
        }
    }
}
