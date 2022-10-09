using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer : MonoBehaviour
{
    public float flySpeed;
    public PlayerController player;
    public float range;
    public LayerMask playerLayer;
    public bool isInRange;

    public GameObject bullet;
    public AudioSource death;
    public bool follower;

    public float points;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        follower = true;
        player = FindObjectOfType<PlayerController>();
        StartCoroutine(followPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        isInRange = Physics2D.OverlapCircle(transform.position, range, playerLayer);

        if (follower)
        {
            Vector3.MoveTowards(transform.position, player.transform.position, flySpeed * Time.deltaTime);
            
        }
        if (isInRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, flySpeed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, range);
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            death.Play();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameManager.score += points;
            death.Play();
            Destroy(gameObject);
        }
    }
    IEnumerator followPlayer()
    {
        yield return new WaitForSeconds(10);
        
        follower = false;

    }
}
