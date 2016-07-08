using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	public static Spawner SINGLETON;

	public GameObject prefab;

	public List<PixelActive> theLargePool;
	public List<GameObject> Pink;
	public List<GameObject> Blue;
	public List<GameObject> NavyBlue;
	public List<GameObject> Red;
	public List<GameObject> Yellow;
	public List<GameObject> Green;
	public List<GameObject> Black;
	public List<GameObject> White;
	
	public Material mPink;
	public Material mBlue;
	public Material mNavyBlue;
	public Material mRed;
	public Material mYellow;
	public Material mGreen;	
	public Material mBlack;
	public Material mWhite;

	// Use this for initialization
	void Start () {
		SINGLETON = this;

		createObjects (mPink,Pink);
		createObjects (mBlue,Blue);
		createObjects (mNavyBlue, NavyBlue);
		createObjects (mRed,Red);
		createObjects (mYellow,Yellow);
		createObjects (mGreen,Green);
		createObjects (mBlack,Black);
		createObjects (mWhite,White);

	}
	
	// Update is called once per frame
	void Update () {
			
	}

	void createObjects(Material m, List<GameObject> l)
	{

		int i ;
		for (i = 0; i < 100; i++) {
			//PHYSICS BETWEEN THE SAME OBJECT DISABLED THROUGH LAYERING
			Object o = Instantiate(prefab,new Vector3(10,0,0), Quaternion.identity);
			GameObject go = (GameObject)o;
			go.transform.parent = gameObject.transform;
			//go.GetComponent<SphereCollider>().enabled = false;
			go.GetComponent<MeshRenderer>().material = m;
			theLargePool.Add(go.GetComponent<PixelActive>());
			l.Add(go);
		}
	}

}
