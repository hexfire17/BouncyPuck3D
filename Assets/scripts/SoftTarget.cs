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
		Destroy (gameObject);
		ParticleSystem deathEffect = Instantiate (_deathEffect, transform.position, transform.rotation) as ParticleSystem;

		// TODO why does this work... but shape.box = doesn't...?
		ParticleSystem.ShapeModule shape = deathEffect.shape;
		shape.box = transform.localScale;
	}

	public ParticleSystem _deathEffect;
}
