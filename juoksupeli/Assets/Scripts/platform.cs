using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    private PlatformManager _platformmanager;
    public float moveSpeed;
    private GameObject _Player;
    public GameObject[] coins; // Array to store the coins on the platform

    const float PLATFORM_SIZE = 40f; // Platform size

    private void OnEnable()
    {
        _platformmanager = GameObject.FindObjectOfType<PlatformManager>();
        _Player = GameObject.FindGameObjectWithTag("Player");

        GetChildCoins(); // Collect coins on this platform
    }

    private void GetChildCoins()
    {
        List<GameObject> childCoins = new List<GameObject>();

        foreach (Transform childObject in transform)
        {
            foreach (Transform child in childObject)
            {
                if (child.CompareTag("Coin"))
                {
                    childCoins.Add(child.gameObject);
                }
            }
        }

        coins = childCoins.ToArray();
    }

    private void Update()
    {
        if (_Player.transform.position.z > transform.position.z + PLATFORM_SIZE)
        {
            _platformmanager.RecyclePlatform(this.gameObject);

            ReactivateCoins();
        }

        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }

    private void ReactivateCoins()
    {
        // coins active
        foreach (GameObject coin in coins)
        {
            coin.SetActive(true);
        }
    }
}
