using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class ReceiverAdressConverter
{
    string adressPattern = @"\d{3}\.\d{1,3}\.\d{1}\.\d{1,2}:\d{2,4}";
    string input;

    public ReceiverAdressConverter(string input) {
        this.input = input;
    }

    public bool Validate() {
        return Regex.IsMatch(input,adressPattern);
    }

    public string [] splitAdress() {
        string [] results;
        results=Regex.Split(input, ":");
        return results;
    }

    public static string[] splitAdress(string input) {
        string[] results;
        results = Regex.Split(input, ":");
        return results;
    }

}
