using UnityEngine;
using System.Collections.Generic;

public class Targetting : MonoBehaviour
{
    public List<Transform> allHumans;

    public Transform currentTarget;

    public float munchDuration = 1.0f;

    private PlayerPhysics playerPhysics;

    public float munchDur = 0.0f;
    public float curDist;
    public float range = 3.0f;

    void Awake()
    {
        playerPhysics = GetComponent<PlayerPhysics>();
    }

    // Use this for initialization
    void Start()
    {
        allHumans = new List<Transform>();

        currentTarget = null;

        AddAllHumans();
    }

    public void AddAllHumans()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Human");

        foreach (GameObject target in go)
        {
            AddTarget(target.transform);
        }
    }

    void AddTarget(Transform target)
    {
        allHumans.Add(target);
    }

    //private void SortByDist()
    //{
    //    allHumans.Sort(delegate(Transform t1, Transform t2)
    //    {
    //        return Vector3.Distance(t1.position, transform.position).CompareTo(
    //            Vector3.Distance(t2.position, transform.position));
    //    });
    //}

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.T) && playerPhysics.zombieStates != PlayerPhysics.ZombieState.fullZombie)
        {
            playerPhysics.zombieStates++;
        }
        MunchControl();
	}

    private void MunchControl()
    {
        curDist = range;

        foreach (Transform target in allHumans)
        {
            if (allHumans.Count > 0)
            {
                float dist = Vector3.Distance(target.position, transform.position);

                if (dist < curDist)
                {
                    curDist = dist;
                    currentTarget = target;

                    munchDur -= Time.deltaTime;
                    target.renderer.material.color = Color.red;
                }
                else
                {
                    target.renderer.material.color = Color.blue;
                }
            }
        }

        if (munchDur <= 0 && playerPhysics.zombieStates != PlayerPhysics.ZombieState.fullHuman)
        {
            playerPhysics.zombieStates--;
            munchDur = munchDuration;
        }
    }
}
