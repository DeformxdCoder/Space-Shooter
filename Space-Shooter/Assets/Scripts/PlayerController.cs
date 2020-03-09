using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;			//Store Boundary values from Unity
}

public class PlayerController : MonoBehaviour
{
	public float speed;								//Storing Values and Prefabs from Unity
	public float Cooldown;
	private float nextFireTime = 0;
	public Boundary boundary;
	public GameObject bullet;


	//Updates based on frequency set in Unity Engine
	void FixedUpdate()
	{

		float moveHorizontal = Input.GetAxis("Horizontal");				//Accept left and right input on direction
		float moveVertical = Input.GetAxis("Vertical");					//Accept up and down input on direction

		Vector2 movement = new Vector2(moveHorizontal, moveVertical);		//Set movement direction equal to input
		GetComponent<Rigidbody2D>().velocity = movement * speed;			//Multiply speed by movement direction and set as velocity

		GetComponent<Rigidbody2D>().position = new Vector2(		Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),		//Force player inside boundary X and Y values
																Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax)
															);
	}
	
	//Updates every frame
	void Update()
	{
			if (Time.time > nextFireTime)				//Check if Cooldown (if any) has elapsed
			{
					if (Input.GetKey("space"))					//When spacebar is pressed shoot
					{
				Vector3 bulletSpawn = new Vector3(transform.position.x, transform.position.y + 1, 0.0f);		//Set spawn of next bullet to 1 unit in front of ship (to avoid immediate suicide)
							Instantiate(bullet, bulletSpawn, Quaternion.identity);			//Spawn Bullet
							nextFireTime = Time.time + Cooldown;				//Disable firing until Cooldown time has passed
					}
			}
	}

	private void OnTriggerEnter2D()
	{
		Destroy(gameObject);			//Destroy on Contact
	}
}


