using UnityEngine;
using System.Collections;

public class accuracyBuff : MonoBehaviour 
{
	public bool startPowerUp = false;
	public float timer = 10;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Starts the powerup
		if(startPowerUp == true)
		{
			timer -= Time.deltaTime;
		}
		buff();
	}
	
	public void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "player")
		{
			startPowerUp = true;
		}
	}
	
	public void buff()
	{
		//Give the player the ability to instant kill zombies
		while(timer > 0 && startPowerUp == true)
		{
			
		}
	}
}
