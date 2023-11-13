using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kelly, Aidan
//10/19/23
//Shoots boss bullet left or right forever

public class Spawner : MonoBehaviour
{
    public GameObject bossBulletPrefab;
    public float spawnRate = 1f;
    public bool shootRight = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShootBossBullet", 0, spawnRate);
    }

    private void ShootBossBullet()
    {
       GameObject bossBulletInstance = Instantiate(bossBulletPrefab, transform.position, transform.rotation);
        bossBulletInstance.GetComponent<BossBullet>().goingRight = shootRight;
    }
}
