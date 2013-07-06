using UnityEngine;
using System.Collections;

public class shotgunAmmo : MonoBehaviour 
{
	//Starting ammo
	public int curShotgunAmmo = 0;
	int maxAmmo = 10;
	
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
			if(curShotgunAmmo < maxAmmo && curShotgunAmmo > 5)
			{
				//Adding Ammo
				curShotgunAmmo = 10;
				//Destroy Item
				Destroy(gameObject);
			}
			else if(curShotgunAmmo < maxAmmo && curShotgunAmmo < 5)
			{
				curShotgunAmmo += 5;
				Destroy(gameObject);
			}
			else 
			{
				Destroy(gameObject);	
			}
		}
	}
}
