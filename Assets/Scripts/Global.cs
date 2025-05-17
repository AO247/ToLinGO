using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour
{
    public GameObject top;

    public GameObject enemyPrefab;
    public TaskManager taskManager;

    float pRandom = 0;
    float pRandomElement = 0;
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
        int random = 0, randomElement = 0;
        do
        {
            random = Random.Range(0, 3);
        } while (random == pRandom);

        do
        {
            randomElement = Random.Range(0, 3);
        } while (randomElement == pRandomElement);

        pRandom = random;
        pRandomElement = randomElement;
        GameObject newEnemy = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
        newEnemy.transform.SetParent(top.transform);
        newEnemy.transform.localPosition = new Vector3(538, -512, 0);
        Enemy enemy = newEnemy.GetComponent<Enemy>();

        GameObject activeEnemy = null;

        if (random == 0)
        {
            enemy.skeleton.SetActive(true);
            activeEnemy = enemy.skeleton;
        }
        else if (random == 1)
        {
            enemy.goblin.SetActive(true);
            activeEnemy = enemy.goblin;
        }
        else if (random == 2)
        {
            enemy.slime.SetActive(true);
            activeEnemy = enemy.slime;
        }

        Color elementColor = Color.white;

        if (randomElement == 0)
        {
            enemy.element = Enemy.Element.Fire;
            elementColor = Color.red;
        }
        else if (randomElement == 1)
        {
            enemy.element = Enemy.Element.Water;
            elementColor = Color.blue;
        }
        else if (randomElement == 2)
        {
            enemy.element = Enemy.Element.Earth;
            elementColor = Color.green;
        }

        SetEnemyColor(activeEnemy, elementColor);

        Debug.Log(random);
        Debug.Log(randomElement);

        taskManager.GenerateTasks();
    }


    void SetEnemyColor(GameObject enemyObject, Color color)
    {
        if (enemyObject == null) return;

        var image = enemyObject.GetComponent<Image>();
        if (image != null)
        {
            image.color = color;
        }
        else
        {
            Debug.LogWarning("Brak komponentu Image na obiekcie: " + enemyObject.name);
        }
    }
}
