using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 5f;
    public Vector3 bulletPos;
    public Rigidbody2D bulletBody;
    public float destruct = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        transform.position += (Vector3.up * bulletSpeed * Time.deltaTime);
        StartCoroutine(bulletDestruct());
    }


    IEnumerator bulletDestruct()
    {
        yield return new WaitForSeconds(destruct);
        Destroy(gameObject);
    }
}
