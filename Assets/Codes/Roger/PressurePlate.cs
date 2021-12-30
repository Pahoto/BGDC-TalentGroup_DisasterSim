using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    GameObject pressurePlate;
    GameObject obstacle;
    private GameObject[] pressurePlates;
    public int pressurePlateNumber;

    private float pressurePlateY;

    public bool pressed = false;
    private bool allPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        pressurePlate = this.gameObject;
        pressurePlateY = pressurePlate.transform.position.y;

        pressurePlates = GameObject.FindGameObjectsWithTag("Pressure Plate");

        obstacle = GameObject.Find("LALALA");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(pressed == false)
            {
                pressurePlate.GetComponent<Renderer>().material.color = Color.cyan;

                pressed = true;
                allPressed = true;

                foreach (GameObject pressurePlate in pressurePlates)
                {
                    if (pressurePlate.GetComponent<PressurePlate>().pressed == false)
                    {
                        allPressed = false;
                    }
                }

                if (allPressed == true)
                {
                    obstacle.SetActive(false);
                }
            }
        }
    }
    
}
