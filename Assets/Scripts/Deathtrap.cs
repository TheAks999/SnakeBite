using UnityEngine;
using System.Collections;

public class Deathtrap : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
	{
		Debug.Log("Ran into something");
	
		SnakePiece snakePiece = (SnakePiece) collider.GetComponent("SnakePiece");
		
		if (snakePiece != null)
		{
			snakePiece.snakeModel.KillSnake();
		}
	}
}
