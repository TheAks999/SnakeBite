var playerObjectID : String = "PlayerSnake";
var computerObjectID : String = "AISnake";


function Start()
{
	var player = GameObject.Find(playerObjectID);
	var computer = GameObject.Find(computerObjectID);
	
	var playerControl : PlayerControls = player.GetComponent(PlayerControls);
	var computerControl : AIControl = computer.GetComponent(AIControl);
	
	playerControl.Setup();
	computerControl.Setup();
}

function Update () 
{
}