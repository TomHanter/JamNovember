using UnityEngine;
using UnityEngine.Video;

public class PlayVideoIntro : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer; // Ссылка на ваш Video Player

    void Start()
    {
        // Подписываемся на событие окончания видео
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // Загружаем следующую сцену после окончания видео
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
