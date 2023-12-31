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
    public float timeBetweenShots;
    public GameObject bulletPrefab;
    public GameObject heavyBulletPrefab;

    public GameObject playerBackpack;
    public GameObject playerJetpack;

    public int health = 99;
    private int startingHealth = 99;

    public bool facingRight = true;

    public bool isBulletCoolDown = false;

    public float bulletCoolDown = 0.5f;

    private bool invulnerable = false;

    public int healthPack = 25;

    public bool hasHeavyBullet = false;

    Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyRef = GetComponent<Rigidbody>();
        startingHealth = health;
        originalPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(2);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump();
            
        }
        Shoot();
    }

    private void PlayerJump()
    {
        RaycastHit hit;

        //Adjust the value based on size of player character
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.2f))
        {
            
            rigidbodyRef.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {

            SpawnBullet();

            
        }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
        {


            
            if (facingRight){
                transform.Rotate(Vector3.up * 180);
                facingRight = false;
            
            }

            //shoot
            SpawnBullet();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            
            
            if (!facingRight){
                transform.Rotate(Vector3.up * 180);
                facingRight = true;
            
            }

            //shoot
            SpawnBullet();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BasicEnemy" && invulnerable == false)
        {
            health -= 15;
            StartCoroutine(InvulnerabilityDelay());
            StartCoroutine(Blink());
        }
        if (other.gameObject.tag == "Hard Enemy" && invulnerable == false)
        {
            health -= 35;
            StartCoroutine(InvulnerabilityDelay());
            StartCoroutine(Blink());
        }

        if (other.gameObject.tag == "BossBullet" && invulnerable == false)
        {
            health -= 45;
            StartCoroutine(InvulnerabilityDelay());
            StartCoroutine(Blink());
        }
        if (other.gameObject.tag == "Health Pack" && health < startingHealth)
        {
            health += healthPack;
            other.gameObject.SetActive(false);
            if (health >= startingHealth)
            {
                health = startingHealth;
            }
        }
        if (other.gameObject.tag == "Health Upgrade")
        {
            startingHealth = 199;
            health = startingHealth;
            other.gameObject.SetActive(false);
        }
        if(other.gameObject.tag == "Jet Pack")
        {
            jumpForce = jumpForce * 2;
            other.gameObject.SetActive(false);
            playerBackpack.SetActive(false);
            playerJetpack.SetActive(true);
            
        }

        if (other.gameObject.tag == "Heavy Bullet Upgrade")
        {
            hasHeavyBullet = true;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Portal")
        {
            transform.position = other.gameObject.GetComponent<Portal>().teleportPoint.transform.position;
            originalPos = transform.position;
        }
    }

   

    public void SpawnBullet()
    {
        Debug.Log("Starting Spawn Bullet");
        if(isBulletCoolDown == false)
        {
            if (hasHeavyBullet == false)
            {
                GameObject normalBullet = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation) as GameObject;
                if (normalBullet.GetComponent<Bullet>())
                {
                    normalBullet.GetComponent<Bullet>().facingRight = facingRight;
                    //Start cooldown
                    isBulletCoolDown = true;
                    StartCoroutine(CooldownDelay());
                }
            }

            if (hasHeavyBullet == true)
            {
                GameObject heavyBullet = Instantiate(heavyBulletPrefab, transform.position, heavyBulletPrefab.transform.rotation) as GameObject;
                if (heavyBullet.GetComponent<Bullet>())
                {
                    heavyBullet.GetComponent<Bullet>().facingRight = facingRight;
                    //Start cooldown
                    isBulletCoolDown = true;
                    StartCoroutine(CooldownDelay());
                }
            }

        }

        Debug.Log("Ending SPawn Bullet");

    }

    IEnumerator CooldownDelay()
    {
        yield return new WaitForSeconds(bulletCoolDown);
        isBulletCoolDown = false;
    }

    IEnumerator InvulnerabilityDelay()
    {
        invulnerable = true;
        yield return new WaitForSeconds(5);
        invulnerable = false;
    }

    IEnumerator Blink()
    {
        MeshRenderer[] Renderers = GetComponentsInChildren<MeshRenderer>();
        for (int index = 0; index < 50; index++)
        {
            if (index % 2 == 0)
            {
                for (int i = 0; i < Renderers.Length; i++)
                {
                    Renderers[i].enabled = false;
                }
            }
            else
            {
                for (int i = 0; i < Renderers.Length; i++)
                {
                    Renderers[i].enabled = true;
                }
            }
            yield return new WaitForSeconds(.1f);
        }
        for (int i = 0; i < Renderers.Length; i++)
        {
            Renderers[i].enabled = true;
        }
    }
}
