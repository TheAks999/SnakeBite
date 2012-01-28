#pragma strict
var logo:Texture2D;
function Start () 
{

}

function Update () 
{

}

function OnGUI()
{
	GUI.Box(Rect((Screen.width/2)-(logo.width/2), 0, logo.width, logo.height), logo);
}