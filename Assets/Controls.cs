using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

	public Vector2 movementSpeed;
	public float rotationSpeed;
	Rigidbody2D rb;
	// Use this for initialization
	//Ctor for gameobjects
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		rotation *= Time.deltaTime;
		transform.Rotate (0, 0, -rotation);


		Vector2 accel = Input.GetAxis("Vertical") * movementSpeed;
		accel *= Time.deltaTime;
		GetComponent<Rigidbody2D> ().AddRelativeForce (accel, ForceMode2D.Impulse);
		GetComponent<LineRenderer>().startColor = Color.red;
		GetComponent<LineRenderer> ().SetPosition (0, transform.position);
		Vector3 endpoint = transform.up;
		GetComponent<LineRenderer> ().SetPosition (1, transform.up + transform.position);
		GetComponent<LineRenderer> ().startWidth = .2f;

		//GetComponent<Rigidbody2D> ().AddTorque (rotation * rotationForce * Time.deltaTime);

	}
}
