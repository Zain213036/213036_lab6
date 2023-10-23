using System;

namespace Program
{
    class OOP
    {
        public class WorkItem
        {
            private static int currentID;
            protected int ID { get; set; }
            protected string Title { get; set; }
            protected string Description { get; set; }
            protected TimeSpan jobLength { get; set; }

            public WorkItem()
            {
                ID = 0;
                Title = "Default Title";
                Description = "Default Description. "; jobLength = new TimeSpan();
            }

            public WorkItem(string title, string des, TimeSpan jobLen)
            {
                this.ID = GetNextID(); this.Title = title; this.Description = des; this.jobLength = jobLen;
            }

            static WorkItem()
            {
                currentID = 0;

            }

            protected int GetNextID()
            {
                return ++currentID;
            }

            public void update(string title, TimeSpan joblen)
            {
                this.Title = title;
                this.jobLength = joblen;
            }

            public override string ToString()
            {
                return string.Format("{0} - {1} ", this.ID, this.Title);
            }
        }

        public class changeRequest : WorkItem
        {
            protected int originalItemID { get; set; }
            public changeRequest() { }
            public changeRequest(string title, string desc, TimeSpan joblen, int originalID)
            {
                this.ID = GetNextID();
                this.Title = title;
                this.Description = desc;
                this.jobLength = joblen;
            }

            public changeRequest(int originalItemID)
            {
                this.originalItemID = originalItemID;
            }
        }
        static void Main(string[] args)
        {

            WorkItem item = new WorkItem("Fix Bugs ", "Fix all Bugus in my code Branch", new TimeSpan(3, 4, 0, 0));
            changeRequest change = new changeRequest("Change Base Class Design", "Add members to the class ", new TimeSpan(4, 0, 0), 1);
            Console.WriteLine(item.ToString());
            change.update("Change the Design of the base Class ", new TimeSpan(4, 0, 0));
            Console.WriteLine(change.ToString());
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

    }
}