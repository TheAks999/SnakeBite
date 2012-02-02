using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour 
{
	public int onCollectGrowAmmount = 0;
	
	void OnTriggerEnter(Collider collider)
	{
		SnakePiece piece = (SnakePiece) collider.GetComponent("SnakePiece");
		if (piece)
		{
			if (onCollectGrowAmmount > 0)
				piece.GetModel().Grow(onCollectGrowAmmount);
		
			Destroy(gameObject);
		}
	}
}
