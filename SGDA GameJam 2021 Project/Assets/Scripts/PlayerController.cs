using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 5f;
    public bool isOnGround;
    public Quaternion playerStartRot;
    public AudioSource change;
    public float health = 3f;
    public GameManager gameManager;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerStartRot = transform.localRotation;
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = playerStartRot;
        if (gameManager.gameOver != true && gameManager.canPlay)
        {
            horizontalInput = Input.GetAxis("Horizontal");

            transform.position += (Vector3.right * horizontalInput * Time.deltaTime * speed);
        }

    
        if (Input.GetKey(KeyCode.E)&&gameManager.gameOver == true && gameManager.canPlay)
        {

            change.Play();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("swing", true);
        }
        else
        {
            anim.SetBool("swing", false);
        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health--;
        }
        if (collision.gameObject.CompareTag("Health Item"))
        {
            health++;
            Destroy(collision.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Health Item"))
        {
            health++;
            Destroy(collision.gameObject);
        }
    }

}
