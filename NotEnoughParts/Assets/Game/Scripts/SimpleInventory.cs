using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleInventory : MonoBehaviour
{
    public int parts = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void AddParts(int partAmmount)
    {
        parts += partAmmount;
    }
    public void RemoveParts(int partAmmount)
    {
        if (parts > 0 && Keyboard.current.eKey.isPressed)
        {
            parts -= partAmmount;
            //return true;
        }
        //return false;
    }
}
