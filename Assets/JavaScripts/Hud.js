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
		GUI.Label(Rect((Screen.width/2)-(width/2), (Screen.height/2)-(height/2), width, height), "YOU LOOSE!");
	}else{
		//Draw Hud
	}
}