using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class VideoEnd : MonoBehaviour
{
    public VideoPlayer m_VideoPlayer;
    public GameObject videoObject;
    public GameObject recipes;

    void Awake () 
    {
        m_VideoPlayer = GetComponent<VideoPlayer>();
        m_VideoPlayer.loopPointReached += OnMovieFinished; // loopPointReached is the event for the end of the video
    }

    void OnMovieFinished(VideoPlayer player)
    {
        player.Stop();
        videoObject.SetActive(false);
        recipes.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
