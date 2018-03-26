using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Follow : MonoBehaviour 
{
	private NavMeshAgent myAgent;
	public Transform target;
    bool isTracking;
    GameObject player;

	void Start () 
	{
        GameObject[] playerList = FindPlayer();
        if (playerList != null && playerList.Length > 0) {
            player = playerList[2];
            isTracking = player.activeInHierarchy;
            myAgent = GetComponent<NavMeshAgent>();
            target = player.transform;
        }
	}

	void Update () 
	{
        if (isTracking)
        {
            myAgent.SetDestination(target.position);
        }
	}
    public void StopNavAgent()
    {
        isTracking = false;
    }

    private GameObject[] FindPlayer()
    {
        return GameObject.FindGameObjectsWithTag("Player");
    }

}