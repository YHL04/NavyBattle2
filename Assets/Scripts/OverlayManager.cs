using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayManager : MonoBehaviour
{
    public GameObject panelPrefab;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel = Instantiate(panelPrefab);
    }

}
