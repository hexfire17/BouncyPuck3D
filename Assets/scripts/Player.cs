using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	void Start () 
	{
		_camera = FindObjectOfType<Camera> ();
		_isAiming = false;
	}
	
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			if (_puck != null) { Destroy (_puck.gameObject); }
			_isAiming = true;

			_puck = Instantiate (_puckPrefab,  GetMousePosition (), _puckPrefab.transform.rotation) as Puck; 
		} 
		else if (Input.GetMouseButtonUp (0))
		{
			//Destroy (_aimParticles.gameObject);
			_isAiming = false;

			_aimDirection = _puck.transform.position - GetMousePosition ();
			_puck.launch (_aimDirection);
		}
		else if (_isAiming) {
			if (_aimParticles == null) {
				_aimParticles = Instantiate (_aimParticlePrefab, GetMousePosition (), _aimParticlePrefab.transform.rotation) as ParticleSystem;
			}
				
			_aimParticles.transform.LookAt (2 * _aimParticles.transform.position - GetMousePosition ());
			_aimDirection = _puck.transform.position - GetMousePosition ();
		}
	}

	Vector3 GetMousePosition ()
	{
		Vector3 inputPosition = Input.mousePosition;
		float distFromCamera = Mathf.Abs(_camera.transform.position.z);
		inputPosition.z = distFromCamera;

		Vector3 mousePosition = _camera.ScreenToWorldPoint(inputPosition);
		mousePosition.z = 0;
		return mousePosition;
	}

	public Puck _puckPrefab;
	public ParticleSystem _aimParticlePrefab;

	Puck _puck;
	Camera _camera;
	ParticleSystem _aimParticles;

	bool _isAiming;
	Vector2 _aimDirection;
}
