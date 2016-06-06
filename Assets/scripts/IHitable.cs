using UnityEngine;
using System.Collections;

public interface IHitable
{
	void OnPuckEnter ();
	void OnPuckExit ();
}
