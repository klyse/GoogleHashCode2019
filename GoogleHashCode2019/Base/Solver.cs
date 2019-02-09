namespace GoogleHashCode2019.Base
{
    public abstract class Solver<I, O> where O : Output, new()
    {
        protected I Input;
        protected O Output;

        protected abstract void Solve();

        public O Execute(I input)
        {
            Input = input;
            Output = new O();
            Solve();

            return Output;
        }
    }
}
