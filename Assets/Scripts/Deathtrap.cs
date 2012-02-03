using UnityEngine;
using System.Collections;

public class Deathtrap : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
	{
	
		SnakePiece snakePiece = (SnakePiece) collider.GetComponent("SnakePiece");
		
		if (snakePiece != null)
		{
			snakePiece.snakeModel.KillSnake();
		}
	}
}
