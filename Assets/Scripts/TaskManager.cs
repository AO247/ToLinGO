using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    List<GameObject> tasks = new List<GameObject>();
    public GameObject content;
    public GameObject task;
    public TextMeshProUGUI inputText;
    int userTaskCount = 0;

    string[] fireTasks = new string[3];
    string[] waterTasks = new string[3];
    string[] earthTasks = new string[3];
    void Start()
    {
        fireTasks[0] = "Zrób 5 pompek";
        fireTasks[1] = "Zrób 10 przysiadów";
        fireTasks[2] = "Zrób 20 brzuszków";

        waterTasks[0] = "Uœmiechnij siê do kogoœ";
        waterTasks[1] = "Pog³aszcz Filipa";
        waterTasks[2] = "Zadzwoñ do znajomego";

        earthTasks[0] = "Zrób 5 oddechów";
        earthTasks[1] = "Ogl¹daj krajobraz za oknem przez min";
        earthTasks[2] = "Przeczytaj 10 stron z ksi¹¿ki";
    }

    // Update is called once per frame
    void Update()
    {
        TasksUpdate();
    }

    public void AddTask(string element = "Fire", string taskName = "Filip Do Wiêzienia")
    {
        Enemy.Element el = Enemy.Element.None;
        if (element == "Fire")
        {
            el = Enemy.Element.Fire;
        }
        else if (element == "Water")
        {
            el = Enemy.Element.Water;
        }
        else if (element == "Earth")
        {
            el = Enemy.Element.Earth;
        }
        Debug.Log("Adding task: " + taskName);
        GameObject newTask = Instantiate(task, content.transform);
        newTask.transform.SetParent(content.transform);
        newTask.transform.localScale = new Vector3(1, 1, 1);
        newTask.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        newTask.GetComponent<CheckMark>().SetTask(el, taskName);
        tasks.Add(newTask);
        RectTransform rTransform = content.GetComponent<RectTransform>();
        RectTransform rectTransform = newTask.GetComponent<RectTransform>();
        Vector2 newSizeDelta = rTransform.sizeDelta;
        newSizeDelta.y += rectTransform.rect.height;
        rTransform.sizeDelta = newSizeDelta;
    }
    public void AddUserTask()
    {
        string taskName = inputText.text;
        Enemy.Element el = Enemy.Element.None;
        if (userTaskCount > 2)
        {
            el = Enemy.Element.None;
        }
        else
        {
            el = Enemy.Element.Gold;
        }
        userTaskCount++;
        GameObject newTask = Instantiate(task, content.transform);
        newTask.transform.SetParent(content.transform);
        newTask.transform.SetAsFirstSibling();
        newTask.transform.localScale = new Vector3(1, 1, 1);
        newTask.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        newTask.GetComponent<CheckMark>().SetTask(el, taskName);
        newTask.GetComponent<CheckMark>().isElemental = false;
        tasks.Add(newTask);
        RectTransform rTransform = content.GetComponent<RectTransform>();
        RectTransform rectTransform = newTask.GetComponent<RectTransform>();

        Vector2 newSizeDelta = rTransform.sizeDelta;
        newSizeDelta.y += rectTransform.rect.height;
        rTransform.sizeDelta = newSizeDelta;
    }

    public void SetTaskLast(GameObject task)
    {
        task.transform.SetAsLastSibling();
    }

    public void TasksUpdate()
    {
        bool flag = false;
        foreach (GameObject task in tasks)
        {
            if (!task.GetComponent<CheckMark>().isChecked)
            {
                if (!task.GetComponent<CheckMark>().isElemental)
                {
                    task.transform.SetAsFirstSibling();
                    flag = true;
                }
            }
        }
        foreach (GameObject task in tasks)
        {
            if (!task.GetComponent<CheckMark>().isChecked)
            {
                if (task.GetComponent<CheckMark>().isElemental)
                {
                    task.transform.SetAsFirstSibling();
                    flag = true;
                }
            }
        }
        foreach (GameObject task in tasks)
        {
            if (task.GetComponent<CheckMark>().isChecked)
            {
                if (task.GetComponent<CheckMark>().isElemental)
                {
                    task.transform.SetAsLastSibling();
                }
            }
        }
        foreach (GameObject task in tasks)
        {
            if (task.GetComponent<CheckMark>().isChecked)
            {
                if (!task.GetComponent<CheckMark>().isElemental)
                {
                    task.transform.SetAsLastSibling();
                }
            }
        }
        if (!flag)
        {
            GameObject.FindGameObjectWithTag("Global").GetComponent<Global>().dayTime = GameObject.FindGameObjectWithTag("Global").GetComponent<Global>().finishTime;
        }
    }

    public void ClearTasks()
    {
        foreach (GameObject task in tasks)
        {
            Destroy(task);
        }
        tasks.Clear();
        userTaskCount = 0;
        RectTransform rTransform = content.GetComponent<RectTransform>();
        Vector2 newSizeDelta = rTransform.sizeDelta;
        newSizeDelta.y = 0;
        rTransform.sizeDelta = newSizeDelta;
    }

    public void ChangeToGold()
    {
        foreach (GameObject task in tasks)
        {
            if (!task.GetComponent<CheckMark>().isChecked)
            {
                if (task.GetComponent<CheckMark>().isElemental)
                {
                    task.GetComponent<CheckMark>().number = 1000;
                    task.GetComponent<CheckMark>().numberText.text = "1k";
                    task.GetComponent<CheckMark>().fire.SetActive(false);
                    task.GetComponent<CheckMark>().water.SetActive(false);
                    task.GetComponent<CheckMark>().earth.SetActive(false);
                    task.GetComponent<CheckMark>().none.SetActive(false);
                    task.GetComponent<CheckMark>().gold.SetActive(true);
                }
            }
        }
    }

    public void GenerateTasks()
    {
        int rand = Random.Range(0, fireTasks.Length);
        AddTask("Fire", fireTasks[rand]);
        int pRand = rand;
        while (rand == pRand)
        {
            rand = Random.Range(0, fireTasks.Length);
        }
        AddTask("Fire", fireTasks[rand]);

        rand = Random.Range(0, waterTasks.Length);
        AddTask("Water", waterTasks[rand]);
        pRand = rand;
        while (rand == pRand)
        {
            rand = Random.Range(0, waterTasks.Length);
        }
        AddTask("Water", waterTasks[rand]);


        rand = Random.Range(0, earthTasks.Length);
        AddTask("Earth", earthTasks[rand]);
        pRand = rand;
        while (rand == pRand)
        {
            rand = Random.Range(0, earthTasks.Length);
        }
        AddTask("Earth", earthTasks[rand]);

    }


}
