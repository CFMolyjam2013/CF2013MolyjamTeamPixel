using UnityEngine;
using System.Collections;

public class foodObject : MonoBehaviour 
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
			if(bar.curBar != bar.maxBar)
			{
				
			}
			else
			{
				
			}
		}
	}
}
