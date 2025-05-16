using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    List<GameObject> tasks = new List<GameObject>();
    public GameObject content;
    public GameObject task;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddTask(string element = "Fire", string taskName = "Filip Do Wiêzienia")
    {
        Enemy.Element el;
        if (element == "Fire")
        {
            el = Enemy.Element.Fire;
        }
        else if (element == "Water")
        {
            el = Enemy.Element.Water;
        }
        else
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
    public void AddTask()
    {
        string element = "Fire";
        string taskName = "Filip Do Wiêzienia";
        Enemy.Element el;
        if (element == "Fire")
        {
            el = Enemy.Element.Fire;
        }
        else if (element == "Water")
        {
            el = Enemy.Element.Water;
        }
        else
        {
            el = Enemy.Element.Earth;
        }

        GameObject newTask = Instantiate(task, content.transform);
        newTask.transform.SetParent(content.transform);
        newTask.transform.SetAsFirstSibling();
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

    public void SetTaskLast(GameObject task)
    {
        task.transform.SetAsLastSibling();
        //RectTransform rTransform = content.GetComponent<RectTransform>();
        //RectTransform rectTransform = task.GetComponent<RectTransform>();
        //Vector2 newSizeDelta = rTransform.sizeDelta;
        //newSizeDelta.y -= rectTransform.rect.height;
        //rTransform.sizeDelta = newSizeDelta;
    }


}
