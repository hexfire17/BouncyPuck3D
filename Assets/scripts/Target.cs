using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour, IHitable
{
	public void OnEnter (Puck puck)
	{
		Debug.Log ("Hit Target");
	}

	public void OnExit (Puck puck)
	{
		Debug.Log ("Destroyed Target");
		Destroy (gameObject);
		SpawnDeathEffect ();
		OnDestroy ();
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
	public event System.Action OnDestroy;
}
