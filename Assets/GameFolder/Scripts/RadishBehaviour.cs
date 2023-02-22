using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadishBehaviour : Enemy
{
    Rigidbody rb;
    [Header("Sounds")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] List<AudioClip> dyingSounds;
    [SerializeField] List<AudioClip> shoutingSounds;
    [Header("Attributes")]
    [SerializeField] float velocity = 3f;
    [SerializeField] float distanceToPlayer = 3f;
    bool canAttack = true;

    void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        PlayShouting();
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
        if(GetParry() && !canAttack)
        {
            GetAnimator().Play("RadishDefense");
            SetParry(false);   
        }    
        if(GetDefeated())
        {
            Debug.Log("isDefeated");
            this.GetComponent<MeshCollider>().enabled = false;
            this.GetComponent<MeshRenderer>().enabled = false;
            SetDefeated(false);
            audioSource.transform.SetParent(null, false);
            PlayDying();
            Destroy(audioSource.gameObject, audioSource.clip.length);
            Destroy(this.gameObject, audioSource.clip.length);
        }
    }

    IEnumerator Attack()
    {
        if(canAttack && !GetParry())
        {
            canAttack = false;
            GetAnimator().Play("RadishAttack");
            GetAnimator().SetTrigger("idle");
            yield return new WaitForSeconds(3f);
            canAttack = true;
        }
        yield return null;
    }

    private void PlayShouting()
    {
        audioSource.clip = shoutingSounds[Random.Range(0,shoutingSounds.Count)];
        audioSource.Play();
    }
    private void PlayDying()
    {
        audioSource.clip = dyingSounds[Random.Range(0,dyingSounds.Count)];
        audioSource.Play();
    }
}
