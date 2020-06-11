using System.Collections;
using System.Collections.Generic;

public class ContinentData
{
    private string continentName;
    private Dictionary<string, CountryData> countries = new Dictionary<string, CountryData>();


    public ContinentData(string name)
    {
        continentName = name;
    }

    public string GetName() => continentName;


    public Dictionary<string, CountryData> GetCountries() => countries;

}
