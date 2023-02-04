using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class MeshCutter : MonoBehaviour
{
    public GameObject cutDirection;
    Material crossSectionMaterial;
    GameObject objectToSlice;

    Vector3 oldPos;
    void Start() 
    {
        //StartCoroutine(GetOldPos());
    }
    // void Update()
    // {
    //     Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
    //     Debug.DrawRay(transform.position + offset, forward, Color.green);
    // }
    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Sliceable"))
        {
            objectToSlice = other.gameObject;
            Transform toParent = other.transform.parent;
            crossSectionMaterial = GetMaterial(objectToSlice);
            Vector3 direction = transform.TransformDirection(cutDirection.transform.forward);
            Vector3 posWorld = other.GetContact(0).point;
            List<GameObject> slicesList = Slice(posWorld, direction);
            if(slicesList != null)
            {
                objectToSlice.GetComponent<Enemy>().Defeated();
            }
            foreach (GameObject slice in slicesList)
            {
                slice.AddComponent<MeshCollider>().convex = true;
                Rigidbody rbSlice = slice.AddComponent<Rigidbody>();
                rbSlice.AddForce(direction*5f,ForceMode.Impulse);
                Destroy(slice,4f);
            }
        }
    }

    public List<GameObject> Slice(Vector3 planeWorldPosition, Vector3 planeWorldDirection) 
    {
        GameObject[] tempGoArray = objectToSlice.SliceInstantiate(planeWorldPosition, planeWorldDirection,
                                                                    new TextureRegion(0.0f, 0.0f, 1.0f, 1.0f),
                                                                    crossSectionMaterial);
        //if(tempGoArray == null)//Fazer Slice Fake
        List<GameObject> tempGoList = new List<GameObject>(tempGoArray);
        return tempGoList;
    }

    private Material GetMaterial(GameObject go)
    {
        Material getMaterial = go.GetComponent<MeshRenderer>().material;
        return getMaterial;
    }

    // IEnumerator GetOldPos()
    // {
    //     oldPos = this.transform.TransformPoint(Vector3.zero);
    //     yield return new WaitForSeconds(0.5f);
    //     StartCoroutine(GetOldPos());
    // }
}
