using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public static StartGame SINGLETON; 

	// Use this for initialization
	void Start () {

		SINGLETON = this;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startGame()
	{
		gameObject.SetActive (false);
		LevelManager.SINGLETON.callLevelCountdown ();
	}
}
