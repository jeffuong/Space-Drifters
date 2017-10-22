// EXTEND
//
// Camera --> GetObjectOnScreen(), GetObjectOnScreen2D()

using UnityEngine;
using System.Collections;

public static class CameraExtension
{
	/// GetObjectOnScreen()
	//
	/// <summary>
	/// Gets the game-obj in this camera's screen view at the specified screen coordinates.
	/// Returns null if there are no hits.
	/// </summary>
	/// 
	/// <remarks>
	/// Uses Unity's built-in raycasting functions for calculation.
	/// See Physics.Raycast for more info.
	/// </remarks>
	public static GameObject GetObjectOnScreen( this Camera cam, Vector3 screenCoords, 
	                                           float maxDistance = Mathf.Infinity, 
	                                           int layerMask = Physics.DefaultRaycastLayers, 
	                                           QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal )
	{
		//variables
		Ray ray;					//ray cast from point on screen forward
		RaycastHit hit;				//first raycast hit

		//raycast
		ray = cam.ScreenPointToRay( screenCoords );
		if ( Physics.Raycast(ray, out hit, maxDistance, layerMask, queryTriggerInteraction) )
			return hit.collider.gameObject;

		//no hits
		return null;
	}
	//
	/// <summary>
	/// Gets the game-obj in this camera's screen view at the specified screen coordinates.
	/// Returns null if there are no hits.
	/// </summary>
	/// 
	/// <remarks>
	/// Uses Unity's built-in raycasting functions for calculation.
	/// See Physics.Raycast for more info.
	/// </remarks>
	//
	//	Implicit conversion: Vector2 to Vector3
	//
	//	public static GameObject GetObjectOnScreen( this Camera cam, Vector2 screenCoords, 
	//	                                            float maxDistance = Mathf.Infinity, 
	//	                                            int layerMask = Physics.DefaultRaycastLayers, 
	//	                                            QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal )
	//	{
	//		//variables
	//		Vector3 coords = new Vector3( screenCoords.x, screenCoords.y );
	//
	//		return GetObjectOnScreen( cam, coords, maxDistance, layerMask, queryTriggerInteraction );
	//	}
	//
	/// <summary>
	/// Gets the game-obj in this camera's screen view at the specified screen coordinates.
	/// Returns null if there are no hits.
	/// </summary>
	/// 
	/// <remarks>
	/// Uses Unity's built-in raycasting functions for calculation.
	/// See Physics.Raycast for more info.
	/// </remarks>
	public static GameObject GetObjectOnScreen( this Camera cam, float x, float y, 
	                                           float maxDistance = Mathf.Infinity, 
	                                           int layerMask = Physics.DefaultRaycastLayers, 
	                                           QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal )
	{
		//variables
		Vector3 coords = new Vector3( x, y );

		return GetObjectOnScreen( cam, coords, maxDistance, layerMask, queryTriggerInteraction );
	}


	/// GetObjectOnScreen2D()
	//
	/// <summary>
	/// Gets the game-obj in this camera's screen view at the specified screen coordinates.
	/// Returns null if there are no hits.
	/// For 2D colliders.
	/// </summary>
	/// 
	/// <remarks>
	/// Uses Unity's built-in raycasting functions for calculation.
	/// See Physics2D.Raycast for more info.
	/// </remarks>
	public static GameObject GetObjectOnScreen2D( this Camera cam, Vector3 screenCoords, 
	                                             float distance = Mathf.Infinity, 
	                                             int layerMask = Physics2D.DefaultRaycastLayers, 
	                                             float minDepth = -Mathf.Infinity, 
	                                             float maxDepth = Mathf.Infinity )
	{
		//variables
		Ray ray;					//ray cast from point on screen forward
		RaycastHit2D hit;				//first raycast hit

		//raycast
		ray = cam.ScreenPointToRay( screenCoords );
		hit = Physics2D.Raycast(ray.origin, ray.direction, distance, layerMask, minDepth, maxDepth);
		if ( hit.collider != null )
			return hit.collider.gameObject;

		//no hits
		return null;
	}
	//
	/// <summary>
	/// Gets the game-obj in this camera's screen view at the specified screen coordinates.
	/// Returns null if there are no hits.
	/// For 2D colliders.
	/// </summary>
	/// 
	/// <remarks>
	/// Uses Unity's built-in raycasting functions for calculation.
	/// See Physics2D.Raycast for more info.
	/// </remarks>
	//
	//	Implicit conversion: Vector2 to Vector3
	//
	//	public static GameObject GetObjectOnScreen2D( this Camera cam, Vector2 screenCoords, 
	//	                                              float distance = Mathf.Infinity, 
	//	                                              int layerMask = Physics2D.DefaultRaycastLayers, 
	//	                                              float minDepth = -Mathf.Infinity, 
	//	                                              float maxDepth = Mathf.Infinity )
	//	{
	//		//variables
	//		Vector3 coords = new Vector3( screenCoords.x, screenCoords.y );
	//
	//		return GetObjectOnScreen2D( cam, coords, distance, layerMask, minDepth, maxDepth );
	//	}
	//
	/// <summary>
	/// Gets the game-obj in this camera's screen view at the specified screen coordinates.
	/// Returns null if there are no hits.
	/// For 2D colliders.
	/// </summary>
	/// 
	/// <remarks>
	/// Uses Unity's built-in raycasting functions for calculation.
	/// See Physics2D.Raycast for more info.
	/// </remarks>
	public static GameObject GetObjectOnScreen2D( this Camera cam, float x, float y,  
	                                             float distance = Mathf.Infinity, 
	                                             int layerMask = Physics2D.DefaultRaycastLayers, 
	                                             float minDepth = -Mathf.Infinity, 
	                                             float maxDepth = Mathf.Infinity )
	{
		//variables
		Vector3 coords = new Vector3( x, y );

		return GetObjectOnScreen2D( cam, coords, distance, layerMask, minDepth, maxDepth );
	}


}


/*
using UnityEngine;
using System.Collections;

// Example Usage

// for 3D colliders
GameObject gObj = Camera.main.GetObjectOnScreen( Input.mousePosition );
if ( gObj != null )
	Debug.Log( gObj.tag );

// for 2D colliders
GameObject gObj = Camera.main.GetObjectOnScreen2D( Input.mousePosition );
if ( gObj != null )
	Debug.Log( gObj.tag );

*/
