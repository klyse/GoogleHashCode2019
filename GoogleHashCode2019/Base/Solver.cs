using System.IO;

namespace GoogleHashCode2019.Base
{
	public abstract class Solver<TInput, TOutput> where TOutput : Output, new() where TInput : Input, new()
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

        public TOutput ExecuteAndSave(string inputPath, string outputPath, bool createSolverDir = false)
        {
            var input = new TInput();
            input.Load(inputPath);

            var output = Execute(input);
            var fileName = outputPath;
            if (createSolverDir)
                fileName = Path.Combine(fileName, this.GetType().Name);
            fileName = Path.Combine(fileName, Input.FileName);

            output.Save(fileName);

            return Output;
        }
    }
}