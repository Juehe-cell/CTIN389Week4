using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public GameObject Player;
    public float TargetDistance;
    public float AllowedDistance;
    public GameObject PetNPC;
    public float followSpeed;
    public RaycastHit Shot;
    public string PetState = "follow";

    // Update is called once per frame
    void Update()
    {
        if (PetState == "follow")
        {
            transform.LookAt(Player.transform);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
            {
                TargetDistance = Shot.distance;
                //within or out of range
                if (TargetDistance >= AllowedDistance)
                {
                    followSpeed = 1f;
                    //Pet.GetComponent<Animator>().Play("run");
                    transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, followSpeed);
                }
                else //if npc in range, stop moving 
                {
                    followSpeed = 0;
                    //Pet.GetComponent<Animation>().Play("idle");
                }
            }
        }
        else
        {
            Debug.Log("stay put");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (TryGetComponent<Player>(out var PlayerScript))
        {

        }
    }
}
