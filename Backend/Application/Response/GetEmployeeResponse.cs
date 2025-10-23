namespace Application.Response
{
    public class GetEmployeeResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }

        public static implicit operator GetEmployeeResponse(Domain.Entities.Employee model)
        {
            return new GetEmployeeResponse
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Position = model.Position
            };
        }
    }
}
