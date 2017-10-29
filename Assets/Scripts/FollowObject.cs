using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {

	// ENUMS //
	enum FollowState { IDLE, TRAIL, GAIN, NON_STATE };

	// VARIABLES //
	private Transform target;						//target followed
	private FollowState state = FollowState.IDLE;	//current state (state machine A.I.)
	//
	public float rotationSway = 0.0f;				//rotation sway (can overshoot)
	public float rotationSpeed = 3.0f;				//rotation speed (springs once)
	public float maxTrail = 0.0f;					//maximum trailing distance
	public float gainSpeed = 4.0f;					//follow speed

	//
	//	private bool _isCatchingUp = false;		//flag: catch-up mode (gains on target)
	//	private float _catchupDistance = 0.0f;	//distance remaining to catchup (for catch-up mode)

	// Use this for initialization
	void Start()
	{
		//init target ...this->CameraStand->PlayerShip
		target = gameObject.transform.parent.parent;

	}

	void Update()
	{
		//state machine
		switch ( state )
		{
			case FollowState.IDLE:
				Idling();
				break;
			case FollowState.TRAIL:
				Trailing();
				break;
			case FollowState.GAIN:
				Gaining();
				break;
			default:
				Debug.Log( "Invalid State\t...in FollowObjects script" );
				gameObject.DebugLineage();
				break;
		}
	}


	///////////////
	// BEHAVIORS //
	///////////////

	public void Idling()
	{
		
	}

	public void Trailing()
	{

	}

	public void Gaining()
	{

	}

}
