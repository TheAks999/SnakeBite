using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour 
{

	public int startScore = 0;
	public int minimumScore = -1000;
	public int maximumScore = 10000;

	private int score;
	
	void Start()
	{
		DontDestroyOnLoad(gameObject);
		DontDestroyOnLoad(this);
		score = startScore;
	}
	
	public void Reset()
	{
		score = startScore;
	}
	
	
	public int CombineScore(int toAdd)
	{
		
	
		if (score + toAdd > maximumScore)
		{
			score = maximumScore;
		}
		else if ( score + toAdd < minimumScore)
		{
			score = minimumScore;
		}
		else
		{
			Debug.Log("Adding score: " + score + " + " + toAdd + " = " + score);
			score += toAdd;
		}
	
		return score;
	}
	
	public int GetScore()
	{
		return score;
	}

}
