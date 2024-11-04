using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoIntro : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer; // Ссылка на ваш Video Player
    
    void Start()
    {
        // Подписываемся на событие окончания видео
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void Update()
    {
        // Проверяем, была ли нажата любая клавиша
        if (Input.anyKeyDown)
        {
            SkipVideo();
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // Загружаем следующую сцену после окончания видео
        LoadNextScene();
    }

    void SkipVideo()
    {
        // Останавливаем видео
        videoPlayer.Pause();

        // Загружаем следующую сцену
        LoadNextScene();
    }

    void LoadNextScene()
    {
        // Загружаем следующую сцену
        SceneManager.LoadScene(1);
    }
}
