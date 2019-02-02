namespace GoogleHashCode2018.Algorithms
{
	public interface ISolver<in TDataType>
	{
		 int  Solve(TDataType type);
	}
}