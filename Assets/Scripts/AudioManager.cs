using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField] private AudioClip manzana;
    [SerializeField] private AudioClip bomba;
    [SerializeField] private AudioClip gameOver;
    [SerializeField] private AudioClip musicaFondo;
    [SerializeField] private AudioClip perdidaVida;
    [SerializeField] private AudioClip vida;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = musicaFondo;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayFruitCaught()
    {
        audioSource.PlayOneShot(manzana);
    }

    public void PlayBomb()
    {
        audioSource.PlayOneShot(bomba);
    }

    public void PlayGameOver()
    {
        audioSource.PlayOneShot(gameOver);
    }

    public void PlayLifeLost()
    {
        audioSource.PlayOneShot(perdidaVida);
    }

    public void PlayLifePickup()
    {
        audioSource.PlayOneShot(vida);
    }
}