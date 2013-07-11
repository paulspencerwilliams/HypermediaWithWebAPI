using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace AcceptanceTests
{
    [Binding]
    public class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario("json")]
        public void BeforeScenario()
        {
            var apiProxy = new ApiProxy(ApiProxy.ApiFormat.Json);
            ScenarioContext.Current["apiProxy"] = apiProxy;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
