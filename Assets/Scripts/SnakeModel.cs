using UnityEngine;
using System.Collections;


public class SnakeModel : MonoBehaviour 
{
	public enum ControlType {PLAYERKEYBOARD,AI};
	public ControlType controlType = ControlType.AI;
	
	public int numberOfSegments = 10;
	public int criticalLength = 3;
	
	private GameObject head = null;
	private GameObject [] snake = null;
	
	public Mesh headMesh = null;
	public Mesh bodyMesh = null;
	public Mesh tailMesh = null;
	
	public Material headMat = null;
	public Material bodyMat = null;
	public Material tailMat = null;
	
	int lengthToGrow = 0;
	
	public Direction initialDirection = Direction.EAST;
	
	private bool isGrowing = false;
	
	
	private int numberOfSteps = 0;
	
	// Use this for initialization
	public void Start () 
	{
		((MeshFilter)GetComponent("MeshFilter")).mesh = null;
		((MeshRenderer)GetComponent("MeshRenderer")).material = null;
	
		if (snake == null)
		{
			BuildSnake();
		}
	}
	
	///////////////////////////////
	/// This Section Brings LIFE!
	///////////////////////////////
	
	public bool IsGrowing()
	{
		return isGrowing;
	}
	
	public void BuildSnake()
	{
		snake = new GameObject[numberOfSegments];
		head = new GameObject();
		snake[0] = head;
		
		//put together the head
		SnakePiece piece = (SnakePiece) head.AddComponent("SnakePiece");
		piece.snakeModel = this;
		piece.head = head;
			
		//Rendering transfer
		piece.headMesh = headMesh;
		piece.bodyMesh = bodyMesh;
		piece.tailMesh = tailMesh;
		
		piece.headMat = headMat;
		piece.bodyMat = bodyMat;
		piece.tailMat = tailMat;
		
		Movement mover = (Movement) head.AddComponent("Movement");
		mover.initialDirection = initialDirection;
		
		
		//initial starting location - assuming an absolute translation
		head.transform.Translate(transform.position);
		
		//constuct the rest of the child
		head.AddComponent("MeshFilter");
		head.AddComponent("MeshRenderer");
		
		

		
		
		if(controlType == SnakeModel.ControlType.AI)
		{
			((Controller)head.AddComponent("AIController")).SetMover(mover);
		}
		else if (controlType == SnakeModel.ControlType.PLAYERKEYBOARD)
		{
			((Controller)head.AddComponent("PlayerController")).SetMover(mover);
		}
		
		//Collision stuff
		SphereCollider collider = (SphereCollider) head.AddComponent("SphereCollider");
		collider.radius = 0.1f;
		collider.isTrigger = true;
		Rigidbody rigid = (Rigidbody) head.AddComponent("Rigidbody");
		rigid.useGravity = false;
		
		
		piece.MakeHead();	
	
		GameObject child = head;
		for (int i = 1; i < numberOfSegments; i++)
		{
			child = ( (SnakePiece) child.GetComponent("SnakePiece") ).AddChild(initialDirection);
			snake[i] = child;
		}
	}
	
	
	void BuildSnakeFrom(GameObject [] pieces)
	{
		numberOfSegments = pieces.Length;
		head = pieces[0];
		snake = pieces;
		
		for (int i = 0; i < numberOfSegments; i++)
		{
			((SnakePiece)snake[i].GetComponent("SnakePiece")).snakeModel = this;
		}
		
	
	}
	
	
	private void Grow(int lengthToAdd)
	{
		if (lengthToAdd	< 1)
			return;
	
		while (isGrowing){}
		isGrowing = true;
		
		
		
		
		Debug.Log("Grow by: " + lengthToAdd);
		
		GameObject [] tempList = new GameObject[numberOfSegments + lengthToAdd];
		
		
		for (int i = 0; i < numberOfSegments; i++)
		{
			tempList[i] = snake[i];
		}
		
		for (int i = 0; i < lengthToAdd; i++)
		{
			GameObject last = (GameObject) tempList[numberOfSegments-1];
			SnakePiece piece = (SnakePiece) last.GetComponent("SnakePiece");
			Movement movement = (Movement) last.GetComponent("Movement");			
			
			tempList[numberOfSegments] = piece.AddChild( movement.GetCurrentDirection() );
			numberOfSegments++;
			
		}
		snake = tempList;
		isGrowing = false;
	}
	
	public void GrowSnake(int lengthToAdd)
	{
		lengthToGrow += lengthToAdd;
	}
	
	public void FixedUpdate()
	{
		numberOfSteps++;
		
		if (numberOfSteps >= 10)
		{
			numberOfSteps = 0;
			Grow(lengthToGrow);
			lengthToGrow = 0;
		}
	}
	
	///////////////////////////////
	/// This Section Brings DEATH!
	///////////////////////////////
	
	
	void KillSnake()
	{
		for (int i = 0; i < numberOfSegments; i++)
		{
			Destroy(snake[i]);
		}
	
		// TODO: if this is a player this means game over
		
		Destroy(gameObject);		
	}
	
	void CutSnakeAt(GameObject segment)
	{
		//find the index of the segment
		int index;
		for (index = 0; index < numberOfSegments; index++)
		{
			if (segment	== snake[index])
				break;
		}
		
		if (index == numberOfSegments)
		{
			Debug.LogError("Cutting error");
			Debug.DebugBreak();
		}
		if (index >= criticalLength &&  numberOfSegments-(index+1) >= criticalLength)
		{
			GameObject [] oldSnake = new GameObject[index];
			GameObject [] newSnake = new GameObject[numberOfSegments-index-1];
			
			for (int i = 0; i < index; i++)
			{
				oldSnake[i] = snake[i];	
			}
			
			((SnakePiece)oldSnake[index-1].GetComponent("SnakePiece")).MakeTail();
			
			
			for (int i = index+1; i < numberOfSegments; i++)
			{
				newSnake[i-(index+1)] = snake[i];	
			}
			
			((SnakePiece)newSnake[0].GetComponent("SnakePiece")).MakeHead();
			Destroy(newSnake[0].GetComponent("FollowerController"));
			newSnake[0].AddComponent("AIController");
			
			GameObject newContainer = (GameObject)Instantiate(gameObject);
			((SnakeModel)newContainer.GetComponent("SnakeModel")).BuildSnakeFrom(newSnake);
			newContainer.name = "New Snake Object";
			
			  
			  
			Destroy(snake[index]);
			snake = oldSnake;
		}
		else if (index >= criticalLength)
		{
			GameObject [] newSnake = new GameObject[index];
			for (int i = 0; i < index; i++)
			{
				newSnake[i] = snake[i];	
			}
			
			((SnakePiece)newSnake[index-1].GetComponent("SnakePiece")).MakeTail();
			
			for (int i = index; i < numberOfSegments; i++)
			{
				Destroy(snake[i]);
			}
			
			snake = newSnake;
		}
		else if (numberOfSegments-(index+1) >= criticalLength)
		{
			//TODO: if this is the player snake this is game over
			
			
			GameObject [] newSnake = new GameObject[numberOfSegments-index-1];
			
			for (int i = index+1; i < numberOfSegments; i++)
			{
				newSnake[i-(index+1)] = snake[i];	
			}
			
			head = newSnake[0];
			((SnakePiece)head.GetComponent("SnakePiece")).MakeHead();
			Destroy(head.GetComponent("FollowerController"));
			head.AddComponent("AIController");
			
			for (int i = 0; i <= index; i++)
			{
				Destroy(snake[i]);
			}
			
			snake = newSnake;
		
		}
		else
		{
			//TODO: if this is the player snake this is game over
			KillSnake();
		}
	}
	
}
