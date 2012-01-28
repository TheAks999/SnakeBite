#pragma strict

var modelScript:SnakeModel; 


public var initialSnakeSize : int = 10;
public var criticalSectionSize : int = 5;

private var timestep : float = 0;

function Start ()
{
	
}

function Update () 
{
	timestep += Time.deltaTime;
	if (timestep > .5)
	{
		Debug.Log("Change direction");
	
		if (transform.position.x > 20 || transform.position.x < -20 || 
			transform.position.z > 20 || transform.position.z < -20 )
		{
				modelScript.TurnLeft();
		}
		else
		{
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
	}
	
	modelScript.UpdatePosition();
}	

function Setup()
{
	modelScript = GetComponent("SnakeModel");
	modelScript.MakeSnake(initialSnakeSize,Direction.EAST,criticalSectionSize);
}
