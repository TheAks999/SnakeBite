#pragma strict
private var turnScript:SnakeModel;
public var initialSnakeSize : int = 10;
public var criticalSectionSize : int = 5;


function Start () 
{
	turnScript = GetComponent("SnakeModel");
	turnScript.MakeSnake(initialSnakeSize,Direction.WEST,criticalSectionSize);
}

function Update () 
{

	if(Input.GetAxis("Horizontal") < 0)
	{
		//checkPosition.SetCommand(checkPosition.Command.TurnLeft);
		turnScript.TurnLeft();
	}
	else if(Input.GetAxis("Horizontal") > 0)
	{
		//checkPosition.SetCommand(checkPosition.Command.TurnRight);
		turnScript.TurnRight();
	}
	
	turnScript.UpdatePosition();
}

function OnGUI()
{
	GUI.Label(Rect(Screen.width - 200, 0, 200,50), Time.realtimeSinceStartup.ToString());
}