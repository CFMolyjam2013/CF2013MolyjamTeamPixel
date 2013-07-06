using UnityEngine;
using System.Collections;

public class foodObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
			//Modify bar so to take away hunger
		}
	}
}
