using UnityEngine;
using System.Collections;

public enum Direction {NORTH, SOUTH, EAST, WEST, NONE};

public class Movement : MonoBehaviour {
	
	public float speed = 10;
	public Direction initialDirection = Direction.EAST;
	
	
	private Direction currentDirection = initialDirection;
	private Direction nextDirection = initialDirection;
	
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
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
