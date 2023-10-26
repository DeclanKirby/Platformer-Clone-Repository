using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * 180);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += transform.forward * 5 * Time.deltaTime;
        }
    }
}
