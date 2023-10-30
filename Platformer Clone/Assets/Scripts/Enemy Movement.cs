using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Kirby, Declan
//10/23/2023
//Controls side to side enemy
public class SideToSideEnemy : MonoBehaviour
{

    public float travelDistanceRight = 0f;
    public float travelDistanceLeft = 0f;
    public float speed;
    private float startingX;
    public bool goingRight = true;
    private int health = 1;
    // Start is called before the first frame update
    void Start()
    {
        //When the scene starts, store the initial X value of this object
        startingX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (goingRight)
        {
            //If the object is not farther than the start position plus the right travel distance, it can move right
            if(transform.position.x <= startingX + travelDistanceRight)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }

            else
            {
                goingRight = false;
            }

        }
        //If the object is not farther than the start position + left travel distance, it can move left
        else
        {
            if (transform.position.x >= startingX + travelDistanceLeft)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            else goingRight = true;
        }

    }
    
    

}
