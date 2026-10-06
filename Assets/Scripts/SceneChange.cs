using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void GoToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void GoToTalk()
    {
        SceneManager.LoadScene("Talk");
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("Game");
    }
}