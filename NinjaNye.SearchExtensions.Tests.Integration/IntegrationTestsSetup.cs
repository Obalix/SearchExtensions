using System;
using NUnit.Framework;

namespace NinjaNye.SearchExtensions.Tests.Integration
{
	[SetUpFixture]
	public class IntegrationTestsSetup
	{
		[OneTimeSetUp]
		public void IntegrationTestFixtureSetup()
		{
			// Add DataDirectory to curretnt AppDomain, so that connection string can use it
			AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
		}

		[OneTimeTearDown]
		public void IntegrationTestFixtureTearDown()
		{

		}
	}
}
