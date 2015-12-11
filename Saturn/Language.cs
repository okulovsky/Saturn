using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn
{
	class Language
	{
		const string consonants = "йцкнгшщзфвпрлдчмтб";
		const string vowels = "уеаоэиюяы";
		public void Word(StringBuilder builder, int length = 0)
		{
			if (length == 0)
				length = Rnd.NextInt(2, 8);
			bool vowel = Rnd.NextBool(0.3);
			for (int i = 0; i < length; i++)
			{
				if (vowel) builder.Append(Rnd.Element(vowels));
				else builder.Append(Rnd.Element(consonants));
				vowel = !vowel;
			}
		}
		public string Word(int length = 0)
		{
			var builder = new StringBuilder();
			Word(builder, length);
			return builder.ToString();
		}

		public string Text(int length)
		{
			var builder = new StringBuilder();
			while (builder.Length < length)
			{
				Word(builder);
				builder.Append(" ");
			}
			return builder.ToString();
		}

		public Func<string> CreateText(int minLength, int maxLength)
		{
			return () =>
			{
				return Text(Rnd.NextInt(minLength, maxLength));
			};
		}
	}
}
