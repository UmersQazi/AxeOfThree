using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMode : MonoBehaviour
{
    public Quaternion axeStartRot;
    public GameObject next;
    public Rigidbody2D playerBody;
    public GameObject Axe;
    public float jumpSpeed = 10f;
    public int index = 2;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        Axe = GameObject.Find("Axe");
        axeStartRot = Axe.transform.localRotation;
        playerBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerBody.velocity.y < 0)
        {
            playerBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (playerBody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            playerBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Swap();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && Input.GetKey(KeyCode.Space))
        {
            Axe.transform.localRotation = axeStartRot;
            Jump();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && Input.GetKey(KeyCode.Space))
        {
            Axe.transform.localRotation = axeStartRot;
            Jump();
        }
    }

    void Swap()
    {
        Vector3 temp;
        temp = transform.position;
        transform.position = next.transform.position;
        next.transform.position = temp;
    }

    void Jump()
    {
        jumpSound.Play();
        Axe.transform.localRotation = axeStartRot;
        playerBody.velocity = new Vector2(playerBody.velocity.x, jumpSpeed);
       
    }

}
