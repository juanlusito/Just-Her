using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx.Async;
using Naninovel;
using Naninovel.Commands;
[System.Serializable]
public class SaveManager : MonoBehaviour
{
    public Scene currentScene;
    [System.Serializable]
    private class GameState
    {
        public Scene stateScene;
    }
    public void SerializeState(GameStateMap gameStateMap)
    {
        currentScene = SceneManager.GetActiveScene();
        GameState newState = new GameState()
        {
            stateScene = currentScene
        };
        gameStateMap.SetState(newState);
    }
    public UniTask DeserializeState(GameStateMap gameStateMap)
    {
        GameState gameState = gameStateMap.GetState<GameState>();
        if (gameState == null)
        {
            return UniTask.CompletedTask;
        }
        currentScene = gameState.stateScene;
        Debug.Log(currentScene.name);
        return UniTask.CompletedTask;
    }
}
