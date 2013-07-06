using UnityEngine;
using System.Collections;

public class shotgunAmmo : MonoBehaviour 
{
	//Starting ammo
	int ammo = 0;
	int maxAmmo = 10;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Adding ammo
		//OnCollisionEnter(Collision);
	}	
	
	public void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "player")
		{
			if(ammo < maxAmmo && ammo > 5)
			{
				//Adding Ammo
				ammo = 10;
				//Destroy Item
				Destroy(gameObject);
			}
			else if(ammo < maxAmmo && ammo < 5)
			{
				ammo += 5;
				Destroy(gameObject);
			}
			else 
			{
				Destroy(gameObject);	
			}
		}
	}
}
