using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
	// Use this for initialization
	void Start () 
	{
		_levelGenerator = FindObjectOfType<LevelGenerator> ();
		_levelGenerator._levelIndex = 0;
		NextLevel ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Return)) {
			NextLevel ();
		}
	}

	void NextLevel ()
	{
		_levelGenerator.GenerateLevel ();
		_levelGenerator._levelIndex++;
	}

	LevelGenerator _levelGenerator;
}
