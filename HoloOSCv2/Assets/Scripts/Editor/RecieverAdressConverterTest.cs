using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class RecieverAdressConverterTest
{
    ReceiverAdressConverter conv;
    string input;

    [Test]
    public void ValidAdressPatternTest() {
        input = "127.0.0.1:1234";
        conv = new ReceiverAdressConverter(input);
        Assert.True(conv.Validate());
    }
    [Test]
    public void InvalidAdressPatternTest() {
        input = "1231921959123:00022";
        conv = new ReceiverAdressConverter(input);
    }

    [Test]
    public void validSplitTest() {
        input = "127.0.0.1:1234";
        conv = new ReceiverAdressConverter(input);
        string[] adress = conv.splitAdress();
        StringAssert.IsMatch(@"\d{3}\.\d{1,3}\.\d{1}\.\d{1,2}", adress[0]); //Pattern for IP Adress
        StringAssert.IsMatch("^[0-9]{4}$", adress[1]); // Pattern for Port
    }

}
