using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMode : MonoBehaviour
{
    public Quaternion axeStartRot;

    public GameObject bullet;

    public GameObject Axe;
    public Vector3 offset = new Vector3(0, 1, 0);
    public int index = 1;

    public AudioSource bulletSound;

    // Start is called before the first frame update
    void Start()
    {
        Axe = GameObject.Find("Axe");
        axeStartRot = Axe.transform.localRotation;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && Input.GetKey(KeyCode.Space))
        {
            Axe.transform.localRotation = axeStartRot;
            Shoot();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && Input.GetKey(KeyCode.Space))
        {
            Axe.transform.localRotation = axeStartRot;
            Shoot();
        }
    }

    void Shoot()
    {
        bulletSound.Play();
        Instantiate(bullet, transform.position + offset, transform.rotation);
        
    }

    
}
