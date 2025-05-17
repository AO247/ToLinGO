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

    string[] fireTasks = new string[7];
    string[] waterTasks = new string[5];
    string[] earthTasks = new string[5];
    void Start()
    {
        fireTasks[0] = "Do 5 pushups";
        fireTasks[1] = "Do 10 squats";
        fireTasks[2] = "Do 20 crounches";
        fireTasks[3] = "Travel 1km";
        fireTasks[4] = "Hold plank for 30 s";
        fireTasks[5] = "Climb stairs for 2 min";
        fireTasks[6] = "Perform 10 lunges on each leg";


        waterTasks[0] = "Smile to someone";
        waterTasks[1] = "Call to your friend";
        waterTasks[2] = "Give a compliment to someone";
        waterTasks[3] = "Meet up with friend";
        waterTasks[4] = "Start a small talk with a coworker";


        earthTasks[0] = "Take 5 deep breaths";
        earthTasks[1] = "Read 5 pages";
        earthTasks[2] = "Take a walk in nature";
        earthTasks[3] = "Meditate for 5 min";
        earthTasks[4] = "Watch something";


    }

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
