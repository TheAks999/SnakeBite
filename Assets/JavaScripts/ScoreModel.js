
var startScore : int = 0;
var minimumScore : int = -1000;
var maximumScore : int = 10000;
private var score : int = startScore;

function Start()
{
	//DontDestroyOnLoad(gameObject.transform);
	
}


function CombineScore(toAdd:int)
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



function GetScore()
{
	return score;
}
