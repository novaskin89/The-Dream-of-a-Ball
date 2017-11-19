using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public Transform meteor;
    public Transform[] meteorSpawnPoints;
    public float spawnDelay;
    public float speed;
	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("SpawnMeteor", spawnDelay, spawnDelay);
	}


    void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * speed);
    }
    
    void SpawnMeteor()
    {
        int randomIndex = Random.Range(0, meteorSpawnPoints.Length);
        Instantiate(meteor, meteorSpawnPoints[randomIndex].position, Quaternion.identity);

    }
}
