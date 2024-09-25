namespace StudentPortal.Web.Models.Entities
{
    public class Student
    {
        public Guid ID { get; set; }// Entity framework will automatically set this ID for us
        
        public string name { get; set; }
        public string email { get; set; }
        public bool Subscribed { get; set; }


    }
}