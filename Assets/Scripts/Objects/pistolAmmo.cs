using UnityEngine;
using System.Collections;

public class pistolAmmo : MonoBehaviour {
	
	//Starting ammo
	public static int curPistolAmmo = 0;
	int maxAmmo = 20;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

	}	
	
	public void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "player")
		{
			if(curPistolAmmo < maxAmmo && curPistolAmmo > 10)
			{
				//Adding Ammo
				curPistolAmmo = 20;
				//Destroy Item
				Destroy(gameObject);
			}
			else if(curPistolAmmo < maxAmmo && curPistolAmmo < 10)
			{
				curPistolAmmo += 10;
				Destroy(gameObject);
			}
			else 
			{
				Destroy(gameObject);	
			}
		}
	}
}
        
		

