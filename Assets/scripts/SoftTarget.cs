using UnityEngine;
using System.Collections;

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
		SpawnDeathEffect ();
	}

	private void SpawnDeathEffect ()
	{
		ParticleSystem deathEffect = Instantiate (_deathEffect, transform.position, transform.rotation) as ParticleSystem;
		ParticleSystem.ShapeModule shape = deathEffect.shape;
		shape.box = transform.localScale;

		ParticleSystem.EmissionModule emission = deathEffect.emission;
		ParticleSystem.MinMaxCurve rate = emission.rate;
		rate.constantMax = 1000 * (transform.localScale.x + transform.localScale.y + transform.localScale.z);
		emission.rate = rate;
	}

	public ParticleSystem _deathEffect;
}
