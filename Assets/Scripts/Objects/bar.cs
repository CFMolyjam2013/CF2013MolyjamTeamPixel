using UnityEngine;
using System.Collections;


public class bar : MonoBehaviour {
	
	public int maxBar = 20;
	public int curBar = 20;
 
	public Texture2D barBg;
	public Texture2D barFg;
 
	public float barLength;
	
	private PlayerPhysics playerPhysics;
	
	// Use this for initialization
	void Start () 
	{
		barLength = Screen.width /2;
		playerPhysics = GetComponent<PlayerPhysics>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(playerPhysics.zombieStates != PlayerPhysics.ZombieState.fullZombie)
		{
			//Hunger decrement
			AddjustCurrentHunger(1/60);	
		}
		else
		{
			AddjustCurrentZombie(5/60);	
		}
	}
	
	void OnGUI () {
		// Create one Group to contain both images
		// Adjust the first 2 coordinates to place it somewhere else on-screen
		GUI.BeginGroup (new Rect (0,0, barLength,32));
	 
		// Draw the background image
		GUI.Box (new Rect (0,0, barLength,32), barBg);
	 
		// Create a second Group which will be clipped
		// We want to clip the image and not scale it, which is why we need the second Group
		GUI.BeginGroup (new Rect (0,0, curBar / maxBar * barLength, 32));
	 
			// Draw the foreground image
			GUI.Box (new Rect (0,0,barLength,32), barFg);
	 
		// End both Groups
		GUI.EndGroup ();
	 
	GUI.EndGroup ();
	}
	 
	public void AddjustCurrentHunger(int adj)
	{ 
		curBar -= adj;
		
		if(curBar <0)
		{
			curBar = 0;	
		}
		
		if(curBar > maxBar)
		{
			curBar = maxBar;	
		}
		
		if(maxBar <1)
		{
			maxBar = 1;
		}
		
		barLength = (Screen.width /2)* (curBar / (float)maxBar);
	}
	
	public void AddjustCurrentZombie(int adj)
	{ 
		curBar -= adj;
		
		if(curBar <0)
		{
			curBar = 0;	
		}
		
		if(curBar > maxBar)
		{
			curBar = maxBar;	
		}
		
		if(maxBar <1)
		{
			maxBar = 1;
		}
		
		barLength = (Screen.width /2)* (curBar / (float)maxBar);
	}
}
