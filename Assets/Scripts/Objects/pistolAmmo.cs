using UnityEngine;
using System.Collections;

public class pistolAmmo : MonoBehaviour {
	
	//Starting ammo
	int ammo = 0;
	int maxAmmo = 20;
	
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
			if(ammo < maxAmmo && ammo > 10)
			{
				//Adding Ammo
				ammo = 20;
				//Destroy Item
				Destroy(gameObject);
			}
			else if(ammo < maxAmmo && ammo < 10)
			{
				ammo += 10;
				Destroy(gameObject);
			}
			else 
			{
				Destroy(gameObject);	
			}
		}
	}
}
        
		

