using UnityEngine;
using UnityEngine.AI;

public class AI_Follow : MonoBehaviour 
{

    public EnemyBaseData enemyStats;
    public bool isAlwaysWalking;
    public bool isAlwaysChasing;
    [Range(0f, 100f)]
    public float alertDistance;
    [Range(0f, 100f)]
    public float wanderRadius;
    [Range(0f, 10f)]
    public float wanderTimer;

    private Transform target;
    private bool isChasing;
    private NavMeshAgent myAgent;
    bool isTracking;
    private float timer;
    GameObject player;
  

    void Start () 
	{  
        GameObject[] playerList = FindPlayer();
        myAgent = GetComponent<NavMeshAgent>();
        if (playerList != null && playerList.Length > 0) {
            player = playerList[0];
            isTracking = player.activeInHierarchy;
            target = player.transform;
        }
        timer = wanderTimer;

    }

	void Update () {
        if (Vector3.Distance(gameObject.transform.position, target.transform.position) <= alertDistance || isAlwaysChasing) {
            isChasing = true;
            if (isAlwaysWalking) {
                gameObject.GetComponent<Animator>().SetBool("chasing", false);
            } else {
                gameObject.GetComponent<Animator>().SetBool("chasing", true);
            }
            
        } else {
            isChasing = false;
            gameObject.GetComponent<Animator>().SetBool("chasing", false);
           
        }
        if (isTracking && isChasing) {
            myAgent.SetDestination(target.position);
        }
        if (isTracking && !isChasing) {
            timer += Time.deltaTime;
            if (timer >= wanderTimer) {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                myAgent.SetDestination(newPos);
                timer = 0;
            }
        }
    }
    public void StopNavAgent(){
        isTracking = false;
    }

    private GameObject[] FindPlayer(){
        return GameObject.FindGameObjectsWithTag("Player");
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }

    void UpdateSpeed(float newSpeed, NavMeshAgent agent) {
        if (agent.speed != newSpeed) {
            agent.speed = newSpeed;
        }
    }

}