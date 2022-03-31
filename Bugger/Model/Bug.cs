namespace Bugger.Model
{
    public class Bug
    {
        public string BugID { get; }
        public string Assignee { get; }
        public string Status { get; }
        public string Description { get; }
        public string FixDescription { get; }
        public  string DateRaised { get; }
        public string DateClosed { get; }

        public Bug(string bugId, string assignee, string status, string description, string fixDescription, string dateRaised, string dateClosed)
        {
            BugID = bugId;
            Assignee = assignee;
            Status = status;
            Description = description;
            FixDescription = fixDescription;
            DateRaised = dateRaised;
            DateClosed = dateClosed;
        }
    }
}
