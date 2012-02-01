using UnityEngine;
using System.Collections;

enum PieceType {HEAD,BODY,TAIL,NONE};

public class SnakePiece : MonoBehaviour {
	
	GameObject head = null;
	GameObject parent = null;
	GameObject child = null;
	
	Mesh headMesh = null;
	Mesh bodyMesh = null;
	Mesh tailMesh = null;
	
	Material headMat = null;
	Material bodyMat = null;
	Material tailMat = null;
	
	
	SnakeModel snakeModel = null;
	PieceType pieceType = NONE;
	
	GameObject AddChild()
	{
		if (HasChild())
		{
			child = new GameObject();
			SnakePiece piece = new SnakePiece();
			
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
			
			
			//constuct the child
			child.AddComponent(piece);
			child.AddComponent(MeshFilter);
			child.AddComponent(MeshRenderer);
			
			//finishing touches
			piece.MakeTail();
			if (!IsHead())
			{
				MakeBody();
			}
			
		}
		
		return child;
	}
	
	bool HasParent()
	{
		if (parent == null)
		{
			return false;
		}
		return true;
	}
	
	bool IsHead()
	{
		if (head == gameObject)
			return true;
			
		return false;
	}
	
	bool IsTail()
	{
		if (tail == gameObject)
			return true;
		
		return false;
	}
	
	void MakeHead()
	{
		parent = null;
		head = gameObject;
		pieceType = HEAD;
		
		
		MeshFilter meshFilter = GetComponent(MeshFilter);
		MeshRenderer meshRenderer = GetComponent(MeshRenderer);
		
		meshFilter.mesh = headMesh;
		meshRenderer.material = headMat;
		
	}
	
	void MakeBody()
	{
		pieceType = BODY;
		
		
		MeshFilter meshFilter = GetComponent(MeshFilter);
		MeshRenderer meshRenderer = GetComponent(MeshRenderer);
		
		meshFilter.mesh = bodyMesh;
		meshRenderer.material = bodyMat;
	}
	
	void MakeTail()
	{
		child = null;
		pieceType = TAIL;
		
		
		MeshFilter meshFilter = GetComponent(MeshFilter);
		MeshRenderer meshRenderer = GetComponent(MeshRenderer);
		
		meshFilter.mesh = tailMesh;
		meshRenderer.material = tailMat;
	}
	
}
