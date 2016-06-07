using UnityEngine;
using System.Collections;

public interface IHitable
{
	void OnEnter (Puck puck);
	void OnExit (Puck puck);
}
