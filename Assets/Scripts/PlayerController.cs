using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour 
{
	[SerializeField] private Rigidbody playerRigid;
	[SerializeField] private AudioSource shotAudio; //had to fix this, as audio.Play doesn't work anymore in Unity 5 and up. Aswell as rigidbody.velocity. Some recommended GetComponent, I used this.

	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 0.5f;
	private float nextFire = 0.0f;

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

	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			shotAudio.Play ();
		}
	}
}