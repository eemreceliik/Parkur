using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask obstacle,playerLayer;

    //Effect
    public GameObject deathEffect;


    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, obstacle))
        {
            GetComponent<LineRenderer>().enabled = true;


            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hit.point);

            GetComponent<LineRenderer>().startWidth = 0.10f + Mathf.Sin(Time.time)/75;

        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;



        }


        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, playerLayer))
        {

            hit.transform.gameObject.GetComponent<PlayerManeger>().Death();

        }


    }





}
