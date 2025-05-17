using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FormController : MonoBehaviour
{

    [SerializeField] private Animator panelAnimator;
    [SerializeField] private FormElement[] formElements;
    [SerializeField] private GameObject answersContainer;
    [SerializeField] private TextMeshProUGUI question;
    [SerializeField] private GameObject answerPrefab;
    private bool formStarted = false;

    private int currentQuestion = -1;

    [System.Serializable]
    class FormElement
    {
        public string question;
        public string[] answers;
    }

    private void Update()
    {
        if (!formStarted)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Ended)
                {
                    formStarted = true;
                    panelAnimator.SetBool("startForm", true);
                    LoadNextQuestion();
                }
            }
        }
    }

    public void LoadNextQuestion()
    {
        currentQuestion++;
        if (currentQuestion < formElements.Length)
        {
            question.text = formElements[currentQuestion].question;
            for(int i = 0; i < answersContainer.transform.childCount; i++)
            {
                Destroy(answersContainer.transform.GetChild(i).gameObject);
            }
            foreach(string answer in formElements[currentQuestion].answers)
            {
                GameObject answerClone = Instantiate(answerPrefab);
                answerClone.transform.SetParent(answersContainer.transform, false);
                answerClone.GetComponentInChildren<TextMeshProUGUI>().text = answer;
            }
        }
        else
        {
            LoadGame();
        }
    }

    private void LoadGame()
    {
        SceneManager.LoadScene(0);
    }
}
