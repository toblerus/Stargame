using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour 
{
	[SerializeField] private Rigidbody boltRigid;
	public float speed; 
	void Start ()
	{
		boltRigid.velocity = transform.forward * speed;
	}
}
