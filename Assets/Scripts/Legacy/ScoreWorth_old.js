/*var pointWorth : int = 0;
var playerObjectName : String = "PlayerSnake";

//function DoPoints()

function OnDestroy()
{
	var hud:Hud = GameObject.Find("ScoreObject").GetComponent("Hud");
	if(!hud.IsLost())
	{
		if (gameObject.name != playerObjectName)
		{
		
			var snakeModel : SnakeModel = GetComponent(SnakeModel);
			
			if (snakeModel)
			{
				if (snakeModel.GetHead())
				{
					if (snakeModel.name == playerObjectName)
					{
					return;
					}
				}
				else
				{	
					Debug.LogWarning("This snake has no head");
					//return;
				}
			}
			
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
			
			scoreModel.CombineScore(pointWorth);
		}
		
	}
}

*/