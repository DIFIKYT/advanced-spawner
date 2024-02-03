using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform[] _waypoints;

    public void EnableSpawner()
    {
        enabled = true;
    }

    public void DisableSpawner()
    {
        enabled = false;
    }

    public void SpawnEnemy()
    {
        if (enabled == false)
            return;

        Transform spawnPoint = transform;
        Enemy enemy = Instantiate(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        Enemy enemyScript = enemy.GetComponent<Enemy>();

        enemyScript.SetWaypoints(_waypoints);
    }
}