namespace GrpcService.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string? TimeDeposit { get; set; }
        public string? DemandDeposit { get; set;}
        public string? CardDeposit { get; set; }
    }
}
