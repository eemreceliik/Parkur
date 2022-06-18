using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{

    public float speed = 10f;
    public float lifetime = 5f;

    private void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        
        //transform.position += transform.forward * Time.deltaTime * speed;

        lifetime -= Time.deltaTime;

        if(lifetime <= 0)

        {

            Destroy(this.gameObject);
        }


    }
}
