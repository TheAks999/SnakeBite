using UnityEngine;
using System.Collections;

public enum PieceType {HEAD,BODY,TAIL,NONE};

public class SnakePiece : MonoBehaviour {
	
	
	public GameObject head = null;
	public GameObject parent = null;
	public GameObject child = null;
	
	public Mesh headMesh = null;
	public Mesh bodyMesh = null;
	public Mesh tailMesh = null;
	
	public Material headMat = null;
	public Material bodyMat = null;
	public Material tailMat = null;
	
	
	public SnakeModel snakeModel = null;
	public PieceType pieceType = PieceType.NONE;
	
	public SnakeModel GetModel()
	{
		return snakeModel;
	}
	
	public GameObject AddChild(Direction childDirection)
	{
		if (!HasChild())
		{
			child = new GameObject();
			
			//Construct the piece
			SnakePiece piece = (SnakePiece) child.AddComponent("SnakePiece");
			piece.parent = gameObject;
			piece.snakeModel = snakeModel;
			piece.head = head;
			
			
				//Rendering transfer
			piece.headMesh = headMesh;
			piece.bodyMesh = bodyMesh;
			piece.tailMesh = tailMesh;
			
			piece.headMat = headMat;
			piece.bodyMat = bodyMat;
			piece.tailMat = tailMat;
			
			//Construct the mover
			Movement mover = (Movement) child.AddComponent("Movement");
			mover.initialDirection = childDirection;
			
			//Place AI
			( (FollowerController) child.AddComponent("FollowerController")).SetParentMover((Movement) GetComponent("Movement")); 
			
			//Collision Stuff
			SphereCollider collider = (SphereCollider) child.AddComponent("SphereCollider");
			collider.radius = 0.1f;
			collider.isTrigger = true;
			
			Rigidbody rigid = (Rigidbody) child.AddComponent("Rigidbody");
			rigid.useGravity = false;
			
			//initial starting location - assuming an absolute translation
			switch(childDirection)
			{
				case Direction.EAST	:
					child.transform.Translate(transform.position + Vector3.left);
				break;
				case Direction.WEST	:
					child.transform.Translate(transform.position + Vector3.right);
				break;
				case Direction.NORTH :
					child.transform.Translate(transform.position + Vector3.back);
				break;
				case Direction.SOUTH :
					child.transform.Translate(transform.position + Vector3.forward);
				break;
			}
			
			//constuct the child
			
			child.AddComponent("MeshFilter");
			child.AddComponent("MeshRenderer");
			
			//finishing touches
			piece.MakeTail();
			if (!IsHead())
			{
				MakeBody();
			}
			Debug.Log("Built Child at " + child.transform);
		}
		
		return child;
	}
	
	public bool HasParent()
	{
		if (parent == null)
		{
			return false;
		}
		return true;
	}
	
	public bool HasChild()
	{
		if (child == null)
		{
			return false;
		}
		
		return true;
	}
	
	public bool IsHead()
	{
		if (head == gameObject)
			return true;
			
		return false;
	}
	
	public bool IsTail()
	{
		return !HasChild();
	}
	
	public void MakeHead()
	{
		parent = null;
		head = gameObject;
		pieceType = PieceType.HEAD;
		
		
		MeshFilter meshFilter = (MeshFilter) GetComponent("MeshFilter");
		MeshRenderer meshRenderer = (MeshRenderer) GetComponent("MeshRenderer");
		
		meshFilter.mesh = headMesh;
		meshRenderer.material = headMat;
		
	}
	
	public void MakeBody()
	{
		pieceType = PieceType.BODY;
		
		
		MeshFilter meshFilter = (MeshFilter) GetComponent("MeshFilter");
		MeshRenderer meshRenderer = (MeshRenderer) GetComponent("MeshRenderer");
		
		meshFilter.mesh = bodyMesh;
		meshRenderer.material = bodyMat;
	}
	
	public void MakeTail()
	{
		child = null;
		pieceType = PieceType.TAIL;
		
		
		MeshFilter meshFilter = (MeshFilter) GetComponent("MeshFilter");
		MeshRenderer meshRenderer = (MeshRenderer) GetComponent("MeshRenderer");
		
		meshFilter.mesh = tailMesh;
		meshRenderer.material = tailMat;
	}
	
}
