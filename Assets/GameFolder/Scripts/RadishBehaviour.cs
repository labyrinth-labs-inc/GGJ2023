using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadishBehaviour : Enemy
{
    Rigidbody rb;

    [Header("Attributes")]
    [SerializeField] float velocity = 3f;
    [SerializeField] float distanceToPlayer = 3f;

    void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float distance = Vector3.Distance(GetPlayer().transform.position, this.transform.position);
        Vector3 direction = (GetPlayer().transform.position - this.transform.position).normalized;
        this.transform.LookAt(GetPlayer().transform);
        this.transform.rotation = Quaternion.Euler(0,this.transform.rotation.eulerAngles.y,0);
        if(distance > distanceToPlayer)
            rb.velocity = direction * velocity;
        else rb.velocity = Vector3.zero;
    }
}
