using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMng : Singleton<SoundMng>
{
    enum AUDIO_TYPE
    {
        BGM,
        SFX
    }

    public enum SFX_CLIP
    {
        SFX1,
    }

    public enum BGM_CLIP
    {
        BGM1
    }

    AudioSource[] m_audio;//오디오 소스를 담는 배열
    [SerializeField]
    AudioClip[] m_sfxClip;
    [SerializeField]
    AudioClip[] m_bgmClip;


    public override void OnAwake()
    {
        AddInstance(this);

        m_audio = new AudioSource[2];

        // BGM
        m_audio[(int)AUDIO_TYPE.BGM] = new AudioSource();

        m_audio[(int)AUDIO_TYPE.BGM].playOnAwake = true;

        m_audio[(int)AUDIO_TYPE.BGM].loop = true;

    }

    public void PlayBGM(BGM_CLIP bgm)
    {
        m_audio[(int)AUDIO_TYPE.BGM].clip = m_bgmClip[(int)bgm];
        m_audio[(int)AUDIO_TYPE.BGM].Play();
    }

    public void PlaySFX(SFX_CLIP sfx)
    {
        m_audio[(int)AUDIO_TYPE.SFX].PlayOneShot(m_sfxClip[(int)sfx]);
        m_audio[(int)AUDIO_TYPE.SFX].Play();
    }
}
