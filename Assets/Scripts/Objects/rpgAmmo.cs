using UnityEngine;
using System.Collections;

public class rpgAmmo : MonoBehaviour 
{
	//Starting ammo
	public int curRpgAmmo = 0;
	int maxAmmo = 3;
	
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
			if(curRpgAmmo < maxAmmo && curRpgAmmo > 2)
			{
				//Adding Ammo
				curRpgAmmo = 3;
				//Destroy Item
				Destroy(gameObject);
			}
			else if(curRpgAmmo < maxAmmo && curRpgAmmo < 2)
			{
				curRpgAmmo += 1;
				Destroy(gameObject);
			}
			else 
			{
				Destroy(gameObject);	
			}
		}
	}
}
