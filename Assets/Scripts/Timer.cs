using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	public Text txt;
	public static Timer SINGLETON;
	public float time;
	public float currentTimer;
	// Use this for initialization
	void Start () {

		SINGLETON = this;

	}
	 
	// Update is called once per frame
	void Update () {
		
		if (LevelManager.GAMEOVER || LevelManager.NEXTLEVEL) {
			return;
		}

		if (time > 0) {
			time -= Time.deltaTime;
			txt.text = time.ToString("F2");
		} else {
			txt.text = "0.00";
			// verify if the game started
			if (LevelManager.SINGLETON.currentLevel > -1)
			{
				currentTimer = currentTimer + ((currentTimer/100 ) * LevelManager.SINGLETON.levels[LevelManager.SINGLETON.currentLevel].IncreaseRate_Percentage);
				time = currentTimer;
				LevelManager.SINGLETON.SpawnPixels();
			}
		}

	}
}
