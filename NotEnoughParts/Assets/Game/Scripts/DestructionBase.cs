//using Unity.VisualScripting;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
//using UnityEngine.Rendering;

[RequireComponent(typeof(AudioSource))]
public class DestructionBase : MonoBehaviour
{
    private TakeDamageSO takeDamageEvent;

    [SerializeField] protected string objectName = "Destructible Object";
    [SerializeField] protected float degradationRate = 0.1f;
    [SerializeField] protected float repairRate = 0.1f;

    [SerializeField] protected float maxHealth = 100f;
    [SerializeField] public float currentHealth = 100f;

    [SerializeField] protected bool raparing = false;
    [SerializeField] protected float maxRandom = 1f;
    [SerializeField] protected AudioClip[] audioClips = new AudioClip[6];
    private AudioSource audioSource;

    private void Start()
    {
       audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!raparing && currentHealth <= 0)
        {
            float randomFactor = Random.Range(0f, maxRandom);
            currentHealth -= degradationRate * Time.deltaTime * randomFactor;
        }
        else
        {
            currentHealth += repairRate * Time.deltaTime;
        }

        if(currentHealth < 75 && currentHealth > 73)
        {
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }
        else if (currentHealth < 50 && currentHealth > 48)
        {
            audioSource.clip = audioClips[1];
            audioSource.Play();
        }
        else if(currentHealth < 25 && currentHealth > 23)
        {
            audioSource.clip = audioClips[2];
            audioSource.Play();
        }else if(currentHealth < 10 && currentHealth > 8)
        {
            audioSource.clip = audioClips[3];
            audioSource.Play();
        }
        else if(currentHealth < 5 && currentHealth > 3)
        {
            audioSource.clip = audioClips[4];
            audioSource.Play();
        }
        else if(currentHealth <= 0)
        {
            audioSource.clip = audioClips[5];
            audioSource.Play();
            takeDamageEvent.RaiseEvent();
        }
         currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }

    

}
