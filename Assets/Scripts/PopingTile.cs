using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopingTile : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Material originalMaterial;
    [SerializeField] Material flashMaterial;
    [SerializeField] ParticleSystem particles;

    void Start()
    {
        Instantiate(particles,transform.position,Quaternion.identity);
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        originalMaterial = sr.material;
        transform.position -= new Vector3(0,0,5);
        StartCoroutine(ApplyEffects());
    }
    void Update()
    {   
        if(transform.localScale != Vector3.zero)
        {
            transform.localScale -=new Vector3(0.03f,0.03f,0.03f);
        }
        // else if(transform.localScale == Vector3.zero)
        // {
        //     Destroy(gameObject);
        // }        
    }
    IEnumerator ApplyEffects()
    {
        rb.AddForce(new Vector2(Random.Range(-2,2),Random.Range(6,8)),ForceMode2D.Impulse);
        rb.AddTorque(Random.Range(-5,5),ForceMode2D.Impulse);
        sr.material = flashMaterial;
        yield return new WaitForSeconds(0.15f);
        sr.material = originalMaterial;
        sr.material.color = Color.grey;
        yield return new WaitForSeconds(0.20f);
        Destroy(gameObject);
    }
}
