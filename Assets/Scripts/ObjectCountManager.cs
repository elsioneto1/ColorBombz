using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObjectCountManager : MonoBehaviour {

	public static ObjectCountManager SINGLETON;
	public Text counter;
	public int objectsTaken = 0;
	public Text gameOver;
	// Use this for initialization
	void Start () {
		SINGLETON = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (counter != null) {

			counter.text = objectsTaken.ToString() + "/" +  LevelManager.SINGLETON.maxPixels().ToString();
		}

		if (objectsTaken > LevelManager.SINGLETON.maxPixels () && !LevelManager.GAMEOVER) {
			LevelManager.GAMEOVER = true;
			gameOver.gameObject.SetActive(true);
			gameOver.enabled = true;
			StartCoroutine("backToScreen");

		}
	}

	IEnumerator backToScreen()
	{
		yield return new WaitForSeconds(2.0f);
		gameOver.enabled = false;
		gameOver.gameObject.SetActive(false);
		StartGame.SINGLETON.gameObject.SetActive (true);
		LevelManager.SINGLETON.clearAll ();	
		LevelManager.GAMEOVER = true;
		LevelManager.NEXTLEVEL = false;
		objectsTaken = 0;
		Timer.SINGLETON.time = 0;
		ColorWheel.SINGLETON.gameObject.transform.position = new Vector3 (59,0,0);

	}
}
