using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
	void Awake ()
	{
		FindObjectOfType<LevelGenerator> ().OnLevelComplete += NextLevel;
	}

	// Use this for initialization
	void Start () 
	{
		_currLevel = -1;
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
		_currLevel++;
		OnLoadLevel (_currLevel);
	}

	LevelGenerator _levelGenerator;
	public event System.Action<int> OnLoadLevel;
	private int _currLevel;
}
