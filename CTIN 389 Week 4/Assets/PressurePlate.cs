using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressurePlate : MonoBehaviour
{
    public bool iswin;
    public GameObject elevator;
    public GameObject wintext;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (elevator != null)
            {
                elevator.GetComponent<ElevatorNew>().powered = true;
            }
            if (iswin == true) { wintext.SetActive(true); }
        }


    }
}
