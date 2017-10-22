using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackhole : MonoBehaviour {

	public float RealitiveWeight;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void OnTriggerStay2D (Collider2D other) {
		float magsqr;
		Vector2 offset;
		offset = transform.position - other.transform.position;
		magsqr = offset.sqrMagnitude;
		Debug.Log (magsqr);
		if (magsqr < 1.0f) {
			
			player.GetComponent<Rigidbody2D> ().AddForce ((RealitiveWeight * offset.normalized / magsqr) * other.GetComponent<Rigidbody2D> ().mass, ForceMode2D.Force);
		}

	}
		

}
