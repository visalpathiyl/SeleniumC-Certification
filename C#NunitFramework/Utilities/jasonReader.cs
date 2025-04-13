using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class jasonReader
{
         [SetUp]
         public void Setup()
        {
            String jsonString = File.ReadAllText("C:\\Users\\a2618823\\source\\repos\\SeleniumAutomationNew\\C#NunitFramework\\Utilities\\TestData.js");
            var parsedData= JToken.Parse(jsonString);
        TestContext.Progress.WriteLine(parsedData.SelectToken("username").Value<string>());
       
        }


    [Test]
    public void DummyTest()
    {
        Assert.Pass("File have been executed");
    }

}
