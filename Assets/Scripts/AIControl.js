#pragma strict

var modelScript:SnakeModel; 


public var initialSnakeSize : int = 10;
public var criticalSectionSize : int = 5;

private var timestep : float = 0;

function Start ()
{
	modelScript = GetComponent("SnakeModel");
	modelScript.MakeSnake(initialSnakeSize,Direction.EAST,criticalSectionSize);

	
}

function Update () 
{
	timestep += Time.deltaTime;
	if (timestep > .5)
	{
		Debug.Log("Change direction");
	
		
		var choice:int = Random.Range(1,100);
		
		if (choice < 51)
		{
			//go straight
			
			//do nothing now
		}
		else if (choice < 76)
		{
			//go left
			modelScript.TurnLeft();
			
		}
		else if (choice >= 76 &&choice <= 100)
		{
			//go right
			modelScript.TurnRight();
		}
		timestep = 0;
	}
	
	modelScript.UpdatePosition();
}	