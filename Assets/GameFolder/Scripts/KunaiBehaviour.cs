using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiBehaviour : MonoBehaviour
{
    Rigidbody rb;
    GameObject owner;
    void Awake() 
    {
        rb = this.GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision other) 
    {
        if(other.GetContact(0).otherCollider.gameObject.tag == "Defense")
        {
            Vector3 direction = (owner.transform.position - this.transform.position).normalized;
            this.transform.LookAt(owner.transform);
            this.transform.rotation = Quaternion.Euler(0,this.transform.rotation.eulerAngles.y,0);
            rb.velocity = direction*6f;
            Invoke("Die", 6f);
        }
        else if(other.GetContact(0).otherCollider.gameObject.tag == "Sliceable")
        {
            rb.useGravity = true;
            Invoke("Die", 1f);
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
    public void SetOwner(GameObject go)
    {
        owner = go;
    }
}
