using UnityEngine;
using System.Collections;

public class AIController : Controller 
{
	
	private float timestep = 0;
	
	// Use this for initialization
	void Start () 
	{
		mover = (Movement) GetComponent("Movement");
	}
	
	// Update is called once per frame
	void Update () 
	{
		timestep += Time.deltaTime;
		if (timestep > .5)
		{
			if (transform.position.x > 20 || transform.position.x < -20 || 
				transform.position.z > 20 || transform.position.z < -20 )
			{
					mover.TurnLeft();
			}
			else
			{
				int choice = Random.Range(1,100);
				
				if (choice < 51)
				{
					//go straight
					
					//do nothing now
				}
				else if (choice < 76)
				{
					//go left
					mover.TurnLeft();
					
				}
				else if (choice >= 76 &&choice <= 100)
				{
					//go right
					mover.TurnRight();
				}
				timestep = 0;
			}
		}
	
	}
}
