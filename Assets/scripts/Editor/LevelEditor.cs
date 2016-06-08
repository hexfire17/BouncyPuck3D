using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor (typeof(LevelGenerator))]
public class LevelEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI ();

		Object[] objs = Resources.LoadAll ("LevelPrefabs", typeof (GameObject));
		_prefabs = new Transform[objs.Length];
		for (int i = 0; i < objs.Length; i++) {
			_prefabs [i] = ((GameObject) objs [i]).GetComponent<Transform> ();
		}

		GUILayout.BeginHorizontal ();
		for (int i = 0; i < _prefabs.Length; i++) {
			if (GUILayout.Button(AssetPreview.GetAssetPreview (objs[i]), GUILayout.MaxWidth(50), GUILayout.MaxHeight(50)))
			{
				_selectedPrefab = _prefabs[i];
				PlaceObject ((Transform)_selectedPrefab);
			}
		}
		GUILayout.EndHorizontal ();

		if (GUILayout.Button("Load Level"))
		{
			GetGenerator ().GenerateLevel (_levelIndex, true);
		}

		if (GUILayout.Button ("Save Level"))
		{
			GetGenerator ().SaveLevel (_levelIndex);
		}

		if (GUILayout.Button ("Next Level"))
		{
			_levelIndex++;
			GetGenerator ().GenerateLevel (_levelIndex, true);
		}

		if (GUILayout.Button ("Prev Level"))
		{
			_levelIndex--;
			GetGenerator ().GenerateLevel (_levelIndex, true);
		}
	}

	public void PlaceObject (Transform prefab)
	{
		Transform t = Instantiate (prefab, Vector3.zero, prefab.transform.rotation) as Transform;
		t.transform.parent = GetGenerator ().GetLevelHolder ();
	}
		
	LevelGenerator GetGenerator ()
	{
		LevelGenerator generator = target as LevelGenerator;
		return generator;
	}

	Transform[] _prefabs;
	Transform _selectedPrefab;

	public int _levelIndex;
}
