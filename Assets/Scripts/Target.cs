using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public Text CounterText;

    private int Count = 0;
    public float speed = 10;
    bool hitTheTop = false;
    private Playercontroller playerController;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<Playercontroller>();
        Count = 0;
       
    }
    private void Update()
    {
        MoveTheTarget();
    }

    private void OnTriggerEnter(Collider other)
    {
        Count += 1;
        CounterText.text = "Hits : " + Count;
        if(other.gameObject.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
        }
        
    }
    
    private void MoveTheTarget()
    {
        if (playerController.isGameActive)
        {
            if (!hitTheTop)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime);
            }


            if (transform.position.y < 3)
            {
                hitTheTop = false;
            }

            if (transform.position.y > 17)
            {

                hitTheTop = true;
            }
        }
    }
}
