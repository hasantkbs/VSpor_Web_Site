using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using VSporAPI.Extensions.QueryBuilder;
using VSporAPI.Models.Entity;
using VSporAPI.Models.Request;
using VSporCore.DataAccess.Dapper;
using VSporCore.Toolkit.Results;
using IResult = VSporCore.Toolkit.Results.IResult;

namespace VSporAPI.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class ImagesController : ControllerBase
    {
        private readonly IDbConnection _dbConnection;
        private IConfiguration _configuration;
        public ImagesController(IDbConnection dbConnection, IConfiguration configuration)
        {
            _dbConnection = dbConnection;
            _configuration = configuration;
        }

        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<IEnumerable<ImagesEntity>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IResult))]
        [HttpPost("/images/search")]
        public async Task<IActionResult> Search(ImagesRequest request)
        {

            var records = await new DapperRepository(_dbConnection).GetMultipleAsync(
                 ImagesSqlQueryBuilderExtensions
                .GetImagesSqlQuery(request));

            var datas = await records.ReadAsync<ImagesEntity>();
            var count = await records.ReadFirstOrDefaultAsync<int>();

            var result = new SuccessDataResult<IEnumerable<ImagesEntity>>(datas, count);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return NotFound(result);
        }
    }
}
