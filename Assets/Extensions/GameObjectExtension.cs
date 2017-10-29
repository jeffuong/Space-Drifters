// EXTEND
//
// GameObject 	--> Has()
//					GetParent(), SetParent()
//					GetRoot()
//					DebugLineage()

using UnityEngine;
using System.Collections;
using System.Collections.Generic;			// IEnumberable<>

public static class GameObjectExtension
{
	/// Has()
	//
	/// <summary>
	/// Checks if the game-obj has the specified component-type.
	/// </summary>
	public static bool Has( this GameObject gObj, System.Type cType )
	{
		return ( gObj.GetComponent( cType ) != null );
	}
	//
	/// <summary>
	/// Checks if the game-obj has the specified component-types.
	/// </summary>
	public static bool Has( this GameObject gObj, 
	                       IEnumerable<System.Type> cTypeList, 
	                       bool requiresAll = true)
	{
		if ( requiresAll )
		{
			//has ALL ...of the specified types in the list to return true
			foreach (System.Type type in cTypeList)
			{
				if ( !gObj.Has(type) )
					return false;
			}
			//
			return true;
		}
		else
		{
			//has ANY ...of the specified types in the list to return true
			foreach (System.Type type in cTypeList)
			{
				if ( gObj.Has(type) )
					return true;
			}
			//
			return false;
		}
	}


	// GetParent(), SetParent()
	//
	/// <summary>
	/// Gets the parent GameObject of this game-obj.
	/// Returns 'null' if no parent is found.
	/// </summary>
	/// 
	/// <remarks>
	/// The parent-child relation actually belongs to the Transform.
	/// In Unity, the Transform component cannot be removed.
	/// It is used to determine the default hierarchy.
	/// </remarks>
	public static GameObject GetParent( this GameObject gObj )
	{
		if ( gObj.transform.parent != null )
			return gObj.transform.parent.gameObject;
		else
			return null;
	}
	//
	/// <summary>
	/// Sets the parent GameObject of this game-obj.
	/// Assigns 'null' if no parent is found.
	/// </summary>
	/// 
	/// <remarks>
	/// The parent-child relation actually belongs to the Transform.
	/// In Unity, the Transform component cannot be removed.
	/// It is used to determine the default hierarchy.
	/// </remarks>
	public static void SetParent( this GameObject gObj, GameObject parent )
	{
		if ( parent.Has(typeof(Transform)) )
			gObj.transform.SetParent( parent.transform );
		else
			gObj.transform.SetParent( null );
	}
	//
	//NOTE:		At the time of writing, C# does not support 
	//			extension properties yet, only extension methods.

	// GetRoot()
	//
	/// <summary>
	/// Gets the top-level ancestor GameObject of this game-obj (at global level).
	/// Returns itself if no parent is found (already global level).
	/// </summary>
	/// 
	/// <remarks>
	/// The parent-child relation actually belongs to the Transform.
	/// In Unity, the Transform component cannot be removed.
	/// It is used to determine the default hierarchy.
	/// </remarks>
	public static GameObject GetRoot( this GameObject gObj )
	{
		return gObj.transform.root.gameObject;
	}


	// DebugLineage()
	//
	/// <summary>
	/// Traces out GameObject lineage via Debug.Log()
	/// </summary>
	/// 
	/// <remarks>
	/// Uses the GetParent() extension method.
	/// </remarks>
	public static void DebugLineage( this GameObject gObj )
	{
		//lineage
		GameObject current_obj = gObj;							//current GameObject in the trace
		string lineage = gObj.name;								//lineage up to global
		//
		while ( current_obj.GetParent() != null )
		{
			lineage += " <- " + current_obj.GetParent().name;	//concat parent name
			current_obj = current_obj.GetParent();				//walk up lineage tree
		}
		//
		lineage += " <- GLOBAL";

		//trace out
		Debug.Log( "\t" + lineage );
	}


}


/*	Has()

using UnityEngine;
using System.Collections;
using System.Collections.Generic;		//List<T>

// Example Usage

// single-type argument
if ( gameObject.Has(typeof(Transform)) )
	Debug.Log( "Has the specified component." );

// type-list argument
List< System.Type > typeList = new List< System.Type >();
typeList.Add( typeof(Transform) );
typeList.Add( typeof(Rigidbody) );
typeList.Add( typeof(BoxCollider) );
//
if ( gameObject.Has( typeList ) )
	Debug.Log( "Has all components in the type-list." );
//
if ( gameObject.Has( typeList, false ) )
	Debug.Log( "Has at least one of the componenets in the type-list." );

/*

/*	GetParent(), SetParent()

using UnityEngine;
using System.Collections;

// Example Usage

// get parent
GameObject parentObj = gameObject.GetParent();

// set parent
GameObject newParent = new GameObject();
gameObject.SetParent( newParent );

// unparent
gameObject.SetParent( null );

/*

/*	GetRoot()

using UnityEngine;
using System.Collections;

// Example Usage

// get root parent
GameObject rootObj = gameObject.GetRoot();

/*

/*	DebugLineage()

using UnityEngine;
using System.Collections;

// Example Usage

// trace out lineage
gameObject.DebugLineage();

*/
