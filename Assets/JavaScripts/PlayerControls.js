#pragma strict
private var turnScript:SnakeModel;

public var initialSnakeSize : int = 10;
public var criticalSectionSize : int = 5;
public var growthFactor : int = 100;
private var growth : int = 0;

 
function Start () 
{
	turnScript = GetComponent("SnakeModel");
}

function Update () 
{
	//Debug.Log(Input.GetButtonDown("Horizontal"));
	if(Input.GetKeyDown(KeyCode.A))
	{
		
		//checkPosition.SetCommand(checkPosition.Command.TurnLeft);
		turnScript.TurnLeft();
	}
	else if(Input.GetKeyDown(KeyCode.D))
	{
		//checkPosition.SetCommand(checkPosition.Command.TurnRight);
		turnScript.TurnRight();
	}
	
	/*if (growth < growthFactor)
	{
		growth ++;
		//Debug.Log("Growth: " + growth);
	}
	else
	{
		growth = 0;
		turnScript.Grow(5);
		
	}*/
	
	
	turnScript.UpdatePosition();
}




function Setup()
{
	turnScript = GetComponent("SnakeModel");
	turnScript.MakeSnake(initialSnakeSize,Direction.EAST,criticalSectionSize);
}