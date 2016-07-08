using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public static InputManager SINGLETON;
	bool mouseInputDown = false;
	bool touchInputDown = false;
	bool inputDown = false;

	// Use this for initialization
	void Start () {
		SINGLETON = this;
	}
	
	// Update is called once per frame
	void Update () {
		inputManager ();
	}

	public bool getInputDown()
	{
		return inputDown;
	}

	void inputManager()
	{

		
		if (Input.touchCount > 0) {
			
			if(!touchInputDown)
			{
				touchInputDown = true;
				inputDown = true;
				
			}
			
		}
		else if(Input.touchCount == 0)
		{
			if(touchInputDown)
			{
				touchInputDown = false;
				inputDown = false;
			}
		}

		if (Input.GetMouseButtonDown (0)) {

			if(!mouseInputDown)
			{
				mouseInputDown = true;
				inputDown = true;
				
			}

		} else if(Input.GetMouseButtonUp(0)){
			mouseInputDown = false;
			inputDown = false;
		}


	}

	public Vector2 getPos()
	{
		if (mouseInputDown) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray))
				return new Vector2(ray.GetPoint(1).x, ray.GetPoint(1).y);
		} else if (touchInputDown) {
			for (var i = 0; i < Input.touchCount; ++i){
				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
				if (Physics.Raycast(ray))
					return new Vector2(ray.GetPoint(1).x, ray.GetPoint(1).y);
			}
		}

		return new Vector2(0,0);
	}





}
