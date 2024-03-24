using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaOven : Oven
{
    public int pizzaCookingtime = 3;
    public int pizzaCount;
    private int pizzaDoughCount;
    private bool isCollected;
    // Start is called before the first frame update
    void Start()
    {
        isCollected = true;
    }

    // Update is called once per frame
    void Update()
    {
        StartCooking();
    }
    public override void StartCooking()
    {
        if (pizzaDoughCount > 0 && orderCount > 0 && !isCooking && isCollected)
        {
            isCollected = false;
            isCooking = true;
            pizzaDoughCount--;
            StartCoroutine(CookTime(pizzaCookingtime));
        }
    }

    public override void CollectOrder()
    {
        if (isOrderReady)
        {
            orderCount--;
            // if order is pizza
            pizzaCount++;
            isOrderReady = false;
            isCollected = true;
        }
    }

    public override void GiveOrder()
    {
        if (!isOrderReady)
        {
            pizzaDoughCount++;
            orderCount++;
        }
    }
    protected override IEnumerator CookTime(int time)
    {
        yield return new WaitForSeconds(time);
        isCooking = false;
        isOrderReady = true;
    }
}
