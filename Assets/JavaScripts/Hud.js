#pragma strict

var win:boolean = false;
var loss:boolean = false;
var width:int = 100;
var height:int = 20;

function OnGUI()
{
	if(win)
	{
		GUI.Label(Rect((Screen.width/2)-(width/2), (Screen.height/2)-(height/2), width, height), "YOU WIN!!!");
	}else if(loss){
		Application.LoadLevel("GameOver");
	}else{
		//Draw Hud
		var scoreObject : GameObject = GameObject.Find("ScoreObject");

		if (!scoreObject)
		{
			Debug.LogError("No Score Object");
			return;
		}
		
		var scoreModel : ScoreModel	= scoreObject.GetComponent(ScoreModel);
		
		if (!scoreModel)
		{
			Debug.LogError("No Score Model");
			return false;
		}
		GUI.Label(Rect(Screen.width - 200, 0, 200,50), "Score: " + scoreModel.GetScore().ToString());
	}
}

public function Won()
{
	win = true;
}
public function Lost()
{
	loss = true;
}