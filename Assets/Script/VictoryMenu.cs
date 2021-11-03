using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    public string levelToload;
    public void Quit()
    {
        Application.Quit(); 
    }

    public void Retry()
    {
        SceneManager.LoadScene(levelToload);
        Time.timeScale = 1;
    }
}
