﻿using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using NinjaNye.SearchExtensions.Levenshtein;

namespace NinjaNye.SearchExtensions.Tests.LevenshteinTests
{
#if DEBUG
	[Ignore("Performance tests will likely fail in debug mode")]
#endif
	[TestFixture]
	public class LevenshteinDistancePerformanceTests : BuildStringTestsBase
	{
		[TestCase(6)]
		[TestCase(7)]
		public void ToLevenshteinDistance_CompareOneMillionStringsOfLengthX_ExecutesInLessThanOneSecond(int length)
		{
			//Arrange
			var words = BuildWords(1000000, length, length);
			var randomWord = BuildRandomWord(length,length);
			var stopwatch = new Stopwatch();
			//Act
			stopwatch.Start();
			var result = words.Select(w => LevenshteinProcessor.LevenshteinDistance(w, randomWord)).ToList();
			stopwatch.Stop();

			//Assert
			Console.WriteLine("Elapsed Time: {0}", stopwatch.Elapsed);
			Console.WriteLine("Total matching words: {0}", result.Count(i => i == 0));
			Console.WriteLine("Total words with distance of 1: {0}", result.Count(i => i == 1));
			Console.WriteLine("Total words with distance of 2: {0}", result.Count(i => i == 2));
			Console.WriteLine("Total words with distance of 3: {0}", result.Count(i => i == 3));
			Assert.That(stopwatch.Elapsed.TotalMilliseconds, Is.LessThan(1000));
		}
	}
}