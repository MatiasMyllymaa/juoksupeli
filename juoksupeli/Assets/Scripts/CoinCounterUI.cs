using UnityEngine;
using TMPro;

public class CoinCounterUI : MonoBehaviour
{
    private TextMeshProUGUI coinText;
    private CoinCollector coinCollector;

    void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();
        if (coinText == null)
        {
            return;
        }

        coinCollector = FindObjectOfType<CoinCollector>();
        if (coinCollector != null)
        {
            UpdateCoinCount(coinCollector.coinCount); // Update the coin count
        }
    }

    public void UpdateCoinCount(int count)
    {
        if (coinText != null)
        {
            coinText.text = count.ToString();
        }
    }

    void Update()
    {
        if (coinCollector != null)
        {
            UpdateCoinCount(coinCollector.coinCount); // update the coincount
        }
    }
}
