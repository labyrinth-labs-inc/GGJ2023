using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class MeshCutter : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] AudioSource audioSource;
    [SerializeField]List<AudioClip> attackSounds;
    [SerializeField]List<AudioClip> defenseSounds;
    public GameObject cutDirection;
    Material crossSectionMaterial;
    GameObject objectToSlice;

    Vector3 oldPos;

    void OnCollisionEnter(Collision other) 
    {
        if(other.GetContact(0).otherCollider.gameObject.CompareTag("Sliceable"))
        {
            if(audioSource)PlayAttackingSounds();
            objectToSlice = other.gameObject;
            crossSectionMaterial = GetMaterial(objectToSlice);
            Vector3 direction = transform.TransformDirection(cutDirection.transform.forward);
            Vector3 posWorld = other.GetContact(0).point;
            List<GameObject> slicesList = Slice(posWorld, direction);
            if(slicesList != null)
            {
                objectToSlice.GetComponent<Enemy>().Defeated();
                foreach (GameObject slice in slicesList)
                {
                    slice.layer = 6; //Sliced Layer
                    slice.AddComponent<MeshCollider>().convex = true;
                    Rigidbody rbSlice = slice.AddComponent<Rigidbody>();
                    Destroy(slice,4f);
                }
            }
        }
        else if(other.GetContact(0).otherCollider.gameObject.CompareTag("SliceableMenu"))
        {
            objectToSlice = other.gameObject;
            crossSectionMaterial = GetMaterial(objectToSlice);
            Vector3 direction = transform.TransformDirection(cutDirection.transform.forward);
            Vector3 posWorld = other.GetContact(0).point;
            List<GameObject> slicesList = Slice(posWorld, direction);
            if(slicesList != null)
            {
                Destroy(objectToSlice);
                foreach (GameObject slice in slicesList)
                {
                    slice.layer = 6; //Sliced Layer
                    slice.AddComponent<MeshCollider>().convex = true;
                    Rigidbody rbSlice = slice.AddComponent<Rigidbody>();
                    Destroy(slice,4f);
                }
            }
        }
        else if(other.GetContact(0).otherCollider.gameObject.CompareTag("Enemy"))
        {
            objectToSlice = other.gameObject;
            Debug.Log("Parry");
            objectToSlice.GetComponent<Enemy>().Parry();
            if(audioSource)PlayDefendingSounds();
        }
        else if(other.GetContact(0).otherCollider.gameObject.CompareTag("Kunai"))
            if(audioSource)PlayDefendingSounds();
    }

    public List<GameObject> Slice(Vector3 planeWorldPosition, Vector3 planeWorldDirection) 
    {
        GameObject[] tempGoArray = objectToSlice.SliceInstantiate(planeWorldPosition, planeWorldDirection,
                                                                    new TextureRegion(0.0f, 0.0f, 1.0f, 1.0f),
                                                                    crossSectionMaterial);
        if(tempGoArray == null)
        {
            objectToSlice.GetComponent<Enemy>().Parry();
            return null;
        }
        List<GameObject> tempGoList = new List<GameObject>(tempGoArray);
        return tempGoList;
    }

    private Material GetMaterial(GameObject go)
    {
        Material getMaterial = go.GetComponent<MeshRenderer>().material;
        return getMaterial;
    }

    private void PlayAttackingSounds()
    {
        audioSource.clip = attackSounds[Random.Range(0,attackSounds.Count)];
        audioSource.Play();
    }
    private void PlayDefendingSounds()
    {
        audioSource.clip = defenseSounds[Random.Range(0,defenseSounds.Count)];
        audioSource.Play();
    }
}
