using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int id;
    int health = 100;
    public int maxHealth;
    public float speed = 5f;
    public Animator animator;
    public ParticleSystem ps;
    public AudioClip[] takeDamage;
    public AudioSource audio;
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SubHealth(int amount)
    {
        audio.clip = takeDamage[Random.Range(0, takeDamage.Length)];
        audio.Play();
        ps.Play();
        if (health < amount)
        {
            
            Destroy(gameObject);
        }
        health -= amount;
        
        
    }

    public void SetIsWalkingAnimation(bool state)
    {
        animator.SetBool("isWalking", state);
    }
    public void SetIsAttackAnimation(bool state)
    {
        animator.SetBool("isAttackRange", state);
    }

}
