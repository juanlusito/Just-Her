using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel.UI;
public class DialogueScript : MonoBehaviour
{
    [HideInInspector] public RevealableTextPrinterPanel dialogueTextScript;
    void Start()
    {
        dialogueTextScript = GetComponent<RevealableTextPrinterPanel>();
        dialogueTextScript.onShow.AddListener(DirectorScript.directorSingleton.DisableObjectInteraction);
        dialogueTextScript.onHide.AddListener(DirectorScript.directorSingleton.StartZoomOut);
        dialogueTextScript.onHide.AddListener(DirectorScript.directorSingleton.EnableObjectInteraction);
    }
}
