using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource bgAudioSource;
    public AudioSource sfxAudioSource;
    public AudioClip bgMusic;

    private void OnEnable()
    {
        EventManager.GameStarted += OnGameStarted;
        EventManager.GameEnded += OnGameOver;
        EventManager.PlayBGMusic += PlayBGMusic;
        EventManager.PlaySFX += PlaySFX;
    }

    private void OnDisable()
    {
        EventManager.GameStarted -= OnGameStarted;
        EventManager.GameEnded -= OnGameOver;
        EventManager.PlayBGMusic -= PlayBGMusic;
        EventManager.PlaySFX -= PlaySFX;
    }

    void OnGameStarted() { EventManager.PlayBGMusic?.Invoke(bgMusic); }
    void OnGameOver() { bgAudioSource.Stop(); }
    void PlayBGMusic(AudioClip bgClip) { bgAudioSource.clip = bgClip; bgAudioSource.Play(); }
    void PlaySFX(AudioClip sfxClip) { sfxAudioSource.clip = sfxClip; sfxAudioSource.Play(); }
}
