#pragma strict
enum Direction {NORTH, SOUTH, EAST, WEST}

//The speed of the snake
public var speed : float = 10.0f;

//True if this object is the head
private var isHead : boolean = true;

//True if this segment is critical for life
private var isCritical : boolean = false;

private var criticalSize : int = 1;

//Linking
private var child : GameObject = null;
private var parent : GameObject = null;
private var head : GameObject = null;

//The absolute next position (sets to EAST)
private var nextPosition : Vector3;
nextPosition = transform.position + Vector3(1,0,0);

//This is the direction the segment is moving
private var direction : Direction = Direction.EAST;

//This is the next direction to be moved
// -- These are seperate so controler input works 
private var inputDirection : Direction = direction;

//The number of children attached to the end of this segment
private var numberOfChildren : int = 0;
private var childID : int = 0;


private var forceTurn : int = 0;

//true is left
private var forceTurnDirection : boolean = false;

function IsHead()
{
	return isHead;
}

function IsCritical()
{
	return isCritical;
}

function CurrentDirection()
{
	return direction;
}

function GetHead()
{
	return head;
}

function NumberOfChildren()
{
	return numberOfChildren;
}

function ChildID()
{
	return childID;
}

function CriticalSize()
{
	return criticalSize;
}


function MakeSnake(size:int,dir:Direction,criticalSections:int)
{
	isHead = true;
	head = gameObject;
	numberOfChildren = size-1;
	childID = 0;
	criticalSize = criticalSections;
	
	if (criticalSections <= 0)
	{
		criticalSize = 1;
		Debug.LogWarning("Too few critical sections on snake");
	} 
	
	isCritical = true;
	//renderer.material.color = Color.red;
	
	if (size > 1)
	{
	
		var childSpot : Vector3 = transform.position; 
		
		switch (direction)
		{
			case Direction.EAST:
				childSpot.x -= 1;
				break;
			case Direction.WEST:
				childSpot.x += 1;
				break;
			case Direction.NORTH:
				childSpot.z -= 1;
				break;
			case Direction.SOUTH:
				childSpot.z += 1;
				break;
		}
		
		
		child = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		
		//child = Instantiate( prefab ,childSpot,Quaternion.identity); 
		child.AddComponent("SnakeModel");
		child.AddComponent("FollowerControl");
		
		if (!child.GetComponent(SphereCollider))
		{
			child.AddComponent(SphereCollider);
		}
		child.GetComponent(SphereCollider).collider.isTrigger = true;
		
		
		child.transform.position = childSpot;
		
	
		var childModel : SnakeModel = child.GetComponent("SnakeModel");
		childModel.SetNextPosition(transform.position,direction);
		childModel.MakeSnake(1,size-1,dir,criticalSections-1,criticalSections,gameObject,head);
	
	}
}

private function MakeSnake(idNumber:int,size:int,dir:Direction,criticalSections:int,criticals:int,parentSnake:GameObject,snakeHead:GameObject)
{
	numberOfChildren = size-1;
	parent = parentSnake;
	head = snakeHead;
	childID = idNumber;
	//renderer.material.color = Color.green;
	criticalSize = criticals;
	isHead = false;
	
	if (criticalSections > 0)
	{
		isCritical = true;
		//renderer.material.color = Color.yellow;
	}
	
	if (size > 1)
	{
		var childSpot : Vector3 = transform.position; 
		
		switch (direction)
		{
			case Direction.EAST:
				childSpot.x -= 1;
				break;
			case Direction.WEST:
				childSpot.x += 1;
				break;
			case Direction.NORTH:
				childSpot.z -= 1;
				break;
			case Direction.SOUTH:
				childSpot.z += 1;
				break;
			default:
				Debug.LogWarning("NOO@O!!! no direction");
		}
		
		
		child = Instantiate( gameObject ,childSpot,Quaternion.identity);
		//child.tag = "child";
	
		
		var childModel : SnakeModel = child.GetComponent("SnakeModel");
		childModel.SetNextPosition(transform.position,inputDirection);
		childModel.MakeSnake(idNumber+1,size-1,dir,criticalSections-1,criticalSize,gameObject,head);
		
	}
}

function KillSnake()
{
	Debug.Log("Killing Snake");
	if (gameObject != head)
	{
		SetChildren();
	}
	KillHelper();
}

private function KillHelper()
{
	if (numberOfChildren > 0)
	{
		var childModel : SnakeModel = child.GetComponent("SnakeModel");
		childModel.KillHelper();
	}
	
	Destroy(gameObject);
}


function TurnLeft()
{
	switch (direction)
	{
		case Direction.EAST:
			inputDirection = Direction.NORTH;
			transform.rotation.eulerAngles.y = 180;
			break;
		case Direction.WEST:
			inputDirection = Direction.SOUTH;
			transform.rotation.eulerAngles.y = 0;
			break;
		case Direction.NORTH:
			inputDirection = Direction.WEST;
			transform.rotation.eulerAngles.y = 90;
			break;
		case Direction.SOUTH:
			inputDirection = Direction.EAST;
			transform.rotation.eulerAngles.y = 270;
			break;
	}
}

function TurnRight()
{
	switch (direction)
	{
		case Direction.EAST:
			inputDirection = Direction.SOUTH;
			transform.rotation.eulerAngles.y = 0;
			break;
		case Direction.WEST:
			inputDirection = Direction.NORTH;
			transform.rotation.eulerAngles.y = 180;
			break;
		case Direction.NORTH:
			inputDirection = Direction.EAST;
			transform.rotation.eulerAngles.y = 270;
			break;
		case Direction.SOUTH:
			inputDirection = Direction.WEST;
			transform.rotation.eulerAngles.y = 90;
			break;
	}	
}

function ForceTurn(dir:boolean)
{
	forceTurn = 2;
	forceTurnDirection = dir;
}


function UpdatePosition()
{
	
	if (VectorEqual(transform.position, nextPosition, .001))
	{
		if (forceTurn > 0)
		{
			if (forceTurnDirection == true)
			{
				TurnLeft();
			}
			else
			{
				TurnRight();
			}
			forceTurn--;
		}
		
		
	
	
		transform.position.x = Mathf.Round(transform.position.x);
		transform.position.y = Mathf.Round(transform.position.y);
		transform.position.z = Mathf.Round(transform.position.z);
		
		if (numberOfChildren > 0 && child != null)
		{
			var childModel : SnakeModel = child.GetComponent("SnakeModel");
			childModel.SetNextPosition(transform.position,direction);
			
		}
		
		var normal : Vector3; 
		
		switch (inputDirection)
		{
			case Direction.EAST:
				normal = Vector3(1,0,0);
				break;
				
			case Direction.WEST:
				normal = Vector3(-1,0,0);
				break;
			
			case Direction.SOUTH:
				normal = Vector3(0,0,-1);
				break;
				
			case Direction.NORTH:
				normal = Vector3(0,0,1);
				break;
				
		}	
		
		direction = inputDirection;
		nextPosition += normal;
	}
	
	
	transform.position = Vector3.Lerp(transform.position,nextPosition,Time.deltaTime*speed);
}


private function SetNextPosition(position:Vector3,dir:Direction)
{
	if(child!=null)
	{
		var tmpChild:SnakeModel = child.GetComponent("SnakeModel");
		tmpChild.SetNextPosition(nextPosition, direction);
	}
	nextPosition = position;
	inputDirection = dir;
}


private function VectorEqual(v1:Vector3,v2:Vector3,epsilon:float)
{
	var result : Vector3 = v1 - v2;
	
	if ( result.x * result.x + result.z * result.z < epsilon)
	{
		
		return true;
	}	
	
	return false;
}


public function CutHere()
{
	if (numberOfChildren >= criticalSize)	
	{
		Debug.Log("Cutting Snake");
		var tmpChild:SnakeModel = child.GetComponent("SnakeModel");
		Destroy(child.GetComponent("FollowerControl"));
		child.AddComponent("AIControl");
		tmpChild.SetHead(child, 0);
		SetChildren();
		tmpChild.ForceTurn(true);
		
		DestroyObject(gameObject);
	}
	else
	{
		KillSnake();
	}
}



private function SetHead(headObject:GameObject,idNumber:int)
{
	if (idNumber == 0)
	{
		isHead = true;
		parent = gameObject;
	}
	
	head = headObject;
	
	if(numberOfChildren > 0)
	{
		var tmpChild:SnakeModel = child.GetComponent("SnakeModel");
		tmpChild.SetHead(headObject, idNumber+1);
	}
	
}

private function SetChildren()
{
	var parentModel:SnakeModel = parent.GetComponent("SnakeModel");	
	var headModel:SnakeModel = head.GetComponent("SnakeModel");
	headModel.SetChildren(parentModel.ChildID());
}

private function SetChildren(numChildren:int)
{
	numberOfChildren = numChildren;
	
	if(numberOfChildren > 0)
	{
		var tmpChild:SnakeModel = child.GetComponent("SnakeModel");
		tmpChild.SetChildren(numChildren-1);
	}
	else
	{
		child = null;
	}
}

