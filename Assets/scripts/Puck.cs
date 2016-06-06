using UnityEngine;
using System.Collections;

public class Puck : MonoBehaviour 
{
	void Start ()
	{
		_rigidBody = GetComponent<Rigidbody> ();
		Vector3 fixedPosition = transform.position;
		fixedPosition.z = -0.6248822f;
		transform.position = fixedPosition;
	}

	void FixedUpdate ()
	{
		//_trailParticles.transform.rotation
	}

	public void launch (Vector2 direction)
	{
		Debug.Log ("Launching puck in direction: " + direction);
		_rigidBody.AddForce (direction.normalized * _speed);
	}

	void OnCollisionEnter (Collision c)
	{
		IHitable hitableObject = c.gameObject.GetComponent<IHitable> ();
		if (hitableObject != null)
		{ 
			hitableObject.OnPuckEnter ();
		}
		Debug.Log ("V: " + _rigidBody.velocity);

	}

	void OnCollisionExit (Collision c)
	{
		IHitable hitableObject = c.gameObject.GetComponent<IHitable> ();
		if (hitableObject != null)
		{ 
			hitableObject.OnPuckExit ();
			Instantiate (_hitParticles, transform.position, transform.rotation);
		}
		Debug.Log ("V: " + _rigidBody.velocity);

	}

	public float _speed;
	public ParticleSystem _hitParticles;

	Rigidbody _rigidBody;
}
