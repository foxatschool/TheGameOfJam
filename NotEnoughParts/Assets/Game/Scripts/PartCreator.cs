using UnityEngine;

public class PartCreator : MonoBehaviour
{
    [SerializeField] int maxParts = 100;
    float timeForParts = 10;
    [SerializeField] float timeForPartsMax = 10;
    [SerializeField] int partCount = 50;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeForParts -= Time.deltaTime;
        if(timeForParts <= 0)
        {
            if (partCount < maxParts)
            {
                partCount += 1;
            }
            timeForParts = timeForPartsMax;
        }
    }

    public void GiveParts() 
    {
        partCount -= 1;
    }


}
