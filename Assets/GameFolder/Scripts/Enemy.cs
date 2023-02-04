using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Reference")]
    GameObject player;
    bool isParry = false;
    [SerializeField]GameObject leftHand;
    [SerializeField]GameObject rightHand;
    [SerializeField]Animator animator;
    public void Defeated()
    {
        animator.enabled = false;
        animator.Play("none");
        this.transform.DetachChildren();
        leftHand.AddComponent<MeshCollider>().convex = true;
        rightHand.AddComponent<MeshCollider>().convex = true;
        Rigidbody rbLeftHand = leftHand.AddComponent<Rigidbody>();
        Rigidbody rbRightHand = rightHand.AddComponent<Rigidbody>();
        Destroy(leftHand, 3f);
        Destroy(rightHand, 3f);
        Die();
    }
    private void Die()
    {
        Destroy(this.gameObject);
    }
    public void Parry()
    {
        isParry = true;
    }
    public bool GetParry()
    {
        return isParry;
    }
    public void SetParry(bool value)
    {
        isParry = value;
    }
    public GameObject GetPlayer()
    {
        return player;
    }
    public Animator GetAnimator()
    {
        return animator;
    }
    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }

}
