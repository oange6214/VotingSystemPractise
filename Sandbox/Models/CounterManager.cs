internal class CounterManager
{
	public CounterManager(params ICounter[] counters)
	{
		Counters = new List<ICounter>(counters);
	}

	public List<ICounter> Counters { get; set; }

	public int Total() => Counters.Sum(c => c.Count);

	public double TotalPercentage() => Counters.Sum(c => c.GetPercent(Total()));

	public void AnounceWinner()
	{
		var excess = Math.Round(100 - TotalPercentage(), 2);

		Console.WriteLine($"Excess: {excess}");

		var biggestAmountOfVotes = Counters.Max(x => x.Count);

		var winners = Counters.Where(x => x.Count == biggestAmountOfVotes).ToList();

		if(winners.Count == 1)
		{
			var winner = winners.First();
			winner.AddExcess(excess);
			Console.WriteLine($"{winner.Name} Won!");
		}
		else
		{
			if (winners.Count != Counters.Count)
			{
				var lowestAmountOfVotes = Counters.Min(x => x.Count);
				var loser = Counters.First(x => x.Count == lowestAmountOfVotes);
				loser.AddExcess(excess);
			}

			Console.WriteLine(string.Join(" -DRAW- ", winners.Select(x => x.Name)));
		}

		foreach (var c in Counters)
		{
			Console.WriteLine($"{c.Name} Counts: {c.Count}, Percentage: {c.GetPercent(Total())}%");
		}

		Console.WriteLine($"Total Percentage: {Math.Round(TotalPercentage(), 2)}%");
	}
}