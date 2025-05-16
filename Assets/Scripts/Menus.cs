using UnityEngine;
using TMPro;

public class Menus : MonoBehaviour
{
    public static Menus instance { get; private set; }
    public float money;

   void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Zachowuje obiekt między scenami
        }
        else
        {
            Destroy(gameObject); // Usuwa duplikaty
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
