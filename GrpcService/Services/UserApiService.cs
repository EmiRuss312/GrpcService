using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcService.Entities;

namespace CrudGrpcApp.Services;
public class UserApiService : UserService.UserServiceBase
{
    ApplicationContext db;
    public UserApiService(ApplicationContext db)
    {
        this.db = db;
    }
    public override async Task<LoginReply> Login(LoginRequest request, ServerCallContext context)
    {
        string phone = request.Phone;
        string password = request.Password;
        var user = db.Clients.Where(b => b.PhoneNumber == phone).FirstOrDefault();
        LoginReply reply;
        if (user == null)
        {
            reply = new LoginReply() { Signup = false };
            return await Task.FromResult(reply);
        }
        if (user.Password != password)
        {
            reply = new LoginReply() { Signup = false };
            return await Task.FromResult(reply);
        }
        reply = new LoginReply() { Signup = true };
        return await Task.FromResult(reply);
    }

    public override async Task<GetUserReply> GetUser(GetUserRequest request, ServerCallContext context)
    {
        var user = db.Clients.Where(param => param.PhoneNumber == request.PhoneNumber).FirstOrDefault();
        GetUserReply reply;
        if (user == null)
        {
            reply = new GetUserReply() {};
            return await Task.FromResult(reply);
        }
        reply = new GetUserReply() { FirstName = user.Name, SecondName = user.SecondName, LastName = user.LastName, Phone = user.PhoneNumber, TimeDeposit = user.TimeDeposit, DemandDeposit = user.DemandDeposit, CardDeposit = user.CardDeposit };
        return await Task.FromResult(reply);
    }
}
