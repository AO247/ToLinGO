using UnityEngine;

public class AnswerButton : MonoBehaviour
{
    public FormController formController;

    private void Start()
    {
        formController = GameObject.Find("FormController").GetComponent<FormController>();
    }

    public void SelectAnswer()
    {
        formController.LoadNextQuestion();
    }
}
