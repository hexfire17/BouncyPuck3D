using UnityEngine;
using System.Collections;
using UnityEditor;

public class SoftTarget : MonoBehaviour, IHitable
{
	public void OnPuckEnter ()
	{
		Debug.Log ("Hit soft");
	}

	public void OnPuckExit ()
	{
		Debug.Log ("Destroy soft");
		ParticleSystem.ShapeModule x = _deathEffect.shape;
		x.box = transform.localScale;
		Destroy (gameObject);
		ParticleSystem deathEffect = Instantiate (_deathEffect, transform.position, transform.rotation) as ParticleSystem;
	}

	public ParticleSystem _deathEffect;
}
