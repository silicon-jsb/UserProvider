using Data.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace UserProvider.Functions
{
    public class DeleteUser
    {
        private readonly ILogger<DeleteUser> _logger;
        private readonly DataContext _context;

        public DeleteUser(ILogger<DeleteUser> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Function("DeleteUser")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "users/{id}")] HttpRequestData req, string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return new NotFoundResult();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

    }
}
