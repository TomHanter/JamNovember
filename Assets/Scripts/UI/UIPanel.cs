using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panelWin;
    [SerializeField] private GameObject _panelLose;
    [SerializeField] private GameObject _soundIcon;
    private float _restartDelay = 0.5f;
    private bool _soundIsOn = true;

    public void Win()
    {
        _panelWin.SetActive(true);
    }

    public void Lose()
    {
        _panelLose.SetActive(true);
    }

    public void OnButtonResetScene()
    {
        Invoke(nameof(ResetScene), _restartDelay);
    }

    public void OnButtonCloseGame() 
    {
        Application.Quit();
    }

    public void OnButtonOffSound()
    {
        if (!_soundIsOn)
        {
            _soundIcon.SetActive(true);
            AudioListener.volume = 1.0f;
            _soundIsOn = true;
        }
        else if (_soundIsOn)
        {
            _soundIcon.SetActive(false);
            AudioListener.volume = 0f;
            _soundIsOn = false;
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
