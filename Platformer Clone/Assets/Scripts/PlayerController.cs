using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //These are movement variables
    public float speed = 10f;
    public float jumpForce = 7f;
    private Rigidbody rigidbodyRef;

    public int bulletSpeed = 5;

    public int health = 99;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyRef = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Game Over");
            //SceneManager.LoadScene(2);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            PlayerJump();
        }
    }

    private void PlayerJump()
    {
        RaycastHit hit;

        //Adjust the value based on size of player character
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.8f))
        {
            
            rigidbodyRef.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void Shoot()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BasicEnemy")
        {
            health += -15;
        }
        if (other.gameObject.tag == "AdvancedEnemy")
        {
            health += -35;
        }
    }
}
