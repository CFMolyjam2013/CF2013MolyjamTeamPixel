using UnityEngine;
using System.Collections;

public class BulletSpeed : MonoBehaviour
{
    private float bulletSpeed = 0.0f;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        bulletSpeed = PlayerPhysics.currentBulletSpeed;
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;

        Destroy(gameObject, 5);
	}
}
