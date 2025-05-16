using TMPro;
using Unity.Android.Gradle;
using UnityEngine;
using UnityEngine.UI;

public class CheckMark : MonoBehaviour
{

    GameObject checkMark;
    public Enemy.Element element;
    public Enemy enemy;
    public TextMeshProUGUI taskName;
    public GameObject cover;
    bool damaged = false;
    public Toggle toggle;
    TaskManager taskManager;
    void Start()
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
            enemy.TakeDamage(element);
            cover.SetActive(true);
            taskName.fontStyle = FontStyles.Strikethrough;
            taskManager.SetTaskLast(gameObject);
        }
        else if(!toggle.isOn && damaged)
        {
            damaged = false;
        }
    }
    public void SetTask(Enemy.Element el, string name)
    {
        element = el;
        taskName.SetText(name);
        Debug.Log("Task: " + name);
        Debug.Log("Element: " + element);
    }    
}
