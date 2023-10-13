using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{//효과음, 배경음, 보이스, 환경음
 //효과음은 동시에 여러 소리가 날 수 있다.

    static SoundManager _uniqueInstance;

    AudioSource _bgmPlayer;
    //2번
    AudioSource _sfxPlayer;
    float _bgmVolume;
    float _sfxVolume;
    bool _bgmMute;
    bool _sfxMute;

    public bool _isMuteBGM
    {
        get { return _bgmMute; }
    }
    public bool _isMuteSFX
    {
        get { return _sfxMute; }
    }
    //1번
    List<AudioSource> _sfxPlayers = new List<AudioSource>();
    public static SoundManager _instance
    {
        get { return _uniqueInstance; }
    }

    private void Awake()
    {
        _uniqueInstance = this;
        DontDestroyOnLoad(gameObject);
        _bgmPlayer = GetComponent<AudioSource>();
        _sfxPlayer = transform.GetChild(0).GetComponent<AudioSource>();

        //임시
        InitializeSet();
        //===
    }

    private void LateUpdate()
    {
        for (int n = 0; n < _sfxPlayers.Count;n++)
        {
            if(!_sfxPlayers[n].isPlaying)
            {
                Destroy(_sfxPlayers[n].gameObject);
                _sfxPlayers.RemoveAt(n);
                break;
            }
        }
    }

    public void InitializeSet(float bv = 1,bool bm = false, float fv = 1, bool fm = false)
    {
        _bgmVolume = bv;
        _bgmMute = bm;
        _sfxVolume = fv;
        _sfxMute = fm;
    }

    public AudioSource PlayBGMSound(DefineHelper.eBGMClipType type, bool isLoop = true)
    {
        GameObject go = new GameObject("BGMPlayer");
        go.transform.parent = transform;
        AudioSource bgmPlayer = go.AddComponent<AudioSource>();
        _bgmPlayer.clip = ResoucePoolManager._instance.GetBgmClipFromType(type);
        _bgmPlayer.volume = _bgmVolume;            
        _bgmPlayer.mute = _bgmMute;
        _bgmPlayer.loop = isLoop;
        _bgmPlayer.Play();

        return _bgmPlayer;
    }

    //1번
    public AudioSource PlaySFXSound(DefineHelper.eSFXClipType type, bool isLoop = false)
    {
        {
            //audio.clip = ResoucePoolManager._instance.GetSFXClipFromType(type);
            //audio.volume = _fxVolume;
            //audio.mute = _fxsMute;
            //audio.loop = isLoop;
            //audio.Play();
        }
        GameObject go = new GameObject("SfxPlayer");
        go.transform.parent = transform;
        AudioSource sfxPlayer = go.AddComponent<AudioSource>();
        sfxPlayer.clip = ResoucePoolManager._instance.GetSFXClipFromType(type);
        sfxPlayer.volume = _sfxVolume;
        sfxPlayer.mute = _sfxMute;
        sfxPlayer.loop = isLoop;
        sfxPlayer.Play();

        _sfxPlayers.Add(sfxPlayer);
        return sfxPlayer;
    }

    public void PlaySFXSoundOneShot(DefineHelper.eSFXClipType type, bool isLoop = false)
    {
        _sfxPlayer.volume = _sfxVolume;
        _sfxPlayer.mute = _sfxMute;
        _sfxPlayer.loop = isLoop;
        _sfxPlayer.PlayOneShot(ResoucePoolManager._instance.GetSFXClipFromType(type));
    }

    public void SetBGMVolume(float volume)
    {
        _bgmPlayer.volume = volume;
        UserInfoManager._Instance.gameData.bgmVolume = volume;
        if (_bgmPlayer.volume <= 0)
        {
            _bgmMute = true;
        }
        else
        {
            _bgmMute = false;
        }
    }

    public void SetSFXVolume(float volume)
    {
        _sfxPlayer.volume = volume;
        UserInfoManager._Instance.gameData.sfxVolume = volume;
        if (volume <= 0)
        {
            _sfxMute = true;
        }
        else
        {
            _sfxMute = false;
        }
    }
}
