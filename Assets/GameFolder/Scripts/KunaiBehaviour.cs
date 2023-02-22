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
    void Start()
    {
        Invoke("Die", 10f);   
    }
    void OnCollisionEnter(Collision other) 
    {
        if(other.GetContact(0).otherCollider.gameObject.tag == "Defense")
        {
            if(owner)
            {
                Vector3 direction = (owner.transform.position - this.transform.position).normalized;
                this.transform.LookAt(owner.transform);
                this.transform.rotation = Quaternion.Euler(0,this.transform.rotation.eulerAngles.y,0);
                rb.velocity = direction*6f;
            }
            else
            {
                this.transform.forward = this.transform.forward *-1;
                rb.velocity = this.transform.forward*6f;
            }
        }
        else if(other.GetContact(0).otherCollider.gameObject.tag == "Sliceable")Invoke("Die",0.3f);
        else Die();
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
