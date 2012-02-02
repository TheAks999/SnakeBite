using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour 
{
	public int onCollectGrowAmmount = 0;
	
	void OnTriggerEnter(Collider collider)
	{
		SnakePiece piece = (SnakePiece) collider.GetComponent("SnakePiece");
		if (piece)
		{
			if (onCollectGrowAmmount > 0)
			{
				Debug.Log("Should grow");
				piece.GetModel().Grow(onCollectGrowAmmount);
			}
			
			Destroy(gameObject);
		}
	}
}
