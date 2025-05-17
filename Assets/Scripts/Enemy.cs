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

    public Element element;
    GameObject enemy;
    public int health = 4;
    RectTransform rTransform;
    TaskManager taskManager;
    Vector3 speed = new Vector3(-0.01f, 0, 0);
    void Start()
    {
        rTransform = GetComponent<RectTransform>();
        taskManager = GameObject.FindGameObjectWithTag("TaskManager").GetComponent<TaskManager>();
    }
    
    // Update is called once per frame
    void Update()
    {
        rTransform.position += speed;
        if(transform.position.x < -350)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            taskManager.ChangeToGold();
            Destroy(gameObject);
        }
    }
}
