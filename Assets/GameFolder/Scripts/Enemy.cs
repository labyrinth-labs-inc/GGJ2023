using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Reference")]
    GameObject player;
    [SerializeField]GameObject leftHand;
    [SerializeField]GameObject rightHand;
    [SerializeField]Animator animator;
    public void Defeated()
    {
        animator.Play("none");
        animator.enabled = false;
        leftHand.transform.parent = null;
        rightHand.transform.parent = null;
        leftHand.AddComponent<MeshCollider>().convex = true;
        rightHand.AddComponent<MeshCollider>().convex = true;
        Rigidbody rbLeftHand = leftHand.AddComponent<Rigidbody>();
        Rigidbody rbRightHand = rightHand.AddComponent<Rigidbody>();
        rbLeftHand.velocity = rbLeftHand.transform.forward *-1;
        rbRightHand.velocity = rbRightHand.transform.forward *-1;
        Destroy(leftHand, 3f);
        Destroy(rightHand, 3f);
        Die();
    }
    private void Die()
    {
        Destroy(this.gameObject);
    }
    public GameObject GetPlayer()
    {
        return player;
    }
    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }
}
