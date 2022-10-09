using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public GameObject enemy;
    public GameManager gameManager;

    public bool canSpawn;

    public bool create;
    public Vector3 offset;
    public float cooldown = 5f;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        
        
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {


        

    }

    IEnumerator Spawn()
    {
        while (true)
        {

            yield return new WaitForSeconds(cooldown);
            Instantiate(enemy, transform.position + offset, enemy.transform.rotation);
            
            

        }
        
    }
}
