using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [Header("Music Tracks")]
    [SerializeField] List<AudioSource> _sources;

    public void PlayAudioClip(AudioSource source) {
        source.Play();
    }

    public void PlayMainMenuMusic() {
        StopAllMusicSources();
        PlayAudioClip(_sources[0]);
    }

    public void PlayGameMusic() {
        StopAllMusicSources();
        PlayAudioClip(_sources[1]);
    }

    public void PlayGameOverMusic() {
        StopAllMusicSources();
        PlayAudioClip(_sources[2]);
    }

    private void StopAllMusicSources() {
        foreach (AudioSource source in _sources) {
            source.Stop();
        }
    }
}
