using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    public bool facingRight = true;
    public float lifeSpan = 4.0f;
    public float bulletHitDist = 0.5f;

    public float damage = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DespawnDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if (facingRight == true)
        {
            transform.position += speed * Vector3.right * Time.deltaTime;
        }
        else
        {
            transform.position += speed * Vector3.left * Time.deltaTime;
        }

        CheckForEnemy();
    }


    private void CheckForEnemy()
    {
        RaycastHit hit;

        //Detects collision for enemies
        if (Physics.Raycast(transform.position, Vector3.right, out hit, bulletHitDist))
        {
            if (hit.collider.tag == "BasicEnemy")
            {
                hit.collider.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }

        if (Physics.Raycast(transform.position, Vector3.left, out hit, bulletHitDist))
        {
            if (hit.collider.tag == "BasicEnemy")
            {
                hit.collider.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }

        //Detect collision for harder enemies
        if (Physics.Raycast(transform.position, Vector3.right, out hit, bulletHitDist))
        {
            if (hit.collider.tag == "Hard Enemy")
            {
                hit.collider.gameObject.GetComponent<HardEnemy>().enemyHealth -= damage;
                gameObject.SetActive(false);
            }
        }

        if (Physics.Raycast(transform.position, Vector3.left, out hit, bulletHitDist))
        {
            if (hit.collider.tag == "Hard Enemy")
            {
                hit.collider.gameObject.GetComponent<HardEnemy>().enemyHealth -= damage;
                gameObject.SetActive(false);
            }
        }

        if (Physics.Raycast(transform.position, Vector3.right, out hit, bulletHitDist))
        {
            if (hit.collider.tag == "CubeMan")
            {
                hit.collider.gameObject.GetComponent<BossController>().health -= damage;
                gameObject.SetActive(false);
            }
        }

        if (Physics.Raycast(transform.position, Vector3.left, out hit, bulletHitDist))
        {
            if (hit.collider.tag == "CubeMan")
            {
                hit.collider.gameObject.GetComponent<BossController>().health -= damage;
                gameObject.SetActive(false);
            }
        }
        if (Physics.Raycast(transform.position, Vector3.right, out hit, bulletHitDist))
        {
            if (hit.collider.tag == "Breakable Wall")
            {
                hit.collider.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }


    IEnumerator DespawnDelay()
    {
        yield return new WaitForSeconds(lifeSpan);
        Destroy(this.gameObject);
    }


}
