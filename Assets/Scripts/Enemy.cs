using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum Element
    {
        Fire,
        Water,
        Earth,
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
    Vector3 speed = new Vector3(-0.01f, 0, 0);
    void Start()
    {
        rTransform = GetComponent<RectTransform>();
        taskManager = GameObject.FindGameObjectWithTag("TaskManager").GetComponent<TaskManager>();
        menus = GameObject.FindGameObjectWithTag("Menus").GetComponent<Menus>();
        HealthBarUI.SetMaxHealth(maxHealth);
    }
    
    // Update is called once per frame
    void Update()
    {
        rTransform.position += speed;
        if(transform.localPosition.x < -350)
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
