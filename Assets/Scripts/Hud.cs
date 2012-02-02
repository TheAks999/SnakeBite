using UnityEngine;
using System.Collections;

public class Hud : MonoBehaviour 
{
		
	bool gameOver = false;	
	
	public int width = 100;
	public int height = 20;
	
	Score score;
	
	//gui stuff
	Rect rect;
	
	void Start()
	{
		score = (Score) GetComponent("Score"); 
		rect = new Rect(Screen.width - 200, 0, 200,50);
	}
	
	bool OnGUI()
	{
		if(gameOver)
		{
			Application.LoadLevel("GameOver");
		}
		else
		{
			//Draw Hud
			if (!score)
			{
				Debug.LogError("No Score Model");
				return false;
			}
			
			GUI.Label( rect, "Score: " + score.GetScore().ToString());
		}
		
		return true;
	}
	
	public bool IsGameOver()
	{
		return gameOver;
	}
	
	public void GameOver()
	{
		gameOver = true;
	}
	
	public void Reset()
	{
		gameOver = false;
	}
}
