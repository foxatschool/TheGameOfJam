using UnityEngine;

public class DamageTaker : MonoBehaviour
{
    public TakeDamageSO takeDamageSO;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        takeDamageSO.Subscribe(TakeDamage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage()
    {
        Debug.Log("Damage Taken");
    }
}
