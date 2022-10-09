using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleMode : MonoBehaviour
{
    public Quaternion axeStartRot;
    public GameObject next;
    public GameObject grass;
    public Vector3 offset = new Vector3(-2, -2, 0);
    public GameObject Axe;

    public AudioSource summonSound;


    public int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        Axe = GameObject.Find("Axe");
        axeStartRot = Axe.transform.localRotation;

    }

    // Update is called once per frame
    void Update()
    {
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
            Summon();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && Input.GetKey(KeyCode.Space))
        {
            Axe.transform.localRotation = axeStartRot;
            Summon();
        }
    }

    void Swap()
    {
        Vector3 temp;
        temp = transform.position;
        transform.position = next.transform.position;
        next.transform.position = temp;
    }

    void Summon()
    {
        summonSound.Play();
        Instantiate(grass, transform.position + (transform.forward)+offset, transform.rotation);
        
    }

}
