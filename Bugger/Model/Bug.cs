namespace Bugger.Model
{
    public class Bug
    {
        public int BugID { get; }
        public string Assignee { get; }
        public string Status { get; }
        public string Description { get; }
        public string FixDescription { get; }
        public  string DateRaised { get; }
        public string DateClosed { get; }

        public Bug(int bugId, string assignee, string status, string description, string dateRaised)
        {
            BugID = bugId;
            Assignee = assignee;
            Status = status;
            Description = description;
            DateRaised = dateRaised;
        }
    }
}
