using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public enum Element
    {
        Fire,
        Water,
        Earth,
        Gold,
        None
    }

    public HealthBarUI HealthBarUI;
    Menus menus;
    public Element element;
    GameObject enemy;
    public int health = 4;
    public int maxHealth = 4;
    RectTransform rTransform;
    TaskManager taskManager;
    public GameObject slime;
    public GameObject goblin;
    public GameObject skeleton;
    public GameObject crown;
    public GameObject textBar;
    float travelTime = 40.0f;
    Vector3 speed = new Vector3(-0.01f, 0, 0);
    float basic;
    float jiggle = 3.0f;
    float jiggleBoundary = 10.0f;

    bool hitted = false;
    float hittedTime = 0.0f;
    float changeTime = 0.0f;
    float changeTimeLimit = 0.08f;
    float wholeHitTime = 0.5f;
    float vanishValue = 0.5f;
    bool currentHit = false;
    void Start()
    {
        rTransform = GetComponent<RectTransform>();
        taskManager = GameObject.FindGameObjectWithTag("TaskManager").GetComponent<TaskManager>();
        menus = GameObject.FindGameObjectWithTag("Menus").GetComponent<Menus>();
        travelTime = GameObject.FindGameObjectWithTag("Global").GetComponent<Global>().finishTime;
        float n = 538;
        float speedX = n / travelTime;
        speed = new Vector3(-speedX, 0, 0);
        basic = rTransform.localPosition.y;
        HealthBarUI.SetMaxHealth(maxHealth);
        
    }
    
    // Update is called once per frame
    void Update()
    {
        rTransform.localPosition += speed * Time.deltaTime;
        rTransform.localPosition = new Vector3(rTransform.localPosition.x, basic + Mathf.Sin(Time.time * jiggle) * jiggleBoundary, 0);
        if (transform.localPosition.x < -350)
        {
            Destroy(gameObject);
            menus.ResetStrike();
        }
        if(hitted)
        {
            changeTime += Time.deltaTime;
            hittedTime += Time.deltaTime;
            if(changeTime >= changeTimeLimit)
            {
                changeTime = 0.0f;
                if (currentHit)
                {
                    currentHit = false;
                    Hit(1.0f);
                }
                else
                {
                    currentHit = true;
                    changeTime = 0.0f;
                    Hit(vanishValue);
                }
            }
            if (hittedTime >= wholeHitTime)
            {
                hitted = false;
                hittedTime = 0.0f;
                Hit(1.0f);
                
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        HealthBarUI.SetHealth(health);
        if (health <= 0)
        {
            taskManager.ChangeToGold();
            Destroy(gameObject);
            menus.UpdateStrike();
        }
        var textB = textBar.GetComponent<Text>();
        if (textB != null)
        {
            textBar.GetComponent<Text>().text = health.ToString() + "/" + maxHealth.ToString();
        }

        hitted = true;
        //Hit(vanishValue);
        //currentHit = true;

    }

    void Hit(float a)
    {
        var slimeImage = slime.GetComponent<Image>();
        var goblinImage = goblin.GetComponent<Image>();
        var skeletonImage = skeleton.GetComponent<Image>();

        var slimeColor = slimeImage.color;
        slimeColor.a = a;
        slimeImage.color = slimeColor;

        var goblinColor = goblinImage.color;
        goblinColor.a = a;
        goblinImage.color = goblinColor;

        var skeletonColor = skeletonImage.color;
        skeletonColor.a = a;
        skeletonImage.color = skeletonColor;
    }
}
