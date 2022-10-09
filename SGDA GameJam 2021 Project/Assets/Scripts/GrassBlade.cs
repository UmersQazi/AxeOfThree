using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBlade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(grassDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator grassDestruct()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
