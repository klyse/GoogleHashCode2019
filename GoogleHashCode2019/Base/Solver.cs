namespace GoogleHashCode2019.Base
{
	public abstract class Solver<TInput, TOutput> where TOutput : Output, new() where TInput : new()
    {
        protected TInput Input;
        protected TInput Work;
        protected TOutput Output;

		protected abstract void Solve();

		public TOutput Execute(TInput input)
		{
			Input = input;
            Work = new TInput();
			Output = new TOutput();
			Solve();

			return Output;
		}
	}
}