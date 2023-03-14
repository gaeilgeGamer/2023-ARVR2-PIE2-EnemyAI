using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemyMove : MonoBehaviour
{
public enum EnemyState {
    Idle,Moving,Following
}
    private NavMeshAgent navMeshAgent;
    private GameObject player;
    public EnemyState currentState = EnemyState.Idle;

    void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    void Update() {

           switch (currentState) {
      case EnemyState.Idle:
         // do nothing
         break;
      case EnemyState.Moving:
         // move to a random location on the NavMesh
         if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.1f) {
            SetRandomDestination();
         }
         break;
        case EnemyState.Following:
        navMeshAgent.SetDestination(player.transform.position);
        break; 
           }     
   
float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
   if ((currentState == EnemyState.Idle || currentState == EnemyState.Moving) && distanceToPlayer < 5f) {
 {
      currentState = EnemyState.Following;
   }
   if ((currentState == EnemyState.Following) && distanceToPlayer > 5f) {
 {
      currentState = EnemyState.Moving;
   } 
}}
void SetRandomDestination() {
   Vector3 randomDirection = Random.insideUnitSphere * 10f;
   randomDirection += transform.position;
   NavMeshHit hit;
   NavMesh.SamplePosition(randomDirection, out hit, 10f, NavMesh.AllAreas);
   navMeshAgent.SetDestination(hit.position);
}
}}
