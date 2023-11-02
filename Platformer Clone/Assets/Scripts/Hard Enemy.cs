using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemy : MonoBehaviour
{
    public float enemyHealth = 10;
    public float speed = 7;
    public float detectionRange = 6;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth <= 0)
        {
            gameObject.SetActive(false);
        }

        CheckForPlayer();
    }
    private void CheckForPlayer()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.right, out hit, detectionRange))
        {
            if (hit.collider.tag == "Player")
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }

        if (Physics.Raycast(transform.position, Vector3.left, out hit, detectionRange))
        {
            if (hit.collider.tag == "Player")
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }



    }
}
