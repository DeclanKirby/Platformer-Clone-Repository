using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    public bool facingRight = true;
    public float lifeSpan = 4.0f;

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
    }

    IEnumerator DespawnDelay()
    {
        yield return new WaitForSeconds(lifeSpan);
        Destroy(this.gameObject);
    }


}
