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
		ParticleSystem deathEffect = Instantiate (_deathEffect, transform.position, transform.rotation) as ParticleSystem;
		deathEffect.transform.localScale = transform.localScale;
	}

	public ParticleSystem _deathEffect;
}
