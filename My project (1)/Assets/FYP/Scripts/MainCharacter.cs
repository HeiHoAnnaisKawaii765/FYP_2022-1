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

    [SerializeField]
    int woundedhealth,addExp;

    int maxExp;
    bool wall;
    [SerializeField]
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

    [SerializeField]
    Transform[] waypoints;
    [SerializeField]
    Transform FinalPos;
    int n = 0;

    private Vector3 wayPt;

    Constrain constrain;

    [SerializeField]
    AudioSource hurtSE;
    void Start()
    {
        nextFire = Time.time;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = lookForward;
        maxExp = 10000;
        exp = PlayerPrefs.GetInt("EXP");
        lv = PlayerPrefs.GetInt("LV");

        wayPt = waypoints[n].position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, wayPt, moveSpeed * Time.deltaTime);


        if (FindObjectOfType<Enemy>() != null || FindObjectOfType<BossScript>() != null)
        {
            if(FindObjectOfType<Enemy>() != null)
            {
                target = FindObjectOfType<Enemy>().gameObject;
            }
            else
            {
                target = FindObjectOfType<BossScript>().gameObject;
            }
            
            
            if (transform.position == waypoints[n].position)
            {
                n = Random.Range(0, waypoints.Length);
                
                wayPt = waypoints[n].position;
            }
            if (Vector3.Distance(target.transform.position, this.transform.position) <= attackRange)
            {
                CheckIfTimeToFire();
            }
        }
        else
        {
            wayPt = FinalPos.position;
            PlayerPrefs.SetInt("EXP", exp);
            PlayerPrefs.SetInt("LV", lv);
            
        }


        if (hp <= 0)
        {

            Destroy(gameObject);
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
        exp += addExp;
    }

    public void GetHurt(int atkvalue)
    {
        

            hp -= atkvalue * 1/(lv+2);
            

            
        
        
        
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(4f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Axe"||other.tag == "Arrow")
        {
            hurtSE.Play();
            hp -= woundedhealth;

        }

        if(other.tag == "Wall")
        {
            gameObject.transform.position = new Vector3(24.61f,-1.67f,0f);
        }
    }
}
