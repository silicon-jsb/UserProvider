using Data.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker.Http;


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
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "fetch")] HttpRequestData req)
    {
        var users = await _context.Users.ToListAsync();
        return new OkObjectResult(users);
    }
}
