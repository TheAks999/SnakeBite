using UnityEngine;
using System.Collections;

public class ObjectGenerator : MonoBehaviour 
{
	public int radius = 10;
	public GameObject generated = null;
	public bool active = false;
	
	private int spawnCounter = 0;
	public int spawnRate = 100; 
	
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (active)
		{
			spawnCounter++;
			if (spawnRate <= spawnCounter)
			{
				Instantiate(generated,
					transform.position 
						+ Random.Range(-radius,radius)*Vector3.right 
						+ Random.Range(-radius,radius)*Vector3.forward,
					Quaternion.identity);
				
				spawnCounter = 0;
			}
		}
		
	}
}
