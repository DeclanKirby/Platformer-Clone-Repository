using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kelly, Aidan
//10/19/23
//Shoots lasers left or right forever

public class Spawner : MonoBehaviour
{
    public GameObject laserPrefab;
    public float spawnRate = 1f;
    public bool shootRight = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShootLaser", 0, spawnRate);
    }

    private void ShootLaser()
    {
        GameObject laserInstance = Instantiate(laserPrefab, transform.position, transform.rotation);
        laserInstance.GetComponent<Laser>().goingRight = shootRight;
    }
}
