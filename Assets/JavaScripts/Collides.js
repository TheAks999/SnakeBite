#pragma strict

function OnTriggerEnter (other : Collider) 
{
	if(other.GetComponent(SnakeModel))
	{
    	var snake:SnakeModel = other.GetComponent(SnakeModel);
    	if(snake.IsCritical())
    	{
    		var head:SnakeModel = snake.GetHead().GetComponent(SnakeModel);
    		//Debug.Log("KILL!!");
    		head.KillSnake();
    	}
    	else
    	{
    		//Debug.Log("CUT!!");
    		snake.CutHere();
    	}
    }
}