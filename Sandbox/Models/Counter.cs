internal class Counter : ICounter
{
	private double? _percentage;

	public Counter(string name, int count)
	{
		Name = name;
		Count = count;
	}

	public string Name { get; set; }

	public int Count { get; private set; }

	public double GetPercent(int total) => _percentage ??
		(_percentage = Math.Round(Count * 100.0 / total, 2)).Value;

	public void AddExcess(double excess) => _percentage += excess;
}