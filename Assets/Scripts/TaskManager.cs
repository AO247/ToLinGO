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
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TasksUpdate();
    }

    public void AddTask(string element = "None", string taskName = "Filip Do Wiêzienia")
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
                if(!task.GetComponent<CheckMark>().isElemental)
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
        if(!flag)
        {
            ClearTasks();
        }
    }

    public void ClearTasks()
    {
        foreach (GameObject task in tasks)
        {
            Destroy(task);
        }
        tasks.Clear();
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
                }
                else
                {
                    task.GetComponent<CheckMark>().number = 100;
                    task.GetComponent<CheckMark>().numberText.text = "100";
                }
                task.GetComponent<CheckMark>().fire.SetActive(false);
                task.GetComponent<CheckMark>().water.SetActive(false);
                task.GetComponent<CheckMark>().earth.SetActive(false);
                task.GetComponent<CheckMark>().none.SetActive(true);
            }
        }
    }

    public void GenerateTasks()
    {

        AddTask("Fire", "Zrób 5 pompek");
        AddTask("Fire", "Zrób 10 przysiadów");
        AddTask("Water", "Uœmiechnij siê do kogoœ");
        AddTask("Water", "Pog³aszcz Filipa");
        AddTask("Earth", "Zrób 5 oddechów");
        AddTask("Earth", "Ogl¹daj krajobraz za oknem przez min");
    }

}
