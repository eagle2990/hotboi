using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedOverTime : MonoBehaviour {

	UnityEngine.AI.NavMeshAgent agent;
	//max speed that can be attained
	float speedCap = 12f;

	void Start () 
	{
		//get NavMeshAgent component from gameObject that this script is attached to 
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		//begin increasing speed (StartCoroutine)
		StartCoroutine("IncreaseSpeedPerSecond", 1f);

	}

	IEnumerator IncreaseSpeedPerSecond (float waitTime)
	{
		//while agent's speed is less than the speedCap
		while (agent.speed < speedCap)
		{
			//wait "waitTime"
			yield return new WaitForSeconds(waitTime);
			//add 0.5f to currentSpeed every loop 
			agent.speed = agent.speed + 0.1f;
		}
	}
}