using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour 
{
	
	protected Movement mover;	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void SetMover(Movement move)
	{
		mover = move;
	}
}
