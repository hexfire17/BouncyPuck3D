using UnityEngine;
using System.Collections;

public class Puck : MonoBehaviour 
{
	//TODO tail just like bullets
	void Start ()
	{
		_rigidBody = GetComponent<Rigidbody> ();
		Vector3 fixedPosition = transform.position;
		fixedPosition.z = -0.6248822f;
		transform.position = fixedPosition;
	}

	public void launch (Vector2 direction)
	{
		Debug.Log ("Launching puck in direction: " + direction);
		_rigidBody.AddForce (direction.normalized * _speed);
	}

	public void Destroy()
	{
		Debug.Log ("Destroy puck");
		GameObject.Destroy (gameObject);
		OnPuckDestroy ();
	}

	void OnCollisionEnter (Collision c)
	{
		IHitable hitableObject = c.gameObject.GetComponent<IHitable> ();
		if (hitableObject != null)
		{ 
			hitableObject.OnEnter (this); // TODO pass puck in
		}
	}

	void OnCollisionExit (Collision c)
	{
		IHitable hitableObject = c.gameObject.GetComponent<IHitable> ();
		if (hitableObject != null)
		{ 
			hitableObject.OnExit (this);
			Instantiate (_hitParticles, transform.position, transform.rotation);
		}
	}

	public float _speed;
	public ParticleSystem _hitParticles;
	public event System.Action OnPuckDestroy;

	Rigidbody _rigidBody;
}
