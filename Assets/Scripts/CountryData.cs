using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

[DataContract]
public class CountryData
{
    [DataMember]
    private string countryName = "";

    [DataMember]
    private string[] hints = new string[0];

    [DataMember]
    private string tag = "";


    public CountryData(string name)
    {
        countryName = name;
        tag = "";

    }


    public string GetName() => countryName;


    public string GetTag() => tag;


    public string[] GetHints() => hints;


}
