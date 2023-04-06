using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public int HP = 100;
    public int atk = 25;
    public int def = 1;
    MainCharacter mc;
    public float attackRate = 5;
    private float nextAttack,nextTP;

    public GameObject player;
    public GameObject deathEffect;

    float atkRange = 3;
    public float movingSpeed = 2;

    public bool touched;

    public GameObject weapon;

    public Transform[] waypoints;

    private Vector3 target;

    int n;

    [SerializeField]
    float teleportTime;

    // Start is called before the first frame update
    private void Awake()
    {
        InvokeRepeating("RestPosition",teleportTime,teleportTime);
    }
    void Start()
    {
        n = 0;
        touched = false;
        mc = FindObjectOfType<MainCharacter>();
        nextAttack = Time.time;
        nextTP = Time.time;
        target = waypoints[n].position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextTP)
        {
            ResetPosition();
            nextTP = Time.time + teleportTime;
        }        

        if (HP <= 0)
        {
            mc.AddExp();
            
        }

        transform.position = waypoints[n].position;


        if ((mc.transform.position.x - this.transform.position.x <= atkRange && mc.transform.position.x - this.transform.position.x >= -atkRange && mc.transform.position.y - this.transform.position.y <= atkRange && mc.transform.position.y - this.transform.position.y >= -atkRange))
        {
            if (Time.time > nextAttack)
            {
                Instantiate(weapon, transform.position, Quaternion.identity);
                nextAttack = Time.time + attackRate;
            }
        }





    }


    void ResetPosition()
    {
       n = Random.Range(0, waypoints.Length);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            HP -= mc.atk * (1 / def);
        }


        if (other.tag == "Player")
        {
            touched = true;
        }
        else
        {
            touched = false;
        }

        if (other.tag == "Explosion")
        {
            HP -= 100;
        }

    }

  
    public void Strike()
    {
        mc.GetHurt(atk);

    }
}
