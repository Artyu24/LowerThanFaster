using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    public string levelToload;
    public string levelToload2;
    public void Quit()
    {
        Application.Quit(); 
    }

    public void Retry()
    {
        SceneManager.LoadScene(levelToload);
        Time.timeScale = 1;
    }
    public void Menu()
    {
        SceneManager.LoadScene(levelToload2);
    }
}
