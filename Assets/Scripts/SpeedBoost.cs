using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour {
	public float speedBoost = 10.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Player") {
			Debug.Log ("Collide with Player");
			Vector2 force = coll.GetComponent<Rigidbody2D> ().velocity.normalized * speedBoost;
			coll.GetComponent<Rigidbody2D> ().AddForce (force, ForceMode2D.Impulse);
		}
			
	}
}
