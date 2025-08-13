using System;
using UnityEngine;

public class ChangeGameState : MonoBehaviour
{
    [SerializeField] private GameState gameState;

    private void Awake()
    {
        gameState.isGameRunning = false;
    }

    public void StartGameSession()
    {
        if (!gameState.isGameRunning)
        {
            gameState.isGameRunning = true;
        }
    }
    
    public void EndGameSession()
    {
        if (gameState.isGameRunning)
        {
            gameState.isGameRunning = false;
        }
    }
}
