namespace Pharmax.Models
{
    public class AdminList
    {
        public static List<Admin> _admin = new List<Admin>()
        {
            new Admin(){AdminName="admin2",AdminPhone=1234567891,AdminEmail="admin2@gmail.com",AdminPassword="admin2",Role="administrator" },
            new Admin(){AdminName="admin",AdminPhone=1234567895,AdminEmail="admin@gmail.com",AdminPassword="admin",Role="administrator"}
        };
    }
}
