#pragma strict
var gameOverImage:Texture2D;
var startLevel:String = "Basic";
var startGUI:GUIStyle;
var exitGUI:GUIStyle;
var goRect:Rect;
function Start()
{
	goRect = Rect((Screen.width/2)-(gameOverImage.width/2),(Screen.height/2)-(gameOverImage.height/2),gameOverImage.width, gameOverImage.height);
	//var score:ScoreModel = GameObject.Find("ScoreObject").GetComponent("ScoreModel");
	
}


function OnGUI()
{
	GUI.Label(goRect,gameOverImage);
	if(GUI.Button(Rect(goRect.xMin+19, goRect.yMin+167,227,87),"", startGUI))
	{
		Application.LoadLevel(startLevel);
	}
	if(GUI.Button(Rect(goRect.xMin+276, goRect.yMin+399,227,87),"", exitGUI))
	{
		Application.Quit();
	}
	//GUI.Label(goRect,"Your Score was:\n" + score.GetScore());
	GUI.Label(goRect,gameOverImage);
	
}