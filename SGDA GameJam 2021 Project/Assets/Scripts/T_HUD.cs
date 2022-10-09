using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_HUD : MonoBehaviour
{
    public GameObject next;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Swap();
        }
    }
    void Swap()
    {
        Vector3 temp;
        temp = transform.position;
        transform.position = next.transform.position;
        next.transform.position = temp;
    }
}
