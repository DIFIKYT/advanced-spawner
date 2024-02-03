using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        DestroyEnemy(collider.gameObject);
    }

    private void DestroyEnemy(GameObject enemy)
    {
        Destroy(enemy);
    }
}