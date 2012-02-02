using UnityEngine;
using System.Collections;

public class PlayerController : Controller 
{
	
	
	// Use this for initialization
	void Start () 
	{
		mover = (Movement) GetComponent("Movement");
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log(Input.GetButtonDown("Horizontal"));
		if(Input.GetKeyDown(KeyCode.A))
		{
			
			//checkPosition.SetCommand(checkPosition.Command.TurnLeft);
			mover.TurnLeft();
		}
		else if(Input.GetKeyDown(KeyCode.D))
		{
			//checkPosition.SetCommand(checkPosition.Command.TurnRight);
			mover.TurnRight();
		}
	}
}
