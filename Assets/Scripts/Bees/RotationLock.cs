using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLock : MonoBehaviour {

	// Use this for initialization

	float lockPos = 0;

	void Update()
	{
		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);
	}
}
