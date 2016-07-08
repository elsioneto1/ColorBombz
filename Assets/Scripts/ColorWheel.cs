using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorWheel : MonoBehaviour {

	public static ColorWheel SINGLETON;
	public GameObject mainQuad;

	Transform _transform;
	bool positioned = false;
	public List<GameObject> palletes;
	public float distanceCheck;

	public string selectedPallete;
	// Use this for initialization
	void Start () {
		SINGLETON = this;
		_transform = transform;
	}
	
	// Update is called once per frame
	void Update () {

		if (LevelManager.GAMEOVER || LevelManager.NEXTLEVEL) {
			return;
		}

		if (AttackBomb.SINGLETON.bombing)
			return;

		updateWheelPosition ();
		togglePallete ();
	}

	void updateWheelPosition()
	{
		
		if (InputManager.SINGLETON.getInputDown () && !positioned) {

			positioned = true;
			transform.position = new Vector3(InputManager.SINGLETON.getPos().x,
			                                 InputManager.SINGLETON.getPos().y,
			                                 -4);
			
			if ( transform.position.x < -2)
			{
				transform.position = new Vector3(-2,transform.position.y,-1);
			}
			if ( transform.position.x > 2)
			{
				transform.position = new Vector3(2,transform.position.y,-1);
			}
			if ( transform.position.y < -3)
			{
				transform.position = new Vector3(transform.position.x,-3,-1);
			}
			if ( transform.position.y > 5)
			{
				transform.position = new Vector3(transform.position.x,5,-1);
			}
			
		}
		else if (!InputManager.SINGLETON.getInputDown ())
		{
			if ( positioned)
			{
				usePallete(mainQuad.GetComponent<Renderer>().material);
				transform.position = new Vector3(20,
				                                 20,
				                                 -1);

				positioned = false;
			}
		}
	}

	void togglePallete()
	{

		for (int i = 0; i < palletes.Count; i++) {
			if ( Vector3.Distance(new Vector3(InputManager.SINGLETON.getPos().x,
			                                  InputManager.SINGLETON.getPos().y,
			                                  palletes[i].transform.position.z), palletes[i].transform.position) < distanceCheck)
			{
				palletes[i].transform.localScale = new Vector3(0.4f,0.4f,1);
				selectedPallete = palletes[i].name;
				mainQuad.GetComponent<Renderer>().material = palletes[i].GetComponent<Renderer>().material;
				return;
			}
			else
			{
				selectedPallete = "";
				palletes[i].transform.localScale = new Vector3(0.3f,0.3f,1);
			}
		}


	}

	void usePallete(Material material)
	{

		AttackBomb.SINGLETON.StartAttack (_transform.position, material);
		AttackBomb.SINGLETON.color = selectedPallete;
		selectedPallete = "";
	}

}
