#pragma strict
var logo:Texture2D;
var buttonHeight:int = 60;
var buttonSpacing:int = 10;
var startGUI:GUIStyle;
var exitGUI:GUIStyle;
var helpGUI:GUIStyle;
var startLevel:String = "Basic";


private var width:float;
private var height:float;
//Have to be floats for resizing purposes

var top:int;
var centerVertically;
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
	GUI.Label(logoRect, logo);
	if(GUI.Button(Rect(logoRect.left, logoRect.bottom+buttonSpacing, 223, buttonHeight), "", startGUI))
	{
		Application.LoadLevel(startLevel);
	}
	GUI.Button(Rect(logoRect.right-223, logoRect.bottom+buttonSpacing, 223, buttonHeight), "", exitGUI);
	GUI.Button(Rect((Screen.width/2)-(72/2), logoRect.bottom+buttonSpacing, 72, buttonHeight), "", helpGUI);
}