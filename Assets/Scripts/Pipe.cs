using System;
using UnityEngine;

public class Pipe : MonoBehaviour
{
  [SerializeField] private GameState gameState;
  [SerializeField] private float movingSpeed;

  private void Update()
  {
    if (!gameState.isGameRunning) return;
    transform.Translate( movingSpeed * Time.deltaTime * Vector3.left, Space.World);
  }
}
