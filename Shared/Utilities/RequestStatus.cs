namespace Statistics.Client.Utilities
{
    public static class RequestStatus
    {
        public enum Status
        {
            Unsubmitted,
            Ok,
            Updated,
            Error,
            Created,
        }
    }
}