using Unity.VisualScripting;
using UnityEngine;

public class Global : MonoBehaviour
{
    public GameObject top;

    public GameObject enemyPrefab;
    public TaskManager taskManager;


    void Start()
    {
        RandomEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameObject.FindGameObjectWithTag("Enemy"))
        {
            taskManager.ClearTasks();
            RandomEnemy();
        }

    }

    void RandomEnemy()
    {
        int random = Random.Range(0, 3);
        int randomElement = Random.Range(0, 3);

        GameObject newEnemy = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
        newEnemy.transform.SetParent(top.transform);
        newEnemy.transform.localPosition = new Vector3(538, -512, 0);
        Enemy enemy = newEnemy.GetComponent<Enemy>();

        if (random == 0)
        {
            enemy.skeleton.SetActive(true);
        }
        else if (random == 1)
        {
            enemy.goblin.SetActive(true);
        }
        else if (random == 2)
        {
            enemy.slime.SetActive(true);
        }

        if (randomElement == 0)
        {
            enemy.element = Enemy.Element.Fire;
        }
        else if (randomElement == 1)
        {
            enemy.element = Enemy.Element.Water;
        }
        else if (randomElement == 2)
        {
            enemy.element = Enemy.Element.Earth;
        }

        Debug.Log(random);
        Debug.Log(randomElement);

        taskManager.GenerateTasks();
    }

}
