using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public GameObject startText;
    public GameObject pressSpaceText;

    void Start()
    {
        startText.SetActive(false);
        pressSpaceText.SetActive(false);

        Invoke("ShowStart", 2.5f);
    }

    void ShowStart()
    {
        startText.SetActive(true);
        pressSpaceText.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Game");
        }
    }
}