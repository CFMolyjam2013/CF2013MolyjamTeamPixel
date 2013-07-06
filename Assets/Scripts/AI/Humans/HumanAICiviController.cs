using UnityEngine;
using System.Collections;

public class HumanAICiviController : MonoBehaviour
{
    //movement variables
    public float fleeSpeed = 10.0f;
    public float calmMoveSpeed = 5.0f;
    public float rotateSpeed = 20.0f;

    public float maxFleeRange = 50.0f;

    //to randomize face direction
    public int randomRot = 1;

    public float moveSpeed = 0.0f;
    
    private GameObject player;
    private PlayerPhysics playerPhysics;

    private bool isMoving = true;

    private Quaternion rot;

    public enum MoveState
    {
        fleeing,
        calm,
        stopped
    }

    public MoveState moveStates { get; set; }    

    void Awake()
    {
        player = GameObject.FindWithTag("player");
        playerPhysics = player.GetComponent<PlayerPhysics>();
    }

    void Start()
    {
        moveSpeed = calmMoveSpeed;
    }

	// Update is called once per frame
	void Update ()
    {
        ProcessMotion();
        MoveSpeed();
	}

    void ProcessMotion()
    {
        Vector3 targetDir = player.transform.position - transform.position;

        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (playerPhysics.zombieStates != PlayerPhysics.ZombieState.fullHuman && dist < maxFleeRange)
        {
            CancelInvoke("RandomizeRotation");

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(-targetDir), rotateSpeed);
        }
        else
        {
            if (!IsInvoking("RandomizeRotation") && isMoving)
            {
                Invoke("RandomizeRotation", 2);
                StartCoroutine("WaitAndGo", 2);
            }           
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, rotateSpeed * Time.deltaTime);
        }
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void MoveSpeed()
    {
        switch (moveStates)
        {
            case MoveState.calm:
                moveSpeed = calmMoveSpeed;
                break;
            case MoveState.fleeing:
                moveSpeed = fleeSpeed;
                break;
            case MoveState.stopped:
                moveSpeed = 0;
                break;
        }
    }

    void RandomizeRotation()
    {
        moveStates = MoveState.stopped;
        randomRot = Random.Range(-10, 60);
        rot = Quaternion.AngleAxis(randomRot, Vector3.up) * transform.rotation;
    }

    IEnumerator WaitAndGo(float waitTime)
    {
        isMoving = false;

        yield return new WaitForSeconds(waitTime);

        moveStates = MoveState.calm;
        isMoving = true;
    }
}
