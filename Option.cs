using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    static Option _uniqueInstance;
    public static Option _instance
    {
        get { return _uniqueInstance; }
    }
    [SerializeField] Slider _bgmSlider;
    [SerializeField] Slider _sfxSlider;
    [SerializeField] Image BGMmuteImg;
    [SerializeField] Image SFXmuteImg;
    float prevBGMVolume = 0;
    float prevSFXVolume = 0;

    public float _bgmVolume
    {
        get { return _bgmSlider.value; }
        set { _bgmSlider.value = value; }
    }
    public float _sfxVolume
    {
        get { return _sfxSlider.value; }
        set { _sfxSlider.value = value; }
    }
    private void Awake()
    {
        _uniqueInstance = this;
        InitData();
    }
    private void Update()
    {
        SoundManager._instance.SetBGMVolume(_bgmSlider.value);
        SoundManager._instance.SetSFXVolume(_sfxSlider.value);
        SetMuteImg();
    }

    void InitData()
    {
        _bgmSlider.value = UserInfoManager._Instance.gameData.bgmVolume;
         _bgmVolume = _bgmSlider.value;
        _sfxSlider.value = UserInfoManager._Instance.gameData.sfxVolume;
        _sfxVolume = _sfxSlider.value;
    }

    public void ClickMuteBGMButton()
    {
        if(!SoundManager._instance._isMuteBGM)
        {
            prevBGMVolume = _bgmSlider.value;
            _bgmSlider.value = 0;
            SoundManager._instance.SetBGMVolume(_bgmSlider.value);
        }
        else
        {
            if (prevBGMVolume != 0)
                _bgmSlider.value = prevBGMVolume;
            else
            {
                prevBGMVolume = 0.7f;
                _bgmSlider.value = prevBGMVolume;
            }
            SoundManager._instance.SetBGMVolume(prevBGMVolume);
        }   
    }

    public void ClickMuteSFXButton()
    {
        if (!SoundManager._instance._isMuteSFX)
        {
            prevSFXVolume = _sfxSlider.value;
            _sfxSlider.value = 0;
            SoundManager._instance.SetSFXVolume(_sfxSlider.value);
        }
        else
        {
            if (prevSFXVolume != 0)
                _sfxSlider.value = prevSFXVolume;
            else
            {
                prevSFXVolume = 0.7f;
                _sfxSlider.value = prevSFXVolume;
            }
            SoundManager._instance.SetSFXVolume(prevSFXVolume);
        }
    }

    void SetMuteImg()
    {
        if(SoundManager._instance._isMuteBGM)
        {
            BGMmuteImg.sprite = ResoucePoolManager._instance.GetSoundImg(DefineHelper.eMuteType.Mute);
        }
        else
        {
            BGMmuteImg.sprite = ResoucePoolManager._instance.GetSoundImg(DefineHelper.eMuteType.None);
        }

        if (SoundManager._instance._isMuteSFX)
        {
            SFXmuteImg.sprite = ResoucePoolManager._instance.GetSoundImg(DefineHelper.eMuteType.Mute);
        }
        else
        {
            SFXmuteImg.sprite = ResoucePoolManager._instance.GetSoundImg(DefineHelper.eMuteType.None);
        }
    }

    public void ClickCloseButton()
    {
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
