using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{

    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _selesctLvl;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnButtonCloseGame();
        }
    }

    public void OnButtonCloseGame()
    {
        Application.Quit();
    }

    public void OnButtonStartGame()
    {
        _mainMenu.SetActive(false);
        _selesctLvl.SetActive(true);
    }

    public void OnButtonSelectLvl(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }

}
