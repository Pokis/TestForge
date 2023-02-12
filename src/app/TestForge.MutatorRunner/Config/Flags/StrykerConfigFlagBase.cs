namespace TestForge.MutatorRunner.Config.Flags
{
    public abstract class StrykerConfigFlagBase<T> : IMutatorFlagConfig
    {
        public abstract string Description { get; }
        public abstract string Command { get; }
        public T Value { get; }

        protected StrykerConfigFlagBase(T value)
        {
            Value = value;
        }
    }
}
