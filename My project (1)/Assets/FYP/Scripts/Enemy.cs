using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public int HP = 100;
    public int atk = 25;
    public int def = 1;
    MainCharacter mc;
    public float attackRate = 5;
    private float nextAttack;

    public GameObject player;
    public GameObject deathEffect;

    float atkRange = 3;
    public float movingSpeed = 2;

    public bool touched;

    public GameObject weapon;

    public Transform[] waypoints;
    [SerializeField]
    Slider healthBar;
    private Vector3 target;
    [SerializeField]
    int n;
    [SerializeField]
    AudioSource hurtSE;

    // Start is called before the first frame update
    void Start()
    {
        n = 0;
        touched = false;
        mc = FindObjectOfType<MainCharacter>();
        nextAttack = Time.time;
        target = waypoints[n].position;
        healthBar.maxValue = HP;
    }

    // Update is called once per frame
    void Update()
    {

        //player =  FindObjectOfType<MainCharacter>().gameObject;
        healthBar.value = HP;
        if (HP <= 0)
        {
            mc.AddExp();
            Dead();
        }

       transform.position = Vector3.MoveTowards(this.transform.position, target, movingSpeed * Time.deltaTime);
        
        if (transform.position == waypoints[n].position)
        {
            
            n += 1;

            if(n>=waypoints.Length)
            {
                n = 0;
            }
            
            target = waypoints[n].position;
        }


        if ((mc.transform.position.x - this.transform.position.x <= atkRange && mc.transform.position.x - this.transform.position.x >= -atkRange && mc.transform.position.y - this.transform.position.y <= atkRange && mc.transform.position.y - this.transform.position.y >= -atkRange))
        {
            if (Time.time > nextAttack)
            {
                Instantiate(weapon, transform.position, Quaternion.identity);
                nextAttack = Time.time + attackRate;
            }
        }




    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bullet")
        {
            hurtSE.Play();
            HP -= mc.atk * (1/ def);
        }


        if (other.tag == "Player")
        {
            touched = true;
        }
        else
        {
            touched = false;
        }

        if(other.tag == "Explosion")
        {
            HP -= 100;
        }

    }
    
    public void Dead()
    {
        Instantiate(deathEffect,this.transform);
        Destroy(gameObject,0.5f);
    }
   public void Strike()
    {
        mc.GetHurt(atk);

    }

}
