using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//basicaly, constrols everything. lol
public class LevelManager : MonoBehaviour {

	public static LevelManager SINGLETON; 
	public List<LevelAsset> levels;
	public int currentLevel = -1;
	public Text Level;
	public static bool GAMEOVER = false;
	public static bool NEXTLEVEL = false;
	public bool changeLevelNow = false;
	public float spawnQuantity;
	public Text respawnQtty;


	// Use this for initialization
	void Start () {

		GAMEOVER = false;
		SINGLETON = this;
		Level.color = new Vector4 (Level.color.r,Level.color.g,Level.color.b, 0);
	//	StartCoroutine ("levelCountdown");

	}

	public void callLevelCountdown()
	{
		StartCoroutine ("levelCountdown");
	}

	public int maxPixels()
	{
		if (currentLevel < 0)
			return 0;

		return levels [currentLevel].maxNumberOfPixels;

	}

	IEnumerator levelCountdown()
	{
		GAMEOVER = false;
		Level.color = new Vector4 (Level.color.r,Level.color.g,Level.color.b, 255);
		ObjectCountManager.SINGLETON.gameOver.gameObject.SetActive(false);
		Level.text = "LEVEL " + (currentLevel + 2);
		yield return new WaitForSeconds (2.0f);
		currentLevel++;
		Level.color = new Vector4 (Level.color.r,Level.color.g,Level.color.b, 0);
		AttackBomb.SINGLETON.size = 1.66f;
		changeLevel();
		NEXTLEVEL = false;
		spawnQuantity = levels [currentLevel].pixelsRespawn;
		Timer.SINGLETON.currentTimer = levels[currentLevel].TimeSpawn;
		Timer.SINGLETON.time = Timer.SINGLETON.currentTimer;

		
	}

	public void SpawnPixels()
	{

		float spawnValue = Mathf.Floor (spawnQuantity);
		
		int pinkProb 		=  0 + LevelManager.SINGLETON.levels[LevelManager.SINGLETON.currentLevel].pPink;
		int blueProb 		=  pinkProb + LevelManager.SINGLETON.levels[LevelManager.SINGLETON.currentLevel].pBlue;
		int navyBlueProb 	=  blueProb + LevelManager.SINGLETON.levels[LevelManager.SINGLETON.currentLevel].pNavyBlue; 
		int redProb 		=  navyBlueProb + LevelManager.SINGLETON.levels[LevelManager.SINGLETON.currentLevel].pRed; 
		int yellowProb 		=  redProb + LevelManager.SINGLETON.levels[LevelManager.SINGLETON.currentLevel].pYellow; 
		int greenProb 		=  yellowProb + LevelManager.SINGLETON.levels[LevelManager.SINGLETON.currentLevel].pGreen; 
		int blackProb 		=  greenProb + LevelManager.SINGLETON.levels[LevelManager.SINGLETON.currentLevel].pBlack; 
		int whiteProb 		=  blackProb + LevelManager.SINGLETON.levels[LevelManager.SINGLETON.currentLevel].pWhite;


		for (int i = 0; i < spawnValue; i++) {

			int random = Random.Range(0,100);
			int j;

			if ( random <= pinkProb)
			{

				for ( j = 0 ; j < Spawner.SINGLETON.Pink.Count; j++)
				{
					if ( !Spawner.SINGLETON.Pink[j].GetComponent<PixelActive>().active)
					{
						Spawner.SINGLETON.Pink[j].GetComponent<PixelActive>().active = true;
						Spawner.SINGLETON.Pink[j].transform.position = new Vector3(Random.Range(-2.0f,2.0f),Random.Range(-3.0f,5.0f),-0.7f);
						LevelManager.SINGLETON.setForces(Spawner.SINGLETON.Pink[j].GetComponent<Rigidbody>());
						Spawner.SINGLETON.Pink[j].GetComponent<PixelActive>().color = "Pink";
						Spawner.SINGLETON.Pink[j].GetComponent<PixelActive>().spawned = true;
						ObjectCountManager.SINGLETON.objectsTaken++;
						break;
					}
				}
			}
			if ( random > pinkProb && random <= blueProb)
			{
				for ( j = 0 ; j < Spawner.SINGLETON.Blue.Count; j++)
				{
					if ( !Spawner.SINGLETON.Blue[j].GetComponent<PixelActive>().active)
					{
						Spawner.SINGLETON.Blue[j].GetComponent<PixelActive>().active = true;
						Spawner.SINGLETON.Blue[j].transform.position = new Vector3(Random.Range(-2.0f,2.0f),Random.Range(-3.0f,5.0f),-0.7f);
						LevelManager.SINGLETON.setForces(Spawner.SINGLETON.Blue[j].GetComponent<Rigidbody>());
						Spawner.SINGLETON.Blue[j].GetComponent<PixelActive>().color = "Blue";
						Spawner.SINGLETON.Blue[j].GetComponent<PixelActive>().spawned = true;
						ObjectCountManager.SINGLETON.objectsTaken++;
						break;
					}
				}
			}
			if ( random > blueProb && random <= navyBlueProb)
			{
				for ( j = 0 ; j < Spawner.SINGLETON.NavyBlue.Count; j++)
				{
					if ( !Spawner.SINGLETON.NavyBlue[j].GetComponent<PixelActive>().active)
					{
						Spawner.SINGLETON.NavyBlue[j].GetComponent<PixelActive>().active = true;
						Spawner.SINGLETON.NavyBlue[j].transform.position = new Vector3(Random.Range(-2.0f,2.0f),Random.Range(-3.0f,5.0f),-0.7f);
						LevelManager.SINGLETON.setForces(Spawner.SINGLETON.NavyBlue[j].GetComponent<Rigidbody>());
						Spawner.SINGLETON.NavyBlue[j].GetComponent<PixelActive>().color = "NavyBlue";
						Spawner.SINGLETON.NavyBlue[j].GetComponent<PixelActive>().spawned = true;
						ObjectCountManager.SINGLETON.objectsTaken++;
						break;
					}
				}
			}
			if ( random > navyBlueProb && random <= redProb)
			{
			
				for ( j = 0 ; j < Spawner.SINGLETON.Red.Count; j++)
				{
					if ( !Spawner.SINGLETON.Red[j].GetComponent<PixelActive>().active)
					{
						Spawner.SINGLETON.Red[j].GetComponent<PixelActive>().active = true;
						Spawner.SINGLETON.Red[j].transform.position = new Vector3(Random.Range(-2.0f,2.0f),Random.Range(-3.0f,5.0f),-0.7f);
						LevelManager.SINGLETON.setForces(Spawner.SINGLETON.Red[j].GetComponent<Rigidbody>());
						Spawner.SINGLETON.Red[j].GetComponent<PixelActive>().color = "Red";
						Spawner.SINGLETON.Red[j].GetComponent<PixelActive>().spawned = true;
						ObjectCountManager.SINGLETON.objectsTaken++;
						break;
					}
				}
			}
			if ( random > redProb && random <= yellowProb)
			{
				for ( j = 0 ; j < Spawner.SINGLETON.Yellow.Count; j++)
				{
					if ( !Spawner.SINGLETON.Yellow[j].GetComponent<PixelActive>().active)
					{
						Spawner.SINGLETON.Yellow[j].GetComponent<PixelActive>().active = true;
						Spawner.SINGLETON.Yellow[j].transform.position = new Vector3(Random.Range(-2.0f,2.0f),Random.Range(-3.0f,5.0f),-0.7f);
						LevelManager.SINGLETON.setForces(Spawner.SINGLETON.Yellow[j].GetComponent<Rigidbody>());
						Spawner.SINGLETON.Yellow[j].GetComponent<PixelActive>().color = "Yellow";
						Spawner.SINGLETON.Yellow[j].GetComponent<PixelActive>().spawned = true;
						ObjectCountManager.SINGLETON.objectsTaken++;
						break;
					}
				}
			}
			if ( random > yellowProb && random <= greenProb)
			{
				for ( j = 0 ; j < Spawner.SINGLETON.Green.Count; j++)
				{
					if ( !Spawner.SINGLETON.Green[j].GetComponent<PixelActive>().active)
					{
						Spawner.SINGLETON.Green[j].GetComponent<PixelActive>().active = true;
						Spawner.SINGLETON.Green[j].transform.position = new Vector3(Random.Range(-2.0f,2.0f),Random.Range(-3.0f,5.0f),-0.7f);
						LevelManager.SINGLETON.setForces(Spawner.SINGLETON.Green[j].GetComponent<Rigidbody>());
						Spawner.SINGLETON.Green[j].GetComponent<PixelActive>().color = "Green";
						Spawner.SINGLETON.Green[j].GetComponent<PixelActive>().spawned = true;
						ObjectCountManager.SINGLETON.objectsTaken++;
						break;
					}
				}
			}
			if ( random > greenProb && random <= blackProb)
			{
				for ( j = 0 ; j < Spawner.SINGLETON.Black.Count; j++)
				{
					if ( !Spawner.SINGLETON.Black[j].GetComponent<PixelActive>().active)
					{
						Spawner.SINGLETON.Black[j].GetComponent<PixelActive>().active = true;
						Spawner.SINGLETON.Black[j].transform.position = new Vector3(Random.Range(-2.0f,2.0f),Random.Range(-3.0f,5.0f),-0.7f);
						LevelManager.SINGLETON.setForces(Spawner.SINGLETON.Black[j].GetComponent<Rigidbody>());
						Spawner.SINGLETON.Black[j].GetComponent<PixelActive>().color = "Black";
						Spawner.SINGLETON.Black[j].GetComponent<PixelActive>().spawned = true;
						ObjectCountManager.SINGLETON.objectsTaken++;
						break;
					}
				}
			}
			if ( random > blackProb && random <= whiteProb)
			{
				for ( j = 0 ; j < Spawner.SINGLETON.White.Count; j++)
				{
					if ( !Spawner.SINGLETON.White[j].GetComponent<PixelActive>().active)
					{
						Spawner.SINGLETON.White[j].GetComponent<PixelActive>().active = true;
						Spawner.SINGLETON.White[j].transform.position = new Vector3(Random.Range(-2.0f,2.0f),Random.Range(-3.0f,5.0f),-0.7f);
						LevelManager.SINGLETON.setForces(Spawner.SINGLETON.White[j].GetComponent<Rigidbody>());
						Spawner.SINGLETON.White[j].GetComponent<PixelActive>().color = "Black";
						Spawner.SINGLETON.White[j].GetComponent<PixelActive>().spawned = true;
						ObjectCountManager.SINGLETON.objectsTaken++;
						break;
					}
				}
			}
		}

		spawnQuantity = spawnQuantity + ((spawnQuantity/100) * LevelManager.SINGLETON.levels[LevelManager.SINGLETON.currentLevel].IncreaseRate_Percentage);
	

	}

	// Update is called once per frame
	void Update () {

		if (changeLevelNow) {
			changeLevelNow = false;
		}
		float qt = Mathf.Floor (spawnQuantity);
		respawnQtty.text = "RespawnQt : " + qt.ToString ();

	}

	public void changeLevel()
	{
		setPixelsBack ();
		startNewLevel ();
	}


	public void setPixelsBack()
	{
		int i;
		for (i = 0; i < Spawner.SINGLETON.Pink.Count; i++) {
			Spawner.SINGLETON.Pink[i].transform.position = new Vector3(10,0,0);
			Spawner.SINGLETON.Pink[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
		for (i = 0; i < Spawner.SINGLETON.Blue.Count; i++) {
			
			Spawner.SINGLETON.Blue[i].transform.position = new Vector3(10,0,0);
			Spawner.SINGLETON.Blue[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
		for (i = 0; i < Spawner.SINGLETON.NavyBlue.Count; i++) {
			
			Spawner.SINGLETON.NavyBlue[i].transform.position = new Vector3(10,0,0);
			Spawner.SINGLETON.NavyBlue[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
		for (i = 0; i < Spawner.SINGLETON.Red.Count; i++) {
			
			Spawner.SINGLETON.Red[i].transform.position = new Vector3(10,0,0);
			Spawner.SINGLETON.Red[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
		for (i = 0; i < Spawner.SINGLETON.Yellow.Count; i++) {
			
			Spawner.SINGLETON.Yellow[i].transform.position = new Vector3(10,0,0);
			
			Spawner.SINGLETON.Yellow[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
		for (i = 0; i < Spawner.SINGLETON.Green.Count; i++) {
			
			Spawner.SINGLETON.Green[i].transform.position = new Vector3(10,0,0);
			Spawner.SINGLETON.Green[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
		for (i = 0; i < Spawner.SINGLETON.Black.Count; i++) {
			
			Spawner.SINGLETON.Black[i].transform.position = new Vector3(10,0,0);
			
			Spawner.SINGLETON.Black[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
		for (i = 0; i < Spawner.SINGLETON.White.Count; i++) {
			
			Spawner.SINGLETON.White[i].transform.position = new Vector3(10,0,0);
			
			Spawner.SINGLETON.White[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
		}

		for (i = 0; i < Spawner.SINGLETON.theLargePool.Count; i++) {

			Spawner.SINGLETON.theLargePool[i].active = false;

		}
	}

	void startNewLevel()
	{
		if (currentLevel < levels.Count) {
			int i;
			for ( i = 0 ; i < levels[currentLevel].numPinks; i++)
			{

				Spawner.SINGLETON.Pink[i].transform.position = new Vector3(Random.Range(-2.0f,2.0f),Random.Range(-3.0f,5.0f),-0.7f);
				setForces(Spawner.SINGLETON.Pink[i].GetComponent<Rigidbody>());
				Spawner.SINGLETON.Pink[i].GetComponent<PixelActive>().color = "Pink";
				ObjectCountManager.SINGLETON.objectsTaken++;
			}
			for ( i = 0 ; i < levels[currentLevel].numBlue; i++)
			{
				Spawner.SINGLETON.Blue[i].transform.position = new Vector3(Random.Range(-2.0f,2.0f),Random.Range(-3.0f,5.0f),-0.7f);
				setForces(Spawner.SINGLETON.Blue[i].GetComponent<Rigidbody>());
				Spawner.SINGLETON.Blue[i].GetComponent<PixelActive>().color = "Blue";
				ObjectCountManager.SINGLETON.objectsTaken++;
			}
			for ( i = 0 ; i < levels[currentLevel].numNavyBlue; i++)
			{
				Spawner.SINGLETON.NavyBlue[i].transform.position =  new Vector3(Random.Range(-2.0f,2.0f),Random.Range(-3.0f,5.0f),-0.7f);
				setForces(Spawner.SINGLETON.NavyBlue[i].GetComponent<Rigidbody>());
				Spawner.SINGLETON.NavyBlue[i].GetComponent<PixelActive>().color = "NavyBlue";
				ObjectCountManager.SINGLETON.objectsTaken++;
			}
			for ( i = 0 ; i < levels[currentLevel].numRed; i++)
			{
				Spawner.SINGLETON.Red[i].transform.position = new Vector3(Random.Range(-2.0f,2.0f),Random.Range(-3.0f,5.0f),-0.7f);
				setForces(Spawner.SINGLETON.Red[i].GetComponent<Rigidbody>());
				Spawner.SINGLETON.Red[i].GetComponent<PixelActive>().color = "Red";
				ObjectCountManager.SINGLETON.objectsTaken++;
			}
			for ( i = 0 ; i < levels[currentLevel].numYellow; i++)
			{
				Spawner.SINGLETON.Yellow[i].transform.position = new Vector3(Random.Range(-2.0f,2.0f),Random.Range(-3.0f,5.0f),-0.7f);
				setForces(Spawner.SINGLETON.Yellow[i].GetComponent<Rigidbody>());
				Spawner.SINGLETON.Yellow[i].GetComponent<PixelActive>().color = "Yellow";
				ObjectCountManager.SINGLETON.objectsTaken++;
			}
			for ( i = 0 ; i < levels[currentLevel].numGreen; i++)
			{
				Spawner.SINGLETON.Green[i].transform.position = new Vector3(Random.Range(-2.0f,2.0f),Random.Range(-3.0f,5.0f),-0.7f);
				setForces(Spawner.SINGLETON.Green[i].GetComponent<Rigidbody>());
				Spawner.SINGLETON.Green[i].GetComponent<PixelActive>().color = "Green";
				ObjectCountManager.SINGLETON.objectsTaken++;
			}
			for ( i = 0 ; i < levels[currentLevel].numBlack; i++)
			{
				Spawner.SINGLETON.Black[i].transform.position = new Vector3(Random.Range(-2.0f,2.0f),Random.Range(-3.0f,5.0f),-0.7f);
				setForces(Spawner.SINGLETON.Black[i].GetComponent<Rigidbody>());
				Spawner.SINGLETON.Black[i].GetComponent<PixelActive>().color = "Black";
				ObjectCountManager.SINGLETON.objectsTaken++;
			}
			for ( i = 0 ; i < levels[currentLevel].numWhite; i++)
			{
				Spawner.SINGLETON.White[i].transform.position = new Vector3(Random.Range(-2.0f,2.0f),Random.Range(-3.0f,5.0f),-0.7f);
				setForces(Spawner.SINGLETON.White[i].GetComponent<Rigidbody>());
				Spawner.SINGLETON.White[i].GetComponent<PixelActive>().color = "White";
				ObjectCountManager.SINGLETON.objectsTaken++;
			}

		}
	}


	public void setForces(Rigidbody rb)
	{
		rb.gameObject.GetComponent<PixelActive> ().active = true;
		rb.gameObject.GetComponent<PixelActive> ().spawned = true;
		int direcX = Random.Range (0,10);
		int direcY = Random.Range (0,10);

		if (direcX < 5) {
			direcX = -1;
		} else {
			direcX = 1;
		}

		if (direcY < 5) {
			direcY = -1;
		} else {
			direcY = 1;
		}

		int x = direcX * Random.Range (101, levels[currentLevel].maxForceX);
		int y = direcY * Random.Range (101, levels[currentLevel].maxForceY);

		rb.AddForce (x,y,0);
	}

	public void clearAll()
	{
		setPixelsBack ();
		currentLevel = -1;
	}
}
