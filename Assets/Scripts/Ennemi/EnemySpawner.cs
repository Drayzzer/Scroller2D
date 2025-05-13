using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 3f;
    public Transform[] spawnPoints;
    public Transform pointA;
    public Transform pointB;
    
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Length == 0) 
        {
            return;
        }
        
        int index = Random.Range(0, spawnPoints.Length);
        Transform selectedspawnPoint = spawnPoints[index];
        
        GameObject enemy = Instantiate(enemyPrefab, selectedspawnPoint.position, Quaternion.identity);

        EnemyMoving moveScript = enemy.GetComponent<EnemyMoving>();
        if (moveScript != null)
        {
            moveScript.pointA = pointA;
            moveScript.pointB = pointB;
        }
    }
}
