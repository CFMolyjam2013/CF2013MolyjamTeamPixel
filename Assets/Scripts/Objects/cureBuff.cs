using UnityEngine;
using System.Collections;

public class cureBuff : MonoBehaviour 
{
	private PlayerPhysics playerPhysics;
	// Use this for initialization
	void Start () 
	{
		playerPhysics = GetComponent<PlayerPhysics>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//OnCollisionEnter(Collision);
	}
		
	public void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "player")
		{
			if(playerPhysics.zombieStates == PlayerPhysics.ZombieState.fullHuman)
			{
				//Destroy item
				Destroy(gameObject);
			}
			else
			{
				//Destroy item
				Destroy(gameObject);
				//Change state
				playerPhysics.zombieStates -= 1;
			}
		}
	}
}
