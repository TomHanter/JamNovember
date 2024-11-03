using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panelWin;
    [SerializeField] private GameObject _panelLose;
    private float _restartDelay = 0.5f;

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

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
