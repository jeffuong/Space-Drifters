using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {

	// VARIABLES //
	public Transform target;				//target to follow
	public float offset = 0.0f;				//offset forward/backward (+/-)
	public float speed = 4.0f;				//follow speed [0-1]
	public float maxDistance = 3.0f;		//maximum distance from target
	//
	//	private bool _isCatchingUp = false;		//flag: catch-up mode (gains on target)
	//	private float _catchupDistance = 0.0f;	//distance remaining to catchup (for catch-up mode)

	//testing...
	public Vector3 targetVelocity;
	public Vector3 targetPosition;
	public Vector3 ownPosition;
	public float distanceTo;
	public float targetSpeed;
	//
	void Update() {
		targetVelocity = target.gameObject.GetComponent<Rigidbody2D>().velocity;
		targetPosition = target.position;
		ownPosition = transform.position;
		//
		Vector3 ownPosFlat = ownPosition;
		ownPosFlat.z = 0.0f;
		distanceTo = (targetPosition - ownPosFlat).magnitude;
		targetSpeed = targetVelocity.magnitude;
	}

	void FixedUpdate () {

		//NOTE:		Causes jittering if done in Update() instead.
		//			Not sure why. It might be due to lerp consistency for smoothness.

		//calculate new position
		Vector3 offset_vec = target.up.normalized * offset;
		Vector3 new_pos = target.position + offset_vec;

		//set new position
		new_pos.z = transform.position.z;
		transform.position = Vector3.Lerp (transform.position, new_pos, speed * Time.fixedDeltaTime);// Time.deltaTime);

		//cap max distance
		Vector3 gap_vec = new_pos - transform.position;
		//
		//testing...
		transform.position = new_pos - (gap_vec.normalized * maxDistance);
		//
		if (gap_vec.magnitude > maxDistance)
		{
			transform.position = new_pos - (gap_vec.normalized * maxDistance);
			//			_isCatchingUp = true;
		}

		//catch-up
		//float distance = Mathf.Lerp (

		//@TOFIX:		Currently has bugs (i.e. camera doesn't catch up, etc.).
		//				Need to make the camera behavior dynamic and induce tension.
	}
}
