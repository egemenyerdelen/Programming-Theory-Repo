using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public int orderCount;
    public bool isOrderReady;
    public bool isCooking;
    private bool isCollected;
    public int breadCount;

    [SerializeField] private int breadDoughCount;

    private int breadCookingTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        orderCount = 0;
        breadDoughCount = 0;
        isOrderReady = false;
        isCooking = false;
        isCollected = true;
    }

    // Update is called once per frame
    void Update()
    {
        StartCooking();
    }

    public virtual void StartCooking()
    {
        if (breadDoughCount > 0 && orderCount > 0 && !isCooking && isCollected)
        {
            isCollected = false;
            isCooking = true;
            breadDoughCount--;
            StartCoroutine(CookTime(breadCookingTime));
        }
    }
     protected virtual IEnumerator CookTime(int time)
    {
        yield return new WaitForSeconds(time);
        isCooking = false;
        isOrderReady = true;
    }

    public virtual void CollectOrder()
    {
        if (isOrderReady)
        {
            orderCount--;
            // if order is bread
            breadCount++;
            isOrderReady = false;
            isCollected = true;
        }
    }

    public virtual void GiveOrder()
    {
        if (!isOrderReady)
        {
            breadDoughCount++;
            orderCount++;
        }
    }
}
