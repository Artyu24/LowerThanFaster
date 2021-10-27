using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;
    public string levelToload;
    public GameObject SettingsWindow;
    public int Hardeur;

    public void StartGame()
    {
        SceneManager.LoadScene(levelToload);
    }
    public void Settings()
    {
        SettingsWindow.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Difficulty(int Dif)
    {
        Hardeur = Dif;
    }
}
