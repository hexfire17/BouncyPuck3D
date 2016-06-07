using UnityEngine;
using System.Collections;

public class Guardian : MonoBehaviour, IHitable
{
	public void OnEnter (Puck puck)
	{
		Debug.Log ("Hit Target");
	}

	public void OnExit (Puck puck)
	{
		puck.Destroy ();
	}
}
