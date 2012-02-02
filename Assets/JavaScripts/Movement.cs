using UnityEngine;
using System.Collections;

public enum Direction {NORTH, SOUTH, EAST, WEST, NONE};

public class Movement : MonoBehaviour 
{
	
	public float speed = 10;
	public Direction initialDirection = Direction.EAST;
	
	public float percentMoved = 0;
	
	public Vector3 nextPosition;
	public Vector3 prevPosition;
	
	private Direction currentDirection;
	private Direction nextDirection;
	
	Movement()
	{
	}
	
	
	public void Start()
	{
		currentDirection = initialDirection;
		nextDirection = initialDirection;
		prevPosition = transform.position;
			
		switch (initialDirection)
		{
			case Direction.EAST:
			nextPosition = transform.position + Vector3.right;
			transform.Rotate(0,-90,0);
			break;
			case Direction.WEST:
			nextPosition = transform.position + Vector3.left;
			transform.Rotate(0,90,0);
			break;
			case Direction.NORTH:
			nextPosition = transform.position + Vector3.forward;
			transform.Rotate(0,180,0);
			break;
			case Direction.SOUTH:
			nextPosition = transform.position + Vector3.back;
			break;
			case Direction.NONE:
			nextPosition = transform.position;
			break;
		}
		
	}
	
	//Directional Functions
	public Direction GetCurrentDirection()
	{
		return currentDirection;
	}
	
	public Direction GetNextDirection()
	{
		return nextDirection;
	}
	
	public void SetNextDirection(Direction direction)
	{
		nextDirection = direction;
	}
	
	public void TurnLeft()
	{
	
		switch (currentDirection)
		{
			case Direction.EAST:
				nextDirection = Direction.NORTH;
				break;
			case Direction.WEST:
				nextDirection = Direction.SOUTH;
				break;
			case Direction.NORTH:
				nextDirection = Direction.WEST;
				break;
			case Direction.SOUTH:
				nextDirection = Direction.EAST;
				break;
			case Direction.NONE:
				nextDirection = Direction.WEST;
				break;
		}
	}
	
	public void TurnRight()
	{
		switch (currentDirection)
		{
			case Direction.EAST:
				nextDirection = Direction.SOUTH;
				break;
			case Direction.WEST:
				nextDirection = Direction.NORTH;
				break;
			case Direction.NORTH:
				nextDirection = Direction.EAST;
				break;
			case Direction.SOUTH:
				nextDirection = Direction.WEST;
				break;
			case Direction.NONE:
				nextDirection = Direction.EAST;
				break;
		}
	}
	
	private bool VectorEqual(Vector3 v1, Vector3 v2, float epsilon)
	{
		Vector3 result = v1 - v2;
		
		if ( result.x * result.x + result.z * result.z < epsilon * epsilon)
		{
			return true;
		}	
		
		return false;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		
		if ( percentMoved >= 1 && currentDirection != Direction.NONE)
		{
		
			percentMoved = 0;
			
			switch(nextDirection)
			{
				case Direction.EAST:
						nextPosition = new Vector3(
				                        Mathf.Round(transform.position.x + 1),
				                        Mathf.Round(transform.position.y),
										Mathf.Round(transform.position.z));
						prevPosition = new Vector3(
				                        Mathf.Round(transform.position.x),
				                        Mathf.Round(transform.position.y),
										Mathf.Round(transform.position.z));
							
					break;
						
					case Direction.WEST:
						nextPosition = new Vector3(
				                       Mathf.Round(transform.position.x - 1),
				                        Mathf.Round(transform.position.y),
										Mathf.Round(transform.position.z));
						prevPosition = new Vector3(
				                       Mathf.Round(transform.position.x),
				                        Mathf.Round(transform.position.y),
										Mathf.Round(transform.position.z));
						break;
					
					case Direction.SOUTH:
						nextPosition = new Vector3(
				                       Mathf.Round(transform.position.x),
				                       Mathf.Round(transform.position.y),
				                       Mathf.Round(transform.position.z - 1));
						prevPosition = new Vector3(
				                       Mathf.Round(transform.position.x),
				                       Mathf.Round(transform.position.y),
				                       Mathf.Round(transform.position.z));
						break;
						
					case Direction.NORTH:
						nextPosition = new Vector3(
				                       Mathf.Round(transform.position.x),
				                       Mathf.Round(transform.position.y),
				                       Mathf.Round(transform.position.z + 1));
						prevPosition = new Vector3(
				                       Mathf.Round(transform.position.x),
				                       Mathf.Round(transform.position.y),
				                       Mathf.Round(transform.position.z));
						break;
				
					default:
						prevPosition = nextPosition = new Vector3(
				                       Mathf.Round(transform.position.x),
				                       Mathf.Round(transform.position.y),
									   Mathf.Round(transform.position.z));
				break;
			}
			
				
				
			/*if (forceTurn > 0)
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
			}*/
			
			
			
			switch (nextDirection)
			{
				
				case Direction.EAST:
					switch(currentDirection)
					{
						case Direction.EAST:
							break;
						case Direction.WEST	:	
							//transform.Rotate(0,180,0);
							break;
						case Direction.SOUTH :	
							transform.Rotate(0,90,0);
							break;
						case Direction.NORTH : 
							transform.Rotate(0,90,0);
							break;
						case Direction.NONE :
							break;
					}
					break;
					
				case Direction.WEST:
					switch(currentDirection)
					{
						case Direction.EAST:
							//transform.Rotate(0,180,0);
							break;
						case Direction.WEST	:	
							break;
						case Direction.SOUTH :	
							transform.Rotate(0,90,0);
							break;
						case Direction.NORTH : 
							transform.Rotate(0,90,0);
							break;
						case Direction.NONE :
							break;
					}
					break;
				
				case Direction.SOUTH:
					switch(currentDirection)
					{
						case Direction.EAST:
							transform.Rotate(0,-90,0);
							break;
						case Direction.WEST	:	
							transform.Rotate(0,90,0);
							break;
						case Direction.SOUTH :	
							break;
						case Direction.NORTH : 
							transform.Rotate(0,180,0);
							break;
						case Direction.NONE :
							break;
					}
					break;
					
				case Direction.NORTH:
					switch(currentDirection)
					{
						case Direction.EAST:
							transform.Rotate(0,90,0);
							break;
						case Direction.WEST	:	
							transform.Rotate(0,-90,0);
							break;
						case Direction.SOUTH :	
							transform.Rotate(0,180,0);
							break;
						case Direction.NORTH : 
							break;
						case Direction.NONE :
							break;
					}
					break;
			}
			
			
			currentDirection = nextDirection;
		}
		
		percentMoved += Time.deltaTime*speed*0.5f;	
		transform.position = Vector3.Lerp(prevPosition,nextPosition,percentMoved);
	}
	
	
}
