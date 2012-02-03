using UnityEngine;
using System.Collections;

public class SnakeCollision : MonoBehaviour 
{
	void OnTriggerEnter (Collider collider) 
	{
		SnakePiece snakePiece = (SnakePiece)collider.GetComponent("SnakePiece");
		if(snakePiece)
		{
			SnakePiece thisPiece = (SnakePiece)GetComponent("SnakePiece");
			
			if (thisPiece)
			{
				if (thisPiece.IsHead() && snakePiece.IsHead())
				{
					thisPiece.snakeModel.KillSnake();
					snakePiece.snakeModel.KillSnake();
					return;
				}	
	    	}
	    	
	    	SnakeModel snake = snakePiece.snakeModel;
	    	
	    	snake.CutSnakeAt(collider.gameObject,gameObject);
	    	
	    }
	}
}
