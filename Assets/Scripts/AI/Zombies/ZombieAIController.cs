using UnityEngine;
using System.Collections;

public class ZombieAIController : MonoBehaviour
{
    public static ZombieAIController instance;

    public int curHealth = 100;
    
    private GameObject player;
    private PlayerPhysics playerPhysics;

    void Awake()
    {
        instance = this;

        player = GameObject.FindWithTag("player");
        playerPhysics = player.GetComponent<PlayerPhysics>();
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void HealthControl(int adj)
    {
        curHealth += adj;
    }
}
