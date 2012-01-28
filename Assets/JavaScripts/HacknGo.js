
function Start()
{
	var player = GameObject.Find("PlayerSnake");
	var computer = GameObject.Find("AISnake");
	
	var playerControl : PlayerControls = player.GetComponent(PlayerControls);
	var computerControl : AIControl = computer.GetComponent(AIControl);
	
	playerControl.Setup();
	computerControl.Setup();
}

function Update () {
}