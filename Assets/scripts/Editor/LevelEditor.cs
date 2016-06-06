using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof(LevelGenerator))]
public class LevelEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI ();
		if (GUILayout.Button("Generate Level"))
		{
			GetGenerator ().GenerateLevel ();
		}

		if (GUILayout.Button ("Soft Object"))
		{
			GetGenerator ().NewSoftObject ();
		}

		if (GUILayout.Button ("Save Level"))
		{
			GetGenerator ().SaveLevel ();
		}
	}

	LevelGenerator GetGenerator ()
	{
		LevelGenerator generator = target as LevelGenerator;
		return generator;
	}
}
