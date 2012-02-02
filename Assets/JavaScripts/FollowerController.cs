using UnityEngine;
using System.Collections;

public class FollowerController : Controller 
{
	Movement parent = null;
	
	public void SetParentMover(Movement parentMover)
	{
		parent = parentMover;
	}
	
	
	// Use this for initialization
	void Start () 
	{
		mover = (Movement) GetComponent("Movement");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!parent)
			return;
			
		mover.SetNextDirection(parent.GetCurrentDirection());	
		
	}
}
