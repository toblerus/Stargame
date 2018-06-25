using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour 
{
	[SerializeField] private Rigidbody asteroidRigid;
	public float tumble;

	void Start()
	{
		asteroidRigid.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
