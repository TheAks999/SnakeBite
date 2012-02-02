using UnityEngine;
using System.Collections;

public class SnakeModel : MonoBehaviour 
{
	int numberOfSegments = 10;
	int criticalLength = 3;
	
    Controller controller = null;
	
	GameObject head = null;
	GameObject [] snake = null;
	
	Mesh headMesh = null;
	Mesh bodyMesh = null;
	Mesh tailMesh = null;
	
	Material headMat = null;
	Material bodyMat = null;
	Material tailMat = null;
	
	Direction initialDirection = Direction.EAST;
	
	// Use this for initialization
	void Start () 
	{
		if (snake == null)
		{
			BuildSnake();
		}
	}
	
	void BuildSnake()
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
		
		piece.MakeHead();	
	
		GameObject child = gameObject;
		for (int i = 1; i < numberOfSegments; i++)
		{
			
			child = ( (SnakePiece) child.GetComponent("SnakePiece") ).AddChild(initialDirection);
			snake[i] = child;
		}
	}
	
	
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
