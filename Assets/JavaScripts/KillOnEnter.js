#pragma strict

function OnTriggerEnter(collider:Collider)
{
	var snakeModel:SnakeModel = collider.transform.GetComponent(SnakeModel);
	if(snakeModel.IsCritical())
	{
		snakeModel.KillSnake();
	}else{
		snakeModel.CutHere();
	}
}