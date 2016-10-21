using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace NinjaNye.SearchExtensions.Tests
{
	public class BuildStringTestsBase
	{
		private const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

		protected IList<string> BuildWords(int wordCount, int minSize = 2, int maxSize = 10, bool processParallel = true)
		{
			Console.WriteLine("Building {0} words...", wordCount);

			var query = Enumerable.Range(0, wordCount);
			if (processParallel) query = query.AsParallel();

			var result = query
				.Select(x => BuildRandomWord(minSize, maxSize))
				.ToList();

			Console.WriteLine("Built words: {0}", wordCount);
			return result;
		}

		protected string BuildRandomWord(int minSize, int maxSize)
		{
			var letterCount = RandomInt(minSize, maxSize);
			var wordLettes = Enumerable.Range(0, letterCount)
				.Select(x => letters[RandomInt(0, 51)]);
			return new string(wordLettes.ToArray());
		}

		private int RandomInt(int min, int max)
		{
			var rng = new RNGCryptoServiceProvider();
			var buffer = new byte[4];

			rng.GetBytes(buffer);
			int result = BitConverter.ToInt32(buffer, 0);

			return new Random(result).Next(min, max);
		}
	}
}