using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackBomb : MonoBehaviour {

	// bomb size
	public float size;
	Transform _transform;
	public static AttackBomb SINGLETON;
	public string color;
	public bool bombing = false;

	// Use this for initialization
	void Start () {
		_transform = transform;
		SINGLETON = this;
	}
	
	// Update is called once per frame
	void Update () {
		verifyWon();
	}

	void verifyWon()
	{
		if (ObjectCountManager.SINGLETON.objectsTaken == 0) {
			LevelManager.NEXTLEVEL = true;
		}
	}

	public IEnumerator attackBomb()
	{

		//_transform.position 	= new Vector3(InputManager.SINGLETON.getPos().x, InputManager.SINGLETON.getPos().y, -1);
		bombing = true;
		while ( _transform.localScale.y - size < -0.03f ) 
		{

			_transform.localScale = Vector3.Lerp(_transform.localScale, new Vector3(size,size,0), 0.1f);
			verifyHits();

			yield return new WaitForSeconds (0.016f);
		}
		int i;
		for (i = 0; i < Spawner.SINGLETON.theLargePool.Count; i++) {
			Spawner.SINGLETON.theLargePool[i].bombTouched = false;
		}
			
		_transform.localScale 	= new Vector3 (0.7f, 0.7f, 1);
		_transform.position 	= new Vector3 (50,50,0);
		bombing 				= false;

		if (LevelManager.NEXTLEVEL) {

			LevelManager.SINGLETON.callLevelCountdown();

		}
	}

	public void StartAttack(Vector3 pos, Material material)
	{
		_transform.GetComponent<Renderer>().material = material;
		_transform.position = pos;
		StartCoroutine("attackBomb");

	}

	void spawnNegativePixels(string s1, string s2, int jIndex,List<GameObject> list)
	{
		if ( color == s1 && Spawner.SINGLETON.theLargePool[jIndex].color == s2 && Vector3.Distance(transform.position, 
		                                                                      new Vector3(Spawner.SINGLETON.theLargePool[jIndex].transform.position.x,
		            																	  Spawner.SINGLETON.theLargePool[jIndex].transform.position.y,
		            																											 transform.position.z)) < size * 0.5f)
		{
			int i;
			for ( i = 0 ; i < list.Count; i++)
			{
				if ( !list[i].GetComponent<PixelActive>().active && !Spawner.SINGLETON.theLargePool[jIndex].bombTouched)
				{
					Spawner.SINGLETON.theLargePool[jIndex].bombTouched = true;
					list[i].GetComponent<PixelActive>().active = true;
					list[i].GetComponent<PixelActive>().bombTouched = true;
					list[i].transform.position = new Vector3(Random.Range(-2.0f,2.0f),Random.Range(-3.0f,5.0f),-0.7f);
					LevelManager.SINGLETON.setForces(list[i].GetComponent<Rigidbody>());
					list[i].GetComponent<PixelActive>().color = s2;
					list[i].GetComponent<PixelActive>().spawned = true;
					ObjectCountManager.SINGLETON.objectsTaken++;
				}
			}
		}
	}

	void verifyHits()
	{

		int j;
		for (j = 0; j < Spawner.SINGLETON.theLargePool.Count; j++) {
			if ( Spawner.SINGLETON.theLargePool[j].active)
			{
				if (Vector3.Distance(transform.position, 
				                     new Vector3(Spawner.SINGLETON.theLargePool[j].transform.position.x,
				            Spawner.SINGLETON.theLargePool[j].transform.position.y,
				            transform.position.z)) < gameObject.transform.localScale.y *0.5f)
				{
					if ( color == Spawner.SINGLETON.theLargePool[j].color )
					{
						Spawner.SINGLETON.theLargePool[j].GetComponent<Rigidbody>().velocity = Vector3.zero;
						Spawner.SINGLETON.theLargePool[j].transform.position = new Vector3(10,0,0);
						Spawner.SINGLETON.theLargePool[j].active = false;
						ObjectCountManager.SINGLETON.objectsTaken--;
						size += 0.1f;

					}
					else
					{

						spawnNegativePixels("Red","Blue",j,Spawner.SINGLETON.Blue);
						spawnNegativePixels("Blue","Red",j,Spawner.SINGLETON.Red);
						spawnNegativePixels("Pink","Green",j,Spawner.SINGLETON.Pink);
						spawnNegativePixels("Green","Pink",j,Spawner.SINGLETON.Green);
						spawnNegativePixels("White","Black",j,Spawner.SINGLETON.White);
						spawnNegativePixels("Black","White",j,Spawner.SINGLETON.Black);
						spawnNegativePixels("NavyBlue","Yellow",j,Spawner.SINGLETON.NavyBlue);
						spawnNegativePixels("Yellow","NavyBlue",j,Spawner.SINGLETON.Yellow);

					}
				}
			}
		}
	}
}
