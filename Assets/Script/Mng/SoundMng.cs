using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사운드 매니저는 싱글턴입니다
// 타 스크립트에서 참조시 SoundMng.instance.로 사용하시면 됩니다
public class SoundMng : Singleton<SoundMng>
{
    enum AUDIO_TYPE
    {
        BGM,
        SFX
    }


    // 배경음 이름 여기에 추가해주시면 됩니다
    public enum BGM_CLIP
    {
        BGM1
    }

    // 효과음 이름 여기에 추가해주시면 됩니다
    public enum SFX_CLIP
    {
        SFX1,
        SFX2
    }
    
    AudioSource[] m_audio;

    // 효과음 클립을 추가해주시면 됩니다 위의 enum 이름과 순서를 같게 하셔야합니다
    [SerializeField]
    AudioClip[] m_sfxClip;


    // 배경음 클립을 추가해주시면 됩니다 위의 enum 이름과 순서를 같게 하셔야합니다
    [SerializeField]
    AudioClip[] m_bgmClip;


    protected override void OnAwake()
    {
        m_audio = new AudioSource[2];

        m_audio[(int)AUDIO_TYPE.BGM] = gameObject.AddComponent<AudioSource>();

        m_audio[(int)AUDIO_TYPE.BGM].playOnAwake = false;

        m_audio[(int)AUDIO_TYPE.BGM].loop = true;

        m_audio[(int)AUDIO_TYPE.SFX] = gameObject.AddComponent<AudioSource>();

        m_audio[(int)AUDIO_TYPE.SFX].playOnAwake = false;

        m_audio[(int)AUDIO_TYPE.SFX].loop = false;

        // 첫 시작시 배경음 바꾸고 싶다면 여기서 바꿔주면 됩니다
        //PlayBGM(BGM_CLIP.BGM1);

    }

    // 배경음 재생
    // SoundMng.instance.PlayBGM(SoundMng.BGM_CLIP.BGM1);
    public void PlayBGM(BGM_CLIP bgm)
    {
        m_audio[(int)AUDIO_TYPE.BGM].clip = m_bgmClip[(int)bgm];
        m_audio[(int)AUDIO_TYPE.BGM].Play();
    }


    // 효과음 재생
    // SoundMng.instance.PlaySFX(SoundMng.BGM_SFX_CLIPCLIP.SFX1);
    public void PlaySFX(SFX_CLIP sfx)
    {
        m_audio[(int)AUDIO_TYPE.SFX].PlayOneShot(m_sfxClip[(int)sfx]);
        m_audio[(int)AUDIO_TYPE.SFX].Play();
    }

    // 모든 소리 중지
    // SoundMng.instance.Stop();
    public void Stop()
    {
        foreach (AudioSource audio in m_audio)
        {
            audio.Stop();
        }
    }

    // 볼륨 설정시 값의 주의사항 : 볼륨은 보통 사운드 ui에서 0 ~ 100값을 넣기 때문에 50으로 나눠 0 ~ 원본의 2배 사운드까지 정해지도록 만들었습니다
    // 만약, ui가 아니라 따로 볼륨 설정 코드를 사용하신다면 이 점 유의해주시기 바랍니다

    // 전체 볼륨 설정
    // SoundMng.instance.SetVolumeTotal(값);
    public void SetVolumeTotal(float value)
    {
        foreach(AudioSource audio in m_audio)
        {
            audio.volume = value / 50;
        }
    }

    // 배경음 볼륨 설정
    // SoundMng.instance.SetVolumeBGM(값);
    public void SetVolumeBGM(float value)
    {
        m_audio[(int)AUDIO_TYPE.BGM].volume = value / 50;
    }


    // 효과음 볼륨 설정
    // SoundMng.instance.SetVolumeSFX(값);
    public void SetVolumeSFX(float value)
    {
        m_audio[(int)AUDIO_TYPE.SFX].volume = value / 50;
    }



}
