namespace Application.Requests
{
    public class InsertEmployeeRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }

        public static implicit operator Domain.Entities.Employee(InsertEmployeeRequest request)
        {
            return new Domain.Entities.Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Position = request.Position
            };
        }
    }
}
