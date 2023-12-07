using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int coinCount = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin")) 
        {
            CollectCoin(other.gameObject); // Collect the coin
        }
    }

    void CollectCoin(GameObject coin)
    {
        coin.SetActive(false); // Deactivate the collected coin (platform script activates it)
        coinCount++;
    }
}
