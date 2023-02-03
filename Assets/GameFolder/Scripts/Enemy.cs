using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField]GameObject player;
    [SerializeField]GameObject leftHand;
    [SerializeField]GameObject rightHand;

    public void Defeated()
    {
        leftHand.transform.parent = null;
        rightHand.transform.parent = null;
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
