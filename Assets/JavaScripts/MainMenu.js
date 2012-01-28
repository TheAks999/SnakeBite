#pragma strict
var logo:Texture2D;
var buttonHeight:int = 60;
var buttonSpacing:int = 10;
var startGUI:GUIStyle;


private var width:float;
private var height:float;
//Have to be floats for resizing purposes

var top:int;
//Added for possible android use with scrollable menu

function Start () 
{
	
}

function Update () 
{

}

function OnGUI()
{
	//Resizes logo if it gets to small for screen.
	if(logo.width > Screen.width)
	{
		width = Screen.width;
		height =  (width/logo.width)*logo.height;
	}else{
		width = logo.width;
		height = logo.height;
	}
	
	
	var logoRect:Rect = new Rect((Screen.width/2)-(width/2), top, width, height);
	GUI.Box(logoRect, logo);
	var button:int = 0;
	GUI.Button(Rect(Screen.width/2-(223/2), buttonSpacing+logoRect.bottom+(buttonSpacing*button)+(buttonHeight*button), 223, buttonHeight), "", startGUI);
	button++;
	GUI.Button(Rect(logoRect.left+buttonSpacing, buttonSpacing+logoRect.bottom+(buttonSpacing*button)+(buttonHeight*button), logoRect.width-(buttonSpacing*2), buttonHeight), "Exit Game");
}