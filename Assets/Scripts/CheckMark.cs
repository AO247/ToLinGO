using UnityEngine;

public class CheckMark : MonoBehaviour
{

    GameObject checkMark;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pressed()
    {
        checkMark.SetActive(!checkMark.active);
    }
}
