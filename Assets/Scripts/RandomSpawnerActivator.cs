using UnityEngine;

public class RandomSpawnerActivator : MonoBehaviour
{
    [SerializeField] private SpawnerController[] _spawners;
    [SerializeField] private float _spawnTime = 1.0f;

    private SpawnerController _activeSpawner;

    private void Start()
    {
        InvokeRepeating(nameof(SwitchSpawner), 0f, _spawnTime);
    }

    private void SwitchSpawner()
    {
        int randomIndex = Random.Range(0, _spawners.Length);

        DisableSpawners(_activeSpawner);
        ActivateSpawner(_spawners[randomIndex]);
    }

    private void ActivateSpawner(SpawnerController enemySpawner)
    {
        enemySpawner.EnableSpawner();
        _activeSpawner = enemySpawner;
        enemySpawner.SpawnEnemy();
    }

    private void DisableSpawners(SpawnerController enemySpawner)
    {
        if(enemySpawner == null)
            return;

        enemySpawner.DisableSpawner();
    }
}