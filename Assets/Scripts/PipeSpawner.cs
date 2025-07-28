using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private Pipe pipe;
    [SerializeField] private GameState gameState;
    [SerializeField] private Transform[] spawnPoints;

    private float _timeToSpawn;
    [SerializeField] private float spawnInterval;

    private void Start()
    {
        _timeToSpawn = spawnInterval;
    }

    private void Update()
    {
        if (_timeToSpawn < 0 && gameState.IsGameRunning)
        {
            var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(pipe, spawnPoint.position, spawnPoint.rotation);
            _timeToSpawn = spawnInterval;
        }

        _timeToSpawn -= Time.deltaTime;
    }
}
