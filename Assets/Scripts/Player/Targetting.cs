using UnityEngine;
using System.Collections.Generic;

public class Targetting : MonoBehaviour
{
    public List<Transform> allTargets;

    public Transform currentTarget;

    public float munchDuration = 1.0f;

    public float range = 3.0f;
    public float shottyRange = 20.0f;
    [HideInInspector]
    public float shottyDist = 0.0f;

    private PlayerPhysics playerPhysics;

    private float munchDur = 0.0f;

    private float curDist;

    void Awake()
    {
        playerPhysics = GetComponent<PlayerPhysics>();
    }

    // Use this for initialization
    void Start()
    {
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
        if (Input.GetKeyDown(KeyCode.T) && playerPhysics.zombieStates != PlayerPhysics.ZombieState.fullZombie)
        {
            playerPhysics.zombieStates++;

            if (playerPhysics.zombieStates != PlayerPhysics.ZombieState.fullHuman)
            {
                allTargets.Clear();
                AddAllHumans();
            }
        }
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

                if (dist < shottyRange)
                {
                    shottyDist = (shottyDist / dist) + shottyRange;
                }

                if (dist < curDist)
                {
                    curDist = dist;

                    if (Input.GetMouseButton(1))
                    {
                        munchDur -= Time.deltaTime;
                    }
                }
            }
        }

        if (munchDur <= 0 && playerPhysics.zombieStates != PlayerPhysics.ZombieState.fullHuman)
        {
            playerPhysics.zombieStates--;
            munchDur = munchDuration;
        }

        if (playerPhysics.zombieStates == PlayerPhysics.ZombieState.fullHuman)
        {
            allTargets.Clear();
            AddAllZombies();
        }
    }
}
