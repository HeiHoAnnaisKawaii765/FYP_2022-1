using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class MainCharacter : MonoBehaviour
{
    
    // Start is called before the first frame update
    //states
    public int hp = 100;
    public int exp = 0;
    public int lv = 1;
    public int atk = 25;
    
    int maxExp;
    bool wall;
    float moveSpeed = 2;

    public string SceneName;

    //attack
    public GameObject projectile;
    public float fireRate;
    private float nextFire;
    public float attackRange = 6f;

    //UI
    public Text pLv, pExp, pHp;
    public TMP_Text lVText;

    //move
    public GameObject target;

    //character
    public Sprite lookForward, lookBackward, lookLeft, lookRight;
    public SpriteRenderer spriteRenderer;

    Enemy enemy;
    public Slider hpSlider, expSlider;
    

    void Start()
    {
        nextFire = Time.time;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = lookForward;
        maxExp = 10000;
        exp = PlayerPrefs.GetInt("EXP");
        lv = PlayerPrefs.GetInt("LV");

    }

    // Update is called once per frame
    void Update()
    {
        target = FindObjectOfType<Enemy>().gameObject;
        

        if (FindObjectOfType<Enemy>() != null)
        {
            if (hp > 50)
            {

                if (target.transform.position.x > this.transform.position.x + attackRange)
                {
                    transform.position += transform.right * Time.deltaTime * moveSpeed;
                    spriteRenderer.sprite = lookRight;
                }
                else if (target.transform.position.x < this.transform.position.x - attackRange)
                {
                    transform.position += transform.right * Time.deltaTime * -moveSpeed;
                    spriteRenderer.sprite = lookLeft;
                }
                else
                {
                    transform.position += transform.right * 0;
                }



                if (target.transform.position.y > this.transform.position.y + attackRange)
                {
                    transform.position += transform.up * Time.deltaTime * moveSpeed;
                    spriteRenderer.sprite = lookForward;

                }
                else if (target.transform.position.y < this.transform.position.y - attackRange)
                {
                    transform.position += transform.up * Time.deltaTime * -moveSpeed;
                    spriteRenderer.sprite = lookBackward;
                }
                else
                {
                    transform.position += transform.up * 0;
                }
            }
            else
            {
                if (target.transform.position.x < this.transform.position.x + attackRange)
                {
                    transform.position += transform.right * Time.deltaTime * -moveSpeed;
                    spriteRenderer.sprite = lookLeft;
                }
                else if (target.transform.position.x > this.transform.position.x - attackRange)
                {
                    transform.position += transform.right * Time.deltaTime * moveSpeed;
                    spriteRenderer.sprite = lookRight;
                }




                if (target.transform.position.y < this.transform.position.y + attackRange)
                {
                    transform.position += transform.up * Time.deltaTime * -moveSpeed;
                    spriteRenderer.sprite = lookBackward;

                }
                else if (target.transform.position.y > this.transform.position.y - attackRange)
                {
                    transform.position += transform.up * Time.deltaTime * moveSpeed;
                    spriteRenderer.sprite = lookForward;
                }

            }
        }
        else
        {
            PlayerPrefs.SetInt("EXP", exp);
            PlayerPrefs.SetInt("LV", lv);
            
        }


        if (hp <= 0)
        {
            SceneManager.LoadScene(SceneName);
            //Destroy(gameObject);

        }
        if ((target.transform.position.x - this.transform.position.x <= attackRange && target.transform.position.x - this.transform.position.x >= -attackRange && target.transform.position.y - this.transform.position.y <= attackRange && target.transform.position.y - this.transform.position.y >= -attackRange))
        {
            CheckIfTimeToFire();
        }


        pHp.text = "HP: " + hp.ToString();
        pExp.text = "Exp: " + exp.ToString();
        lVText.text = lv.ToString();


        if (exp >= 10000)
        {
            int extra = exp - 10000;
            exp = 0 + extra;
            lv += 1;
            maxExp = maxExp + 25;
            atk = atk + lv;
        }

        expSlider.value = exp;
        hpSlider.value = hp;
        expSlider.maxValue = maxExp;

    }
    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }

    }

    
    public void AddExp()
    {
        exp += 20;
    }

    public void GetHurt(int atkvalue)
    {
        

            hp -= atkvalue;
            

            
        
        
        
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(4f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Axe")
        {
            hp -= FindObjectOfType<Enemy>().atk * (1 / lv);

        }
        if(other.tag == "Wall")
        {
            gameObject.transform.position = new Vector3(24.61f,-1.67f,0f);
        }
    }
}
