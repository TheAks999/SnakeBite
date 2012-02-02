using UnityEngine;
using System.Collections;

public enum Direction {NORTH, SOUTH, EAST, WEST, NONE};

public class Movement : MonoBehaviour {
	
	public float speed = 10;
	public Direction initialDirection = Direction.EAST;
	
	private float percentMoved = 0;
	
	private Direction currentDirection;
	private Direction nextDirection;
	
	Movement()
	{
	}
	
	Movement(Direction initDirection)
	{
		initialDirection = initDirection;
	}
	
	public void Start()
	{
		currentDirection = initialDirection;
		nextDirection = initialDirection;
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
	void Update () 
	{
		
		Vector3 nextPosition;
		
		switch(currentDirection)
		{
			case Direction.EAST:
					nextPosition = new Vector3(
			                        Mathf.Floor(transform.position.x + 1),
			                        transform.position.y,
									transform.position.z);
					break;
					
				case Direction.WEST:
					nextPosition = new Vector3(
			                       Mathf.Ceil(transform.position.x - 1),
			                       transform.position.y,
			                       transform.position.z);
					break;
				
				case Direction.SOUTH:
					nextPosition = new Vector3(
			                       transform.position.x,
			                       transform.position.y,
			                       Mathf.Ceil(transform.position.z - 1));
					break;
					
				case Direction.NORTH:
					nextPosition = new Vector3(
			                       transform.position.x,
			                       transform.position.y,
			                       Mathf.Floor(transform.position.z + 1));
					break;
			
				default:
					nextPosition = new Vector3(
			                       transform.position.x,
			                       transform.position.y,
			                       transform.position.z);
			break;
		}
		
		
		
		if ( VectorEqual(transform.position, nextPosition, 0.001f) )
		{
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
			
			
			//transform.position.x = Mathf.Round(transform.position.x);
			//transform.position.y = Mathf.Round(transform.position.y);
			//transform.position.z = Mathf.Round(transform.position.z);
			
			
			switch (nextDirection)
			{
				case Direction.EAST:
					transform.RotateAround(Vector3.up,270);
					break;
					
				case Direction.WEST:
					transform.RotateAround(Vector3.up,90);
					break;
				
				case Direction.SOUTH:
					transform.RotateAround(Vector3.up,0);
					break;
					
				case Direction.NORTH:
					transform.RotateAround(Vector3.up,180);
					break;
			}
			
			
			currentDirection = nextDirection;
		}
		
		transform.position = Vector3.Lerp(transform.position,nextPosition,Time.deltaTime*speed);
	}
	
	
}
