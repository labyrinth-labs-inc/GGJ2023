using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]GameObject leftHand;
    [SerializeField]GameObject rightHand;

    Animator animator;
    private void Awake() {
        //animator = this.GetComponent<Animator>();
    }
    public void Defeated()
    {
        //animator.enabled = false;
        leftHand.transform.parent = null;
        rightHand.transform.parent = null;
        //leftHand.tag = "Untagged";
        //rightHand.tag = "Untagged";
        leftHand.AddComponent<MeshCollider>().convex = true;
        Rigidbody rbLeftHand = leftHand.AddComponent<Rigidbody>();

        rightHand.AddComponent<MeshCollider>().convex = true;
        Rigidbody rbRightHand = rightHand.AddComponent<Rigidbody>();
        Destroy(leftHand, 3f);
        Destroy(rightHand, 3f);

        Die();
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
