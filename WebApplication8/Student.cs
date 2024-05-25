namespace WebApplication8




{
    

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Override Equals method to compare properties
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var otherStudent = (Student)obj;
            return Id == otherStudent.Id && Name == otherStudent.Name && Email == otherStudent.Email;
        }

        // Override GetHashCode method (optional)
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Id.GetHashCode();
                hash = hash * 23 + (Name != null ? Name.GetHashCode() : 0);
                hash = hash * 23 + (Email != null ? Email.GetHashCode() : 0);
                return hash;
            }
        }
    }

}
