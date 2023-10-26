using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public int bulletSpeed = 5;

    public int health = 99;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (health <= 0)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(2);
        }
        */
    }

    private void Shoot()
    {
       
    }
    /*private void OnTriggerEnter(Collider other)
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
    */
}
