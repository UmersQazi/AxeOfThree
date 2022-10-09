using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour
{
    public float degreesPerSec = 360f;
    public Quaternion startRot;

    // Start is called before the first frame update
    void Start()
    {
        startRot = transform.localRotation;

    }

    // Update is called once per frame
    void Update()
    {
        float rotAmount = degreesPerSec * Time.deltaTime;
        float curRot = transform.localRotation.eulerAngles.z;
        
        if (Input.GetKey(KeyCode.Space))
        {
            

            
        }
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && Input.GetKey(KeyCode.Space))
        {
            transform.localRotation = startRot;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && Input.GetKey(KeyCode.Space))
        {
            transform.localRotation = startRot;
        }
    }
}
