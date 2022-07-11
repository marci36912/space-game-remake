using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public static float MusicVolume { get; private set; } = 1;
    public static float EffectVolume { get; private set; } = 1;

    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource effect;

    [SerializeField] private EffectStorage[] effects;
    //Dash 0, EnemyShoot 1, Pickup 2, PlayerExplosion 3, PlayerHurt 4, PlayerShoot 5, RobotExplosion 6, Sword 7

    #region setVolumes
    public void SetEffectVolume(float n)
    {
        EffectVolume = n;
        effect.volume = n;
    }
    public void SetMusicVolume(float n)
    {
        MusicVolume = n;
        music.volume = n;
    }
    #endregion

    private void Start()
    {
        if (Instance == null) Instance = this;

        music.volume = MusicVolume;
        effect.volume = EffectVolume;
    }

    public void PlayEffect(SoundIds id)
    {
        effect.clip = getEffectClip(id);
        effect.Play();
    }

    private AudioClip getEffectClip(SoundIds id)
    {
        foreach(var effect in effects)
        {
            if(effect.id == id)
            {
                return effect.Effect;
            }
        }
        return null;
    }
}

public enum SoundIds
{
    Dash,
    EnemyShoot,
    PickUp,
    PlayerExplosion,
    PlayerHurt,
    PlayerShoot,
    RobotExplosion,
    Sword,
    Explosion
}

[System.Serializable]
class EffectStorage
{
public AudioClip Effect;
public SoundIds id;
}
