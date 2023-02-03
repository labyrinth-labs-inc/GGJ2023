using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadishBehaviour : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] GameObject player;
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
