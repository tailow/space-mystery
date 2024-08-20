using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroSceneManager : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        videoPlayer.loopPointReached += EndReached;
    }

    private void EndReached(VideoPlayer player)
    {
        SceneManager.LoadScene("MainScene");
    }
}
