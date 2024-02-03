using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab = null;
    [SerializeField] private Transform[] _waypoints;

    private bool _spawnerEnabled = false;

    public void EnableSpawner()
    {
        _spawnerEnabled = true;
    }

    public void DisableSpawner()
    {
        _spawnerEnabled = false;
    }

    public void SpawnEnemy()
    {
        if (_spawnerEnabled == false)
            return;

        Transform spawnPoint = transform;
        GameObject enemy = Instantiate(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        EnemyController enemyScript = enemy.GetComponent<EnemyController>();

        enemyScript.SetWaypoints(_waypoints);
    }
}