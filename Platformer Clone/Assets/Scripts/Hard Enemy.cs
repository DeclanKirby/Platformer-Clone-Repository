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
        Debug.DrawLine(transform.position + transform.up * 1.5f, transform.position + Vector3.left * 6 + transform.up * 1.5f, Color.red);
        Debug.DrawLine(transform.position + transform.up * 1.5f, transform.position + Vector3.right * 6 + transform.up * 1.5f, Color.red);
    }
    private void CheckForPlayer()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + transform.up * 1.5f, Vector3.right, out hit, detectionRange))
        {
            if (hit.collider.tag == "Player" || hit.collider.tag == "Backpack" || hit.collider.tag == "Player Jetpack")
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
        
        if (Physics.Raycast(transform.position + transform.up * 1.5f, Vector3.left, out hit, detectionRange))
        {
            if (hit.collider.tag == "Player" || hit.collider.tag == "Backpack" || hit.collider.tag == "Player Jetpack")
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }



    }
}
