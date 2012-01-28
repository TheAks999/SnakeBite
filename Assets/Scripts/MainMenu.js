#pragma strict
var logo:Texture2D;

private var width:int;
private var height:int;

function Start () 
{

}

function Update () 
{

}

function OnGUI()
{
	if(logo.width > Screen.width)
	{
		width = Screen.width;
		height = (logo.width/Screen.width)*logo.height;
	}else{
		width = logo.width;
		height = logo.height;
	}
	GUI.Box(Rect((Screen.width/2)-(width/2), 0, width, height), logo);
}