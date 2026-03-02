using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Damage", menuName = "Events/DamageFlag")]
public class TakeDamageSO : ScriptableObject
{
    private UnityAction listeners;
    

    public void Subscribe(UnityAction listener) => listeners += listener;
    public void Unsubscribe(UnityAction listener) => listeners -= listener;
    public void RaiseEvent() => listeners?.Invoke();
}