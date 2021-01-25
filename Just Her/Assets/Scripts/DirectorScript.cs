using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;
public class DirectorScript : MonoBehaviour
{
    void Update()
    {
        IScriptPlayer scriptPlayer = Engine.GetService<IScriptPlayer>();
        Script playedScript = scriptPlayer.PlayedScript;
    }
}
