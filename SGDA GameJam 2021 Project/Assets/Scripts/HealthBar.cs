using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    PlayerController player;
    public GameObject bar1;
    public GameObject bar2;
    public GameObject bar3;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.health == 3)
        {
            bar1.SetActive(true);
            bar3.SetActive(true);
            bar2.SetActive(true);
        }
        else if(player.health == 2)
        {
            bar1.SetActive(false);
            bar3.SetActive(true);
            bar2.SetActive(true);


        }else if(player.health == 1)
        {
            bar2.SetActive(false);
            bar1.SetActive(false);
            bar3.SetActive(true);



        }else if(player.health == 0)
        {
            bar1.SetActive(false);
            bar2.SetActive(false);
            bar3.SetActive(false);
        }
    }
}
