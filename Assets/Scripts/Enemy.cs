using UnityEngine;

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
    float travelTime = 40.0f;
    Vector3 speed = new Vector3(-0.01f, 0, 0);
    float basic;
    float jiggle = 3.0f;
    float jiggleBoundary = 10.0f;
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
    }
}
