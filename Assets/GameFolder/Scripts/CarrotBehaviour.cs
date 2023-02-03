using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotBehaviour : Enemy
{
    Rigidbody rb;

    [Header("Attributes")]
    [SerializeField] float velocity = 3f;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.velocity = this.transform.forward * velocity;
    }
}
