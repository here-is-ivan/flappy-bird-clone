using System;
using UnityEngine;

public class Pipe : MonoBehaviour
{
  [SerializeField] private float movingSpeed;

  private void Update()
  {
    transform.Translate( movingSpeed * Time.deltaTime * Vector3.left, Space.World);
  }
}
