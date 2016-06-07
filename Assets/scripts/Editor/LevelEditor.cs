using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof(LevelGenerator))]
public class LevelEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI ();
		if (GUILayout.Button("Load Level"))
		{
			GetGenerator ().GenerateLevel (_levelIndex);
		}

		if (GUILayout.Button ("Save Level"))
		{
			GetGenerator ().SaveLevel (_levelIndex);
		}

		if (GUILayout.Button ("Next Level"))
		{
			_levelIndex++;
			GetGenerator ().GenerateLevel (_levelIndex);
		}

		if (GUILayout.Button ("Prev Level"))
		{
			_levelIndex--;
			GetGenerator ().GenerateLevel (_levelIndex);
		}
			
		if (GUILayout.Button ("Soft Object"))
		{
			GetGenerator ().NewSoftObject (_levelIndex);
		}

	}

	LevelGenerator GetGenerator ()
	{
		LevelGenerator generator = target as LevelGenerator;
		return generator;
	}

	public int _levelIndex;
}
