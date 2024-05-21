
    
public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsSeller { get; set; }
    }

    // Models/Property.cs
    public class Property
    {
        public int Id { get; set; }
        public string Place { get; set; }
        public double Area { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public string NearbyFacilities { get; set; }
        public int SellerId { get; set; }
        public User Seller { get; set; }
    }

