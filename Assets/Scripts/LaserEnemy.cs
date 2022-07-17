using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask obstacle,playerLayer;

    //Effect
    public GameObject deathEffect;
    private bool lazerHit;
    public float range = 100f;


    private void Update()
    {
        //Line Renderer
        if (Physics.Raycast(transform.position, transform.forward, out hit, range, obstacle))
        {
            GetComponent<LineRenderer>().enabled = true;
            lazerHit = true;

            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hit.point);

            GetComponent<LineRenderer>().startWidth = 0.10f + Mathf.Sin(Time.time)/75;

        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
            lazerHit = false;



        }


        if (Physics.Raycast(transform.position, transform.forward, out hit, range, playerLayer))
        {
            if (lazerHit)
            {
                hit.transform.gameObject.GetComponent<PlayerManeger>().Death();
            }

        }


    }





}
