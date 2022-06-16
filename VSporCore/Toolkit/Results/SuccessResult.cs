namespace VSporCore.Toolkit.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true, ResultMessages.OperationSuccess)
        {
        }

        public SuccessResult(string message) : base(true, message)
        {
        }
    }
}
