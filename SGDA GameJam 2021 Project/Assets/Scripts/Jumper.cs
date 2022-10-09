using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    Rigidbody2D enemyBody;
    public float jumpTime = 3f;
    public float jumpSpeed = 5f;
    public GameObject player;
    public Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        enemyBody = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(Jump());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(jumpTime);

        enemyBody.velocity = new Vector2(enemyBody.velocity.x, jumpSpeed);
        gameObject.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, jumpSpeed*Time.deltaTime);

    }
}
