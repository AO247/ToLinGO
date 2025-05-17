using TMPro;
using Unity.Android.Gradle;
using UnityEngine;
using UnityEngine.UI;

public class CheckMark : MonoBehaviour
{

    GameObject checkMark;
    Menus menus;
    public Enemy.Element element;
    public Enemy enemy;
    public TextMeshProUGUI taskName;
    public GameObject cover;
    bool damaged = false;
    public Toggle toggle;
    public bool isChecked = false;
    public bool isElemental = true;
    public TextMeshProUGUI numberText;
    public int number;
    TaskManager taskManager;
    public int highDmg = 4, dmg = 2, lowDmg = 1;
    public GameObject fire;
    public GameObject water;
    public GameObject earth;
    public GameObject gold;
    public GameObject none;
    void Start()
    {
        menus = GameObject.FindGameObjectWithTag("Menus").GetComponent<Menus>();
    }
    private void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        taskManager = GameObject.FindGameObjectWithTag("TaskManager").GetComponent<TaskManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle.isOn && !damaged)
        {
            damaged = true;
            cover.SetActive(true);
            taskName.fontStyle = FontStyles.Strikethrough;
            taskManager.SetTaskLast(gameObject);
            isChecked = true;
            toggle.interactable = false;
            enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
            if (enemy && number < 10) 
            {
                enemy.TakeDamage(number);
            }
            else
            {
                menus.UpdateMoney(number);
            }
        }

    }
    public void SetTask(Enemy.Element el, string name)
    {
        element = el;
        if (el == Enemy.Element.Fire)
        {
            fire.SetActive(true);
        }
        else if (el == Enemy.Element.Water)
        {
            water.SetActive(true);
        }
        else if (el == Enemy.Element.Earth)
        {
            earth.SetActive(true);
        }
        else if (el == Enemy.Element.None)
        {
            none.SetActive(true);
        }
        else if (el == Enemy.Element.Gold)
        {
            gold.SetActive(true);
        }

        taskName.SetText(name);

        if (el != Enemy.Element.None && el != Enemy.Element.Gold)
        {
            if (enemy.element == Enemy.Element.Fire)
            {
                if (el == Enemy.Element.Water)
                {
                    number = highDmg;
                }
                else if (el == Enemy.Element.Earth)
                {
                    number = lowDmg;
                }
                else if (el == Enemy.Element.Fire)
                {
                    number = dmg;
                }
            }
            else if (enemy.element == Enemy.Element.Water)
            {
                if (el == Enemy.Element.Earth)
                {
                    number = highDmg;
                }
                else if (el == Enemy.Element.Fire)
                {
                    number = lowDmg;
                }
                else if (el == Enemy.Element.Water)
                {
                    number = dmg;
                }
            }
            else if (enemy.element == Enemy.Element.Earth)
            {
                if (el == Enemy.Element.Fire)
                {
                    number = highDmg;
                }
                else if (el == Enemy.Element.Water)
                {
                    number = lowDmg;

                }
                else if (el == Enemy.Element.Earth)
                {
                    number = dmg;
                }
            }
        }
        else
        {
            number = 100;
        }
        numberText.SetText(number.ToString());
    }

}
