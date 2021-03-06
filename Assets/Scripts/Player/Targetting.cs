using UnityEngine;
using System.Collections.Generic;

public class Targetting : MonoBehaviour
{
    public static Targetting instance;

    public static bool isMunching = false;

    public List<Transform> allTargets;

    public Transform currentTarget;

    //[HideInInspector]
    public bool hasTurned = false;

    public float munchDuration = 1.0f;

    public float range = 3.0f;
    public float shottyRange = 20.0f;
    [HideInInspector]
    public float shottyDist = 0.0f;
    [HideInInspector]
    public bool hasTurnedBack = false;
    [HideInInspector]
    public float curDist;
    
    private PlayerPhysics playerPhysics;

    private float munchDur = 0.0f;
    
    void Awake()
    {
        instance = this;

        playerPhysics = GetComponent<PlayerPhysics>();
    }

    // Use this for initialization
    void Start()
    {
        munchDur = munchDuration;

        allTargets = new List<Transform>();

        currentTarget = null;

        AddAllZombies();
    }

    public void AddAllHumans()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Human");

        foreach (GameObject target in go)
        {
            AddTarget(target.transform);
        }
    }

    public void AddAllZombies()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Zombie");

        foreach (GameObject target in go)
        {
            AddTarget(target.transform);
        }
    }

    void AddTarget(Transform target)
    {
        allTargets.Add(target);
    }

	// Update is called once per frame
	void Update ()
    {
        MunchControl();
	}

    private void MunchControl()
    {
        curDist = range;

        foreach (Transform target in allTargets)
        {
            if (allTargets.Count > 0)
            {
                float dist = Vector3.Distance(target.position, transform.position);

                HumanAIAttackController humanAttackai = target.GetComponent<HumanAIAttackController>();

                //calculate range for shotgun strength
                if (dist < shottyRange)
                {
                    shottyDist = (shottyDist / dist) + shottyRange;
                }

                //calculate distance to other targets
                if (dist < curDist)
                {
                    curDist = dist;

                    if (Input.GetMouseButton(1) && playerPhysics.zombieStates != PlayerPhysics.ZombieState.fullHuman)
                    {
                        humanAttackai.moveSpeed = 0;

                        munchDur -= Time.deltaTime;
                    }
                    if (Input.GetMouseButtonUp(1))
                    {
                        humanAttackai.moveSpeed = humanAttackai.forwardSpeed;
                    }
                }

                if (munchDur <= 0)
                {
                    playerPhysics.zombieStates--;
                    PlayerPhysics.killCount++;

                    Convert conv = target.GetComponent<Convert>();
                    conv.ConvertToZombie();

                    munchDur = munchDuration;
                }
            }
        }
    }
}
