using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed = 10;
    public bool goingRight = false;
    public float lifeSpan = 4.0f;
    

    public float damage = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DespawnDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if (goingRight == true)
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
