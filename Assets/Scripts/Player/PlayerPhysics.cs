using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour
{
    //speeds of player in zombie states
    public float fullHumanSpeed = 10.0f;
    public float partHumanSpeed = 20.0f;
    public float halfZombieSpeed = 30.0f;
    public float nearFullZombieSpeed = 40.0f;
    public float fullZombieSpeed = 60.0f;

    public float playerRotSpeed = 120.0f;

    //gid sizes
    public int xGridSize = 4;
    public int yGridSize = 4;

    private int frameDir = 0;
    private int currentFrame = 0;

    //position of the grid tiles
    private float xGridPos = 0.0f;
    private float yGridPos = 0.0f;

    private float frameDur = 0.0f;
    private float nextTimeFrame = 0.0f;

    private float angle = 0.0f;
    private float counterActAngle = 90.0f;

    //zombie levels
    public enum ZombieState
    {
        fullHuman,
        partHuman,
        halfZombie,
        nearFullZombie,
        fullZombie
    }

    public ZombieState zombieStates { get; set; }
    
    // Update is called once per frame
    void Update()
    {
        print(zombieStates);

        Aiming();
        Firing();
        GetMotion();
    }

    void Aiming()
    {
        Vector3 mousePos = Input.mousePosition;

        Vector3 objPos = Camera.main.WorldToScreenPoint(transform.position);

        //get relative position from mouse position and player
        mousePos.x = mousePos.x - objPos.x;
        mousePos.y = mousePos.y - objPos.y;

        //get angle
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        //get rotation
        Quaternion rot = Quaternion.Euler(new Vector3(0, -angle + counterActAngle, 0));
        //apply rotation
        transform.rotation = rot;
    }

    void Firing()
    {

    }

    void GetMotion()
    {
        //get input
        float vInput = Input.GetAxisRaw("Vertical");
        float hInput = Input.GetAxisRaw("Horizontal");

        //set grid tiles
        xGridPos = 1.0f / xGridSize;
        yGridPos = 0.5f;

        //set scale
        renderer.material.mainTextureScale = new Vector2(vInput * xGridPos, yGridPos);

        if (Time.time - nextTimeFrame > frameDur)
        {
            nextTimeFrame = Time.time + frameDur;

            if (vInput > 0)
            {
                currentFrame++;
            }
            if (vInput < 0)
            {
                currentFrame--;
            }

            //loop frames
            if (currentFrame >= xGridSize || currentFrame <= -xGridSize)
            {
                currentFrame = 0;
            }

            //apply frames
            renderer.material.mainTextureOffset = new Vector2(vInput * ((currentFrame) % xGridSize + 1) * xGridPos, 1);
        }

        //rotate
        Quaternion rot = Quaternion.AngleAxis(hInput * playerRotSpeed * Time.deltaTime, transform.up) * transform.rotation;
        transform.rotation = rot;
        //move forward
        transform.position += transform.forward * vInput * MoveSpeed() * Time.deltaTime;
    }

    //set speed according to zombie state
    float MoveSpeed()
    {
        float moveSpeed = 0.0f;

        switch (zombieStates)
        {
            case ZombieState.fullHuman:
                moveSpeed = fullHumanSpeed;
                break;
            case ZombieState.partHuman:
                moveSpeed = partHumanSpeed;
                break;
            case ZombieState.halfZombie:
                moveSpeed = halfZombieSpeed;
                break;
            case ZombieState.nearFullZombie:
                moveSpeed = nearFullZombieSpeed;
                break;
            case ZombieState.fullZombie:
                moveSpeed = fullZombieSpeed;
                break;
        }

        return moveSpeed;
    }
}