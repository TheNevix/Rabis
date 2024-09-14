using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rabis.Api.Dtos.User.Requests;
using Rabis.Api.Services;
using Rabis.Api.Settings;

namespace Rabis.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet(Endpoints.User.Get)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var result = _userService.Get(cancellationToken);

            return Ok(result);
        }

        [HttpPost(Endpoints.User.Create)]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            var result = _userService.Create(request);

            return Ok(result);
        }

        [HttpPut(Endpoints.User.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var result = _userService.Update(request.Id, request, cancellationToken);

            return Ok(result);
        }

        [HttpPut(Endpoints.User.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var result = _userService.Update(request.Id, request, cancellationToken);

            return Ok(result);
        }

        [HttpPut(Endpoints.User.Delete)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken)
        {
            Guid TempId = Guid.NewGuid();


            return Ok(result);
        }
    }
}
