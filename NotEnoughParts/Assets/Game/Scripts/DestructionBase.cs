using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class DestructionBase : MonoBehaviour
{
    [SerializeField] protected string objectName = "Destructible Object";
    [SerializeField] protected float degradationRate = 0.1f;
    [SerializeField] protected float repairRate = 0.1f;
    [SerializeField] protected float maxHealth = 100f;
    [SerializeField] protected float currentHealth = 100f;
    [SerializeField] protected bool raparing = false;
    [SerializeField] protected float maxRandom = 1f;
    [SerializeField] protected AudioClip[] audioClips = new AudioClip[6];
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
            //audioClips[0].PlayOneShot();
        }

    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }

    

}
