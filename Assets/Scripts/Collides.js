#pragma strict

function OnTriggerEnter (other : Collider) 
{
	if(other.GetComponent(SnakeModel))
	{
    	var snake:SnakeModel = other.GetComponent(SnakeModel);
    	if(snake.IsCritical())
    	{
    		Debug.Log("KILL!!");
    		snake.KillSnake();
    	}
    	else
    	{
    		Debug.Log("CUT!!");
    		snake.CutHere();
    	}
    }
}