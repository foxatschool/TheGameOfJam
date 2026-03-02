//using Unity.VisualScripting;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
//using UnityEngine.Rendering;

[RequireComponent(typeof(AudioSource))]
public class DestructionBase : MonoBehaviour
{
    [SerializeField]private TakeDamageSO takeDamageEvent;

    [SerializeField] protected string objectName = "Destructible Object";
    [SerializeField] protected float degradationRate = .1f;
    [SerializeField] protected float repairRate = .1f;

    [SerializeField] protected float maxHealth = 100f;
    [SerializeField] public float currentHealth = 100f;

    protected float timeBetweenDamage = 0.1f;
    [SerializeField] protected float timeBetweenDamageMax = 0.1f;
    protected float timeBetweenRepair = 1.0f;
    [SerializeField] protected float timeBetweenRepairMax = 1.0f;

    [SerializeField] protected bool raparing = false;
    //[SerializeField] protected float maxRandom = 1f;
    [SerializeField] protected AudioClip[] audioClips = new AudioClip[6];
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //Log($"{objectName} is getting damaged.");
        if (!raparing && timeBetweenDamage <= 0 && currentHealth > 0)
        {
            //float randomFactor = Random.Range(0f, maxRandom);
            currentHealth -= degradationRate;
            timeBetweenDamage = timeBetweenDamageMax;
            onDamage();
        }
        else if (raparing)
        {
            currentHealth += repairRate * Time.deltaTime;
        }
        else
        {
            timeBetweenDamage -= Time.deltaTime;
        }

        if (currentHealth <= 0)
        {
            //Log($"{objectName} is destroyed.");
            takeDamageEvent?.RaiseEvent();
        }

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    private void onDamage()
    {
        if (currentHealth == 75.0f && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioClips[0]);
        }
        else if (currentHealth == 50.0f && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioClips[1]);
        }
        else if (currentHealth == 25.0f && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioClips[2]);
        }
        else if (currentHealth == 10.0f && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioClips[3]);
        }
        else if (currentHealth == 5.0f && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioClips[4]);
        }
        else if (currentHealth <= 0)
        {
            audioSource.PlayOneShot(audioClips[5]);
            
        }
    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }
}
