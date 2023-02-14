using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    // Start is called before the first frame update
    void Start()
    {
        touched = false;
        mc = FindObjectOfType<MainCharacter>();
        nextAttack = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        player =  FindObjectOfType<MainCharacter>().gameObject;

        if (HP <= 0)
        {
            mc.AddExp();
            Dead();
        }


        if (player.transform.position.x > this.transform.position.x + atkRange)
        {
            transform.position += transform.right * Time.deltaTime * movingSpeed;
            
        }
        else if (player.transform.position.x < this.transform.position.x - atkRange)
        {
            transform.position += transform.right * Time.deltaTime * -movingSpeed;
            
        }
        else
        {
            transform.position += transform.right * 0;
        }



        if (player.transform.position.y > this.transform.position.y + atkRange)
        {
            transform.position += transform.up * Time.deltaTime * movingSpeed;
            

        }
        else if (player.transform.position.y < this.transform.position.y - atkRange)
        {
            transform.position += transform.up * Time.deltaTime * -movingSpeed;
            
        }
        else
        {
            transform.position += transform.up * 0;
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
