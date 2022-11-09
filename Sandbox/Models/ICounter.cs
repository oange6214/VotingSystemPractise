internal interface ICounter
{
	int Count { get; }
	string Name { get; set; }

	void AddExcess(double excess);
	double GetPercent(int total);
}