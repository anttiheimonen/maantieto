﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using UnityEngine;


public class ContinentManager // : MonoBehaviour
{
    public ContinentData continentData;


    public void ChangeCountryColor()
    {

    }


    public string GetContinentInfo(string tag)
    {
        return "GetContinentInfo ei vielä valmis";
    }


    /// Loads data of a continent from a file
    public void LoadContinentData(string tag)
    {
        FileStream fs = File.OpenRead(@"Assets/world_data.json");
        var ser = new DataContractJsonSerializer(typeof(ContinentData));

        continentData = (ContinentData)ser.ReadObject(fs);
        Debug.Log("tiedot ladattu");
        // continentData.GetNumberOfCountries();
        continentData.Initialize();
    }


    public string GetRandomCountryTag()
    {
        return continentData.GetRandomCountry().GetTag();
    }


    public CountryData GetRandomCountryData()
    {
        Debug.Log("Palautetaan random maa...");
        return continentData.GetRandomCountry();
    }


    public string Debugaa()
    {
        return "CM instanssissta";
    }

}
