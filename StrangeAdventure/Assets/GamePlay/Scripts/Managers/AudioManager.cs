using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public string ResourceDir = "";

    private AudioSource m_bgSound;
    private AudioSource m_effectSound;
    private bool muteBG;
    private bool muteEffect;

    public bool MuteBG
    {
        get => muteBG;
        set
        {
            muteBG = value;
            m_bgSound.mute = muteBG;
        }
    }

    public bool MuteEffect
    {
        get => muteEffect;
        set
        {
            muteEffect = value;
            m_effectSound.mute = muteEffect;
        }
    }

    public void Init()
    {
        Instance = this;
        m_bgSound = gameObject.AddComponent<AudioSource>();
        m_bgSound.playOnAwake = false;
        m_bgSound.loop = true;
        m_effectSound = gameObject.AddComponent<AudioSource>();
        
        MuteBG = ResourcesManager.Instance.GetGameConfig().MuteBg;
        muteEffect = ResourcesManager.Instance.GetGameConfig().MuteEffect;

        m_bgSound.mute = muteBG;
        m_effectSound.mute = muteEffect;
    }

    //播放音乐
    public void PlayBg(string audioName)
    {
        //当前正在播放的音乐文件
        string oldName;
        if (m_bgSound.clip == null)
            oldName = "";
        else
            oldName = m_bgSound.clip.name;

        if (oldName != audioName)
        {
            //音乐文件路径
            string path;
            if (string.IsNullOrEmpty(ResourceDir))
                path = audioName;
            else
                path = ResourceDir + "/" + audioName;

            //加载音乐
            AudioClip clip = Resources.Load<AudioClip>(path);

            //播放
            if(clip!=null)
            {
                m_bgSound.clip = clip;
                m_bgSound.Play();
            }
        }
    }

    //停止音乐
    public void StopBg()
    {
        m_bgSound.Stop();
        m_bgSound.clip = null;
    }

    //播放音效
    public void PlayEffect(string audioName)
    {
        //路径
        string path;
        if (string.IsNullOrEmpty(ResourceDir))
            path = audioName;
        else
            path = ResourceDir + "/" + audioName;

        //音频
        AudioClip clip = Resources.Load<AudioClip>(path);

        //播放
        m_effectSound.PlayOneShot(clip);
    }

    public void Destroy()
    {
        ResourcesManager.Instance.GetGameConfig().MuteBg = muteBG;
        ResourcesManager.Instance.GetGameConfig().MuteEffect = MuteEffect;
    }
}