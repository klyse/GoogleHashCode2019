namespace GoogleHashCode2019.Base
{
	public abstract class Solver<TInput, TOutput> where TOutput : Output, new()
	{
		protected TInput Input;
		protected TOutput Output;

		protected abstract void Solve();

		public TOutput Execute(TInput input)
		{
			Input = input;
			Output = new TOutput();
			Solve();

			return Output;
		}
	}
}