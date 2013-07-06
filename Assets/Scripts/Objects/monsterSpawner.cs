using UnityEngine;
using System.Collections;

public class monsterSpawner : MonoBehaviour 
{
	public GameObject enemyToSpawn = null;
	
	public float spawnDelayMin = 5.0f;
	public float spawnDelayMax = 8.0f;
	
	private float _nextSpawnTime = 0.0f;
	private GameObject _spawnedEnemy = null;
	private Transform _t = null;
	
	// Use this for initialization
	void Start () 
	{
		//Caching the transform
		_t = transform;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( _spawnedEnemy == null && Time.time > _nextSpawnTime)
		{
			//Setting the time for the next spawn
			_nextSpawnTime = Time.time +Random.Range(spawnDelayMin,spawnDelayMax);
			
			//Spawning the enemy
			_spawnedEnemy = Instantiate(enemyToSpawn,_t.position,Quaternion.identity) as GameObject;
			
		}
	}
}
