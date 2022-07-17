using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 rorateAxis;
    public float speed = 1f;

    private void Update()
    {
        transform.Rotate(rorateAxis * speed * Time.deltaTime);
    }
}
