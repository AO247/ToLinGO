using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum Element
    {
        Fire,
        Water,
        Earth
    }

    public Element element;
    GameObject enemy;
    public int health = 4, highDmg = 4, dmg = 2, lowDmg = 1;
    RectTransform rTransform;
    Vector3 speed = new Vector3(-0.01f, 0, 0);
    void Start()
    {
        rTransform = GetComponent<RectTransform>();
    }
    
    // Update is called once per frame
    void Update()
    {
        rTransform.position += speed;
        if(transform.position.x < -350)
        {
            //Destroy(gameObject);
        }
    }

    public void TakeDamage(Element el)
    {
        Debug.Log("Element: " + el);
        if (element == Element.Fire)
        {
            if(el == Element.Water)
            {
                health -= highDmg;
                Debug.Log("High Damage: " + highDmg);
            }
            else if (el == Element.Earth)
            {
                health -= lowDmg;
                Debug.Log("Low Damage: " + lowDmg);
            }
            else if (el == Element.Fire)
            {
                health -= dmg;
                Debug.Log("Damage: " + dmg);
            }
        }
        else if (element == Element.Water)
        {
            if (el == Element.Earth)
            {
                health -= highDmg;
                Debug.Log("High Damage: " + highDmg);
            }
            else if (el == Element.Fire)
            {
                health -= lowDmg;
                Debug.Log("Low Damage: " + lowDmg);
            }
            else if (el == Element.Water)
            {
                health -= dmg;
                Debug.Log("Damage: " + dmg);
            }
        }
        else if (element == Element.Earth)
        {
            if (el == Element.Fire)
            {
                health -= highDmg;
                Debug.Log("High Damage: " + highDmg);
            }
            else if (el == Element.Water)
            {
                health -= lowDmg;
                Debug.Log("Low Damage: " + lowDmg);

            }
            else if (el == Element.Earth)
            {
                health -= dmg;
                Debug.Log("Damage: " + dmg);
            }
        }
        if (health <= 0)
        {
            Debug.Log("Enemy Destroyed");
            //Destroy(gameObject);
        }
    }
}
