using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinentManager : MonoBehaviour
{
    public static ContinentManager continentManager;

    private void Awake()
    {
        continentManager = this;
    }


    public GameObject afrikka;
}
