using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    public float spinSpeed = 30f;
    public Vector3 spinDirection = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotate the object in the set direction by speed at degrees/second
        transform.Rotate(spinDirection * spinSpeed * Time.deltaTime);
    }
}
