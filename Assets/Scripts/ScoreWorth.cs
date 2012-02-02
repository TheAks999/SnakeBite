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
		hud = (Hud) scoreObject.GetComponent("Hud");
		score = (Score) scoreObject.GetComponent("Score");
	}
	
	
	void OnDestroy()
	{
		if(!hud.IsGameOver())
		{
			
			SnakePiece thisPiece = (SnakePiece) GetComponent("SnakePiece");
			
			if (thisPiece)
			{
				SnakeModel model = thisPiece.GetModel();
				if (model.controlType == SnakeModel.ControlType.PLAYERKEYBOARD)
				{
					return;
				}
			}
			
			score.CombineScore(worth);
		
		
		}
	}

}
