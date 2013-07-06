using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour
{
    public static bool hasRpg = false;

    public static float currentBulletSpeed = 0.0f;

    //speeds of player in zombie states
    public float fullHumanSpeed = 10.0f;
    public float partHumanSpeed = 20.0f;
    public float halfZombieSpeed = 30.0f;
    public float nearFullZombieSpeed = 40.0f;
    public float fullZombieSpeed = 60.0f;

    public float playerRotSpeed = 120.0f;

    //weapon fire rates
    public float pistolFireRate = 0.5f;
    public float shottyFireRate = 1.5f;
    public float rpgFireRate = 2.5f;

    //bullet speeds
    public float pistolBulletSpeed = 1.0f;
    public float shottyBulletSpeed = 0.5f;
    public float rpgRocketSpeed = 1.0f;

    //projectiles
    public Transform pistolBullet;
    public Transform shottyShell;
    public Transform rpgChainsawRocket;

    //gid sizes
    public int xGridSize = 4;
    public int yGridSize = 4;

    private int frameDir = 0;
    private int currentFrame = 0;

    //position of the grid tiles
    private float xGridPos = 0.0f;
    private float yGridPos = 0.0f;

    //frame times
    private float frameDur = 0.0f;
    private float nextTimeFrame = 0.0f;

    private float angle = 0.0f;
    private float counterActAngle = 90.0f;

    private Transform currentProjectile;

    public enum WeaponSelect
    {
        pistol,
        shotty,
        rpgChainsaw,
        melee
    }

    public WeaponSelect weaponSelected { get; set; }

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

    void Start()
    {
        weaponSelected = WeaponSelect.pistol;
    }
    
    // Update is called once per frame
    void Update()
    {
        print(SetFireRate());

        Aiming();
        WeaponSelection();
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

    void WeaponSelection()
    {
        //pistol select
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponSelected = WeaponSelect.pistol;
            currentBulletSpeed = pistolBulletSpeed;
            currentProjectile = pistolBullet;
        }
        //shotty select
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponSelected = WeaponSelect.shotty;
            currentBulletSpeed = shottyBulletSpeed;
            currentProjectile = shottyShell;
        }
        //rpg select
        if (Input.GetKeyDown(KeyCode.Alpha3) && hasRpg)
        {
            weaponSelected = WeaponSelect.rpgChainsaw;
            currentBulletSpeed = rpgRocketSpeed;
            currentProjectile = rpgChainsawRocket;
        }
        //melee select
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            weaponSelected = WeaponSelect.melee;
        }
    }

    float SetFireRate()
    {
        float fireRate = 0.0f;

        switch (weaponSelected)
        {
            case WeaponSelect.pistol:
                fireRate = pistolFireRate;
                break;
            case WeaponSelect.shotty:
                fireRate = shottyFireRate;
                break;
            case WeaponSelect.rpgChainsaw:
                fireRate = rpgFireRate;
                break;
        }

        return fireRate;
    }

    void Firing()
    {
        if (Input.GetMouseButton(0) && !IsInvoking("Fire"))
        {
            InvokeRepeating("Fire", 0, SetFireRate());
        }
        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke("Fire");
        }
    }

    void Fire()
    {
        Instantiate(currentProjectile, transform.position, transform.rotation);
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