using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{

    [SerializeField] private GameObject _soundIcon;

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
        SceneManager.LoadScene(2);
    }

}
