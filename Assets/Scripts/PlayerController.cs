using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour {
	[SerializeField] private Rigidbody playerRigid;
	public float speed;
	public float tilt;
	public Boundary boundary;

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");


		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		playerRigid.velocity = movement * speed;

		playerRigid.position = new Vector3 
			(
				Mathf.Clamp (playerRigid.position.x, boundary.xMin, boundary.xMax),
				0.0f, 
				Mathf.Clamp (playerRigid.position.z, boundary.zMin, boundary.zMax)
			);
		playerRigid.rotation = Quaternion.Euler (0.0f, 0.0f, playerRigid.velocity.x * -tilt);
	}

}
