using UnityEngine;
using System.Collections;

public class Deathtrap : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
	{
		SnakePiece snakePiece = (SnakePiece) collider.transform.GetComponent("SnakeModel");
		
		if (snakePiece)
		{
		
		}
	}
}
