using UnityEngine;

public class CharacterDied : MonoBehaviour
{
    public void Die()
    {
        Time.timeScale = 0f;
    }
}
