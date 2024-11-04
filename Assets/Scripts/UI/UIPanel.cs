using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPanel : MonoBehaviour
{
    
    [SerializeField] private GameObject _panelWin;
    [SerializeField] private GameObject _panelLose;
    [SerializeField] private  GameObject _soundIcon;
    private float _restartDelay = 0.5f;
    private static bool _soundIsOn = true;

    private void Awake()
    {

        LoadMusicState();

        if (!_soundIsOn)
        {
            _soundIcon.SetActive(false);
            AudioListener.volume = 0f;

        }
        else if (_soundIsOn)
        {
            _soundIcon.SetActive(true);
            AudioListener.volume = 0.6f;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnButtonCloseGame();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnButtonResetScene();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            OnButtonOffSound();
        }
    }

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
            AudioListener.volume = 0.6f;
            _soundIsOn = true;
        }
        else if (_soundIsOn)
        {
            _soundIcon.SetActive(false);
            AudioListener.volume = 0f;
            _soundIsOn = false;
        }

        SaveMusicState(_soundIsOn);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SaveMusicState(bool isMusicOn)
    {
        PlayerPrefs.SetInt("MusicState", isMusicOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    public bool LoadMusicState()
    {
        return PlayerPrefs.GetInt("MusicState", 1) == 1; // 1 по умолчанию, если данных нет
    }

}
