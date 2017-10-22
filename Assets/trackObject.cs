using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackObject : MonoBehaviour {

	public Transform target;
	public float speed = 1.0f;

	void Update () {
		Vector3 v3 = transform.position;
		v3.x = Mathf.Lerp (v3.x, target.position.x, speed);
		v3.y = Mathf.Lerp (v3.y, target.position.y, speed);
		transform.position = new Vector3(v3.x, v3.y, -10);
	}
}
