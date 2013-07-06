using UnityEngine;
using System.Collections;

public class rpgAmmo : MonoBehaviour 
{
	//Starting ammo
	int ammo = 0;
	int maxAmmo = 3;
	
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
			if(ammo < maxAmmo && ammo > 2)
			{
				//Adding Ammo
				ammo = 3;
				//Destroy Item
				Destroy(gameObject);
			}
			else if(ammo < maxAmmo && ammo < 2)
			{
				ammo += 1;
				Destroy(gameObject);
			}
			else 
			{
				Destroy(gameObject);	
			}
		}
	}
}
