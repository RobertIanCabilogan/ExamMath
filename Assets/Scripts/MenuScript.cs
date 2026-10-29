using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{

    public GameObject start;
    public GameObject levelSelect;
    public GameObject about;
    public GameObject Buttons;
    public GameObject[] returnBtn;
    public GameObject quit;
    public GameObject[] LevelButtons;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShowStart();
    }

    public void ShowStart()
    {
        Buttons.SetActive(true);
        levelSelect.SetActive(false);
        about.SetActive(false);
    }

    public void ShowLevelSelect()
    {
        Buttons.SetActive(false);
        levelSelect.SetActive(true);
        about.SetActive(false);
    }

    public void ShowAbout()
    {
        Buttons.SetActive(false);
        levelSelect.SetActive(false);
        about.SetActive(true);
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Return()
    {
        ShowStart();
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Level_1()
    {
        LoadLevel("Level 1");
    }

    public void Level_2()
    {
        LoadLevel("Level 2");
    }

    public void Level_3()
    {
        LoadLevel("Level 3");
    }
    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
}
