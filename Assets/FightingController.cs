using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FightingController : MonoBehaviour
{
    public Transform sword;
    public Animator ani;
    public ParticleSystem ps;
    public AudioSource audioSource;

    public AudioClip[] sounds;

    public bool blocked;
    public int damage;
    public Camera cam;
    public float range;
    public float maxComboDelayTime;
    public float attackTime = 0f;
    public float attackTimer = 3f;
    bool canAttack = false;

    PlayerMovement pm;

    float numOfClicks = 0;

    private void Start()
    {
        pm = GetComponentInParent<PlayerMovement>();
    }

    void Update()
    {
   
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Block();

        }
        else
        {
            ani.SetBool("isBlock", false);
            blocked = false;

        }
        if (Input.GetMouseButtonDown(0) && !blocked)
        {
            
            
            
                Click();
            
        }
        
       if(canAttack)
        {
            attackTimer -= Time.deltaTime * 10;
        }
        if (attackTimer < 0)
        {
            ResetAttack();
        }

    }

    void Block()
    {
        blocked = true;
        ani.SetBool("isBlock", true);



    }
   
    void Attack()
    {
       
        
        ps.Play();
        
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
       


        if (Physics.Raycast(ray, out hit, LayerMask.NameToLayer("AI")))
        {
          if(Vector3.Distance(transform.position,hit.point) < range) { 

            Debug.Log("Did Hit");
            hit.transform.GetComponent<Enemy>().SubHealth(damage);
            }

        }
    }
    void Click()
    {
        
        if(numOfClicks == 0)
        {
            canAttack = true;
            attackTimer = attackTime;
            ani.SetFloat("NumClick", 1);
            numOfClicks++;
            Attack();
            audioSource.clip = sounds[0];
            audioSource.Play();
            return;
        }
        
        if(attackTimer > 0 && numOfClicks == 1)
        {
            Attack();
            ani.SetFloat("NumClick", 2);
            audioSource.clip = sounds[1];
            audioSource.Play();
            return;
        }        
    }

    void ResetAttack()
    {
        ani.SetFloat("NumClick", 0);
        numOfClicks = 0;
        attackTimer = 0f;
        canAttack = false;
    }

   
    
}



