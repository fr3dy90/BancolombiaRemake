using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField] private Button _videoButton;
    [SerializeField] private VideoPlayer _video;
    [SerializeField] private string _url;

    private void Awake()
    {
        Debug.Log("VideoController::Awake");
        _videoButton.onClick.AddListener(OnLaunchAvatar);
        _url = System.IO.Path.Combine(Application.streamingAssetsPath, "AvatarIntro.mp4");
        _video.url = _url;
        _video.Prepare();
        
    }

    private void OnLaunchAvatar()
    {
        if (!_video.isPlaying && _video.isPrepared)
        {
            _video.Play();
        }
    }
}
