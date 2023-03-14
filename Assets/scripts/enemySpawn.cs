using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemySpawn : MonoBehaviour
{
public GameObject enemyPrefab;
public Transform[] spawnPoints;
public int numberOfEnemies;
public float spawnDelay;
    // Start is called before the first frame update
        void Start()
{
   StartCoroutine(SpawnEnemies());
}
    IEnumerator SpawnEnemies() {
        for (int i = 0; i < numberOfEnemies; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
    }
    
void SpawnEnemy()
{
   int spawnIndex = Random.Range(0, spawnPoints.Length);
   Transform spawnPoint = spawnPoints[spawnIndex];

   GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

   NavMeshAgent navMeshAgent = enemy.GetComponent<NavMeshAgent>();
   navMeshAgent.Warp(spawnPoint.position);
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
