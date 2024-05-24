using Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.AspNetCore.Http;


namespace UserProvider.Functions;


public class GetUsers
{
    private readonly ILogger<GetUsers> _logger;
    private readonly DataContext _context;

    public GetUsers(ILogger<GetUsers> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
    }

    [Function("GetUsers")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetUsers")] HttpRequestData req)
    {
        try
        {
            var users = await _context.Users.ToListAsync();
            return new OkObjectResult(users);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching users.");
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }

}
