using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab = null;
    [SerializeField] private Transform[] _spawnPoints = null;
    [SerializeField] private float _spawnInterval = 2f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, _spawnInterval);
    }

    private void SpawnEnemy()
    {
        int randomSpawnPointIndex = Random.Range(0, _spawnPoints.Length);
        Transform spawnPoint = _spawnPoints[randomSpawnPointIndex];
        GameObject enemy = Instantiate(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        Vector3 randomDirection = GetRandomDirection();

        if (enemyScript != null)
            enemyScript.SetDirection(randomDirection);
    }

    private Vector3 GetRandomDirection()
    {
        Vector3[] possibleDirections = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
        int randomIndex = Random.Range(0, 4);

        return possibleDirections[randomIndex];
    }
}