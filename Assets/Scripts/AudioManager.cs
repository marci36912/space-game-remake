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

    [SerializeField] private AudioClip[] effects;
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

    #region effects
    public void PlayDash()
    {
        effect.clip = effects[((int)SoundIds.Dash)];
        effect.Play();
    }
    public void PlayEnemyShoot()
    {
        effect.clip = effects[((int)SoundIds.EnemyShoot)];
        effect.Play();
    }
    public void PlayPickUp()
    {
        effect.clip = effects[((int)SoundIds.PickUp)];
        effect.Play();
    }
    public void PlayPlayerExplosion()
    {
        effect.clip = effects[((int)SoundIds.PlayerExplosion)];
        effect.Play();
    }
    public void PlayPlayerHurt()
    {
        effect.clip = effects[((int)SoundIds.PlayerHurt)];
        effect.Play();
    }
    public void PlayPlayerShoot()
    {
        effect.clip = effects[((int)SoundIds.PlayerShoot)];
        effect.Play();
    }
    public void PlayRobotExplosion()
    {
        effect.clip = effects[((int)SoundIds.RobotExplosion)];
        effect.Play();
    }
    public void PlaySword()
    {
        effect.clip = effects[((int)SoundIds.Sword)];
        effect.Play();
    }
    #endregion
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
    Sword
}
