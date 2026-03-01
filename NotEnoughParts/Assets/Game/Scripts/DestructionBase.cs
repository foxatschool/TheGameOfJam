using UnityEngine;

public abstract class DestructionBase : MonoBehaviour
{
    [SerializeField] protected float degradationRate = 0.1f;
    [SerializeField] protected float repairRate = 0.1f;
    [SerializeField] protected float maxHealth = 100f;
    [SerializeField] protected float currentHealth = 100f;
    [SerializeField] protected bool raparing = false;
    [SerializeField] protected bool isDestroyed = false;
    [SerializeField] protected float maxRandom = 1f;
    private void Update()
    {
        if (!raparing && !isDestroyed)
        {
            float randomFactor = Random.Range(0f, maxRandom);
            currentHealth -= degradationRate * Time.deltaTime * randomFactor;
        }
        else
        {
            currentHealth += repairRate * Time.deltaTime;
        }

    }
}
