using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour 
{
	public void Awake()
	{
		Debug.Log ("Level Generator Started");
		FindObjectOfType<Game> ().OnLoadLevel += GenerateLevel;
	}

	public void GenerateLevel(int levelIndex)
	{
		Debug.Log ("Generating level " + levelIndex);

		if (transform.FindChild (_holderName))
		{
			DestroyImmediate(transform.FindChild(_holderName).gameObject);
		}

		_targetsRemaining = 0;
		_currentLevel = _levels [levelIndex];
		foreach (LevelObject o in _currentLevel._levelObjects)
		{
			Transform t = Object.Instantiate (o._prefab, o._position, o._rotation) as Transform;
			t.transform.localScale = o._scale;
			t.parent = GetLevelHolder ();

			if (t.GetComponent<Target> () != null) {
				_targetsRemaining++;
				t.GetComponent<Target> ().OnDestroy += OnTargetDestroy;
			}
		}
	}
		
	public void SaveLevel (int levelIndex)
	{
		Debug.Log ("Saving level " + levelIndex);
		_currentLevel = _levels [levelIndex];

		_currentLevel._levelObjects = new List<LevelObject> ();
		foreach(Transform child in GetLevelHolder ())
		{
			LevelObject levelObject = new LevelObject ();
			levelObject._position = child.position;
			levelObject._scale = child.localScale;
			levelObject._rotation = child.transform.rotation;
			levelObject._prefab = GetPrefab (child.name);
			_currentLevel._levelObjects.Add (levelObject);
		}
	}

	private void OnTargetDestroy ()
	{
		_targetsRemaining--;
		Debug.Log ("Targets Remaining: " + _targetsRemaining);
		if (_targetsRemaining == 0) {
			OnLevelComplete ();
		}
	}

	public Transform GetLevelHolder ()
	{
		if (transform.FindChild (_holderName) != null) {
			_levelHolder = transform.FindChild (_holderName);
		}
		if (_levelHolder == null) 
		{
			_levelHolder = new GameObject(_holderName).transform;
			_levelHolder.parent = transform;
		}
		return _levelHolder;
	}

	public Transform GetPrefab (string name)
	{
		for (int i = 0; i < _prefabMapping.Count; i++)
		{
			if (name.Contains (_prefabMapping.ToArray () [i]._name)) {
				return _prefabMapping.ToArray () [i]._prefab;
			}
		}
		return null;
	}
		
	[System.Serializable]
	public class Level
	{
		public List<LevelObject> _levelObjects;
	}

	[System.Serializable]
	public class LevelObject
	{
		public Transform _prefab;
		public Vector3 _position;
		public Vector3 _scale;
		public Quaternion _rotation;
	}

	public Level[] _levels;
	Level _currentLevel;

	Transform _levelHolder;
	const string _holderName = "LevelHolder";

	private int _targetsRemaining;

	public event System.Action OnLevelComplete;

	[System.Serializable]
	public class PrefabMapping
	{
		public string _name;
		public Transform _prefab;
	}
	public List<PrefabMapping> _prefabMapping;
}
