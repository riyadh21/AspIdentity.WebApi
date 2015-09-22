using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspNetIdentity.WebApi.Controllers
{
    using System.Threading.Tasks;

    using AspNetIdentity.WebApi.Infrastructure;

    [RoutePrefix("api/RefreshTokens")]
    public class RefreshTokensController : BaseApiController
    {

        private AuthRepository repository = null;

        public RefreshTokensController()
        {
            repository = new AuthRepository();
        }

        [Authorize(Roles = "Admin")]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(repository.GetAllRefreshTokens());
        }

        //[Authorize(Users = "Admin")]
        [AllowAnonymous]
        [Route("")]
        public async Task<IHttpActionResult> Delete(string tokenId)
        {
            var result = await repository.RemoveRefreshToken(tokenId);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Token Id does not exist");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
