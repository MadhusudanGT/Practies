using UnityEngine;

public class ObserverPattern : MonoBehaviour
{
    private void Start()
    {
        IBM ibm = new IBM("IBM", 120.00);
        ibm.AddSubscriber(new Investor("MADHU"));
        ibm.AddSubscriber(new Investor("PRAVEEN"));

        ibm.Price= 80.00;
        ibm.Price = 20.00;
        ibm.Price = 110.00;
    }
}