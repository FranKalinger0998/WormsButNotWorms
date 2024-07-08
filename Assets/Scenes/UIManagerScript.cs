using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    public Button host;
    public Button clinent;
    // Start is called before the first frame update
    void Start()
    {
        host.onClick.AddListener(() => { NetworkManager.Singleton.StartHost(); });
        clinent.onClick.AddListener(() => { NetworkManager.Singleton.StartClient(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
