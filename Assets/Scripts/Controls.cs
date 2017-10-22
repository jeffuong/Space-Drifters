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
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () 
	{
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		rotation *= Time.deltaTime;
		transform.Rotate (0, 0, -rotation);


		Vector2 accel = Input.GetAxis("Vertical") * movementSpeed;
		accel *= Time.deltaTime;
		rb.AddRelativeForce (accel, ForceMode2D.Impulse);
		GetComponent<LineRenderer>().startColor = Color.red;
		GetComponent<LineRenderer> ().SetPosition (0, transform.position);
		Vector3 endpoint = transform.up;
		GetComponent<LineRenderer> ().SetPosition (1, transform.up + transform.position);
		GetComponent<LineRenderer> ().startWidth = .2f;

		//GetComponent<Rigidbody2D> ().AddTorque (rotation * rotationForce * Time.deltaTime);

		//input: SPACE -> stop
		if ( Input.GetKeyDown(KeyCode.Space) )
			rb.velocity = new Vector2( 0.0f, 0.0f );	//stops

	}
}
