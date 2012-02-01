#pragma strict
var gameOverImage:Texture2D;
var startLevel:String = "Basic";
var startGUI:GUIStyle;
var exitGUI:GUIStyle;
var score:ScoreModel = null;

function Update()
{
	score = gameObject.Find("ScoreObject").GetComponent("ScoreModel");
}

function OnGUI()
{
	var goRect:Rect = Rect((Screen.width/2)-(gameOverImage.width/2),(Screen.height/2)-(gameOverImage.height/2),gameOverImage.width, gameOverImage.height);

	if(score != null)
	{
		GUI.Label(goRect,"Your Score was:\n" + score.GetScore());
	}
	
	GUI.Label(goRect,gameOverImage);
	if(GUI.Button(Rect(goRect.xMin+19, goRect.yMin+167,227,87),"", startGUI))
	{
		Destroy(GameObject.Find("ScoreObject"));
		Application.LoadLevel(startLevel);
	}
	if(GUI.Button(Rect(goRect.xMin+276, goRect.yMin+399,227,87),"", exitGUI))
	{
		Application.Quit();
	}

}