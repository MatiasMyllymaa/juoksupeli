using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class platform : MonoBehaviour
{
    private PlatformGenerator _platformgenerator;
    //platformin liikkumis nopeus
    public float moveSpeed;

    const float PLATFORM_SIZE = 40f; // Platformin koko
    private GameObject _Player;
    private void OnEnable()
    {
        _platformgenerator = GameObject.FindObjectOfType<PlatformGenerator>();
        _Player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {
        if (_Player.transform.position.z > transform.position.z + PLATFORM_SIZE)
        {
            _platformgenerator.RecyclePlatform(this.gameObject);
        }
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }

}
