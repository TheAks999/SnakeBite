using UnityEngine;
using System.Collections;

public class ScoreWorth : MonoBehaviour 
{
	Hud hud;
	Score score;
	
	public int worth = 0;
	
	void Start()
	{
		GameObject scoreObject = GameObject.Find("ScoreObject");
		hud = scoreObject.GetComponent("Hud");
		score = scoreObject.GetComponent("Score");
	}
	
	
	void OnDestroy()
	{
		if(!hud.IsLost())
		{
			if (gameObject.name != playerObjectName)
			{
			
				SnakePiece thisPiece = (SnakePiece) GetComponent("SnakePiece");
				
				if (snakePiece)
				{
					SnakeModel model = snakePiece.GetModel();
					if (model.controlType == SnakeModel.ControlType.PLAYERKEYBOARD)
					{
						return;
					}
				}
				
				score.CombineScore(pointWorth);
			}
			
		}
	}

}
