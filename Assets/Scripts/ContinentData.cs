using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;



[DataContract]
public class ContinentData
{
    [DataMember]
    private string tag = "";

    [DataMember]
    private string continentName = "";

    [DataMember]
    private CountryData[] countries = new CountryData[0];

    private Dictionary<string, CountryData> countriesDic;

    private int numberOfCountries;


    /// Sets up a directory structure of countries so that countries can be
    /// get by tag.
    public void Initialize()
    {
        countriesDic = new Dictionary<string, CountryData>();
        numberOfCountries = countries.Length;
        foreach (var c in countries)
        {
            countriesDic.Add(c.GetTag(), c);
        }
    }


    public string GetName() => continentName;


    public string GetTag() => tag;


    public int GetNumberOfCountries() => numberOfCountries;


    public Dictionary<string, CountryData> GetCountries() =>
        countriesDic;


    public CountryData GetRandomCountry()
    {
        System.Random rnd = new System.Random();
        int idx = rnd.Next(0, numberOfCountries);
        return countries[idx];
    }
}
