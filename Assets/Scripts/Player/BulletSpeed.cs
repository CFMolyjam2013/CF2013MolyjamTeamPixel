using UnityEngine;
using System.Collections;

public class BulletSpeed : MonoBehaviour
{
    private float bulletSpeed = 0.0f;

    private int damage = 0;
		
	// Update is called once per frame
	void Update ()
    {
        print(damage);
        Speed();

        Kill();
	}

    void Speed()
    {
        bulletSpeed = PlayerPhysics.currentBulletSpeed;
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }

    void Kill()
    {
        Destroy(gameObject, 5);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Zombie")
        {
            damage = PlayerPhysics.currDamage;
            ZombieAIController.instance.HealthControl(-damage);

            Destroy(gameObject);
        }
    }
}
