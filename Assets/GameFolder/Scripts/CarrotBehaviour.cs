using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotBehaviour : Enemy
{
    Rigidbody rb;
    [SerializeField] GameObject spawnPoint;
    [Header("Attributes")]
    [SerializeField] float velocity = 3f;
    [SerializeField] float distanceToPlayer = 3f;
    [Header("Prefab")]
    [SerializeField] GameObject kunaiPrefab;

    bool canAttack = true;

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
        else 
        {
            rb.velocity = Vector3.zero;
            StartCoroutine(Attack());
        }
        if(GetDefeated())
        {
            Debug.Log("isDefeated");
            this.GetComponent<MeshCollider>().enabled = false;
            this.GetComponent<MeshRenderer>().enabled = false;
            SetDefeated(false);
            Destroy(this.gameObject, 3f);
        }
    }

    IEnumerator Attack()
    {
        if(canAttack)
        {
            canAttack = false;
            GetAnimator().Play("CarrotAttack");
            GameObject go = Instantiate(kunaiPrefab,
                                        spawnPoint.transform.position,
                                        spawnPoint.transform.rotation);
            go.GetComponent<Rigidbody>().velocity = go.transform.forward * 3f;
            go.GetComponent<KunaiBehaviour>().SetOwner(this.gameObject);
            yield return new WaitForSeconds(6f);
            canAttack = true;
        }
        yield return null;
    }
    
}
