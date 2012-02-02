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
	
	
	public void Grow(int lengthToAdd)
	{
		while (isGrowing){}
		isGrowing = true;
		
		
		if (lengthToAdd	< 1)
			return;
		
		
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
	
	public void FixedUpdate()
	{
		numberOfSteps++;
		
		if (numberOfSteps >= 100)
		{
			numberOfSteps = 0;
			Grow(1);
		
		}
	}
	
}
