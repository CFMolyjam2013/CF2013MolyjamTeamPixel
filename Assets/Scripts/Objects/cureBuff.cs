using UnityEngine;
using System.Collections;

public class cureBuff : MonoBehaviour 
{
	private PlayerPhysics playerPhysics;
	private bar bar;
	// Use this for initialization
	void Start () 
	{
		playerPhysics = GetComponent<PlayerPhysics>();
		bar = GetComponent<bar>();
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
				//Change state
				playerPhysics.zombieStates -= 1;
				//Modify the bar to fill up
				bar.AddjustCurrentZombie();
				//Destroy item
				Destroy(gameObject);
			}
		}
	}
}
