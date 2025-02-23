using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
  public static AudioManager Instance { get; private set; }
  [SerializeField] AudioSource sfxAudio, musicAudio, powerupAudio;
  public AudioClip initialMusic;
  [SerializeField] AudioMixer master;
  [Range (-5,5)]

  public float musicVolume, sfxVolume, powerupVolume;


  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      DontDestroyOnLoad(this.gameObject); //no se destruye al cambiar de escena.

    }
    else
    {
      Destroy(this.gameObject);
    }
  }
  void Start()
  {
    sfxAudio = transform.GetChild(0).GetComponent<AudioSource>();
    musicAudio = transform.GetChild(1).GetComponent<AudioSource>();
    powerupAudio = transform.GetChild(2).GetComponent<AudioSource>();
    InitialPlayMusic(initialMusic);
  }
  void Update ()
  {
    MusicVolumeControl(musicVolume);
    SfxVolumeControl(sfxVolume);
  }

  public void PlayOneShot(AudioClip clip)
  {
    sfxAudio.PlayOneShot(clip);
  }
  public void PlayPowerupSFX(AudioClip clip)
  {
    powerupAudio.PlayOneShot(clip);
  }

  void InitialPlayMusic(AudioClip clip)
  {
    musicAudio.Stop();
    musicAudio.clip = clip;
    musicAudio.Play();
    musicAudio.loop = true;
  }

  public void MusicVolumeControl(float volume)
  {
    master.SetFloat("Music", Mathf.Log10(volume) * 20);
  }
  public void SfxVolumeControl(float volume)
  {
    master.SetFloat("Sfx", Mathf.Log10(volume) * 20);
  }
  public void PowerupVolumeControl(float volume)
  {
    master.SetFloat("Powerup", volume);
  }
}



