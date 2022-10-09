using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler : MonoBehaviour
{
    public float enemySpeed = 5f;
    SpriteRenderer sprite;
    public GameObject pipe;
    public Pipe prompt;
    public float count;
    public float points;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        prompt = pipe.GetComponent<Pipe>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.canPlay)
        transform.position += (Vector3.right * Time.deltaTime * enemySpeed);
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grass"))
        {

            
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("End") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Grass"))
        {
            gameManager.score += points;
            prompt.create = true;
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("End") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
    IEnumerator flip()
    {
        yield return new WaitForSeconds(3);
       
        enemySpeed = -enemySpeed;

        StartCoroutine(flip2());
    }
    IEnumerator flip2()
    {
        yield return new WaitForSeconds(3);
        enemySpeed = -enemySpeed;
        
    }
}
