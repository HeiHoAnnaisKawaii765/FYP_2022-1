using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsController : MonoBehaviour
{
    [SerializeField]public float speed = 1f;
    public Rigidbody2D theRB;
    
    
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Enemy target;
    MainCharacter mc;
    Vector2 moveDirection;
    BossScript boss;
    public string ownerTag = "Player";

    public int type = 1;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<Enemy>();
        mc = FindObjectOfType<MainCharacter>();
        boss = FindObjectOfType<BossScript>();
        switch(type)
        {
            case 1:
                if(boss != null)
                {
                    moveDirection = (boss.transform.position - transform.position).normalized * moveSpeed;
                    rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
                }
                else
                {
                    moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
                    rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
                }
                
                break;
            case 2:
                moveDirection = (mc.transform.position - transform.position).normalized * moveSpeed;
                rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
                break;
            case 3:
                moveDirection = (mc.transform.position - transform.position).normalized * moveSpeed;
                rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
                break;

        }

        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 10f);

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag != ownerTag)
        {
            Destroy(gameObject);
        }
        
    }



}
