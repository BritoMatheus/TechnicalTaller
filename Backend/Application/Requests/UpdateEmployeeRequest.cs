namespace Application.Requests
{
    public class UpdateEmployeeRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }

        public static implicit operator Domain.Entities.Employee(UpdateEmployeeRequest request)
        {
            return new Domain.Entities.Employee
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Position = request.Position
            };
        }
    }
}
