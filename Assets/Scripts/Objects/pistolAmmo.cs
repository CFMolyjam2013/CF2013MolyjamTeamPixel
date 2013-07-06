using UnityEngine;
using System.Collections;

public class pistolAmmo : MonoBehaviour {
	
	//Starting ammo
	int ammo = 0;
	
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
			//Adding Ammo
			ammo += 10;
			//Destroy Item
		}
	}
}
        
		

