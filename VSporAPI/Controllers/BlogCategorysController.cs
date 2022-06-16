using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using VSporAPI.Extensions.QueryBuilder;
using VSporAPI.Models.Dto;
using VSporAPI.Models.Request;
using VSporCore.DataAccess.Dapper;
using VSporCore.Toolkit.Results;
using IResult = VSporCore.Toolkit.Results.IResult;
namespace VSpor.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class BlogCategorysController : ControllerBase
    {
        private readonly IDbConnection _dbConnection;
        private IConfiguration _configuration;
        public BlogCategorysController(IDbConnection dbConnection, IConfiguration configuration)
        {
            _dbConnection = dbConnection;
            _configuration = configuration;
        }

        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<IEnumerable<BlogCategorysDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IResult))]
        [HttpPost("/blogcategorys/search")]
        public async Task<IActionResult> Search(BlogCategorysRequest request)
        {
           
            var records = await new DapperRepository(_dbConnection).GetMultipleAsync(
                 BlogCategorysSqlQueryBuilderExtensions
                .GetBlogCategorysSqlQuery(request));

            var datas = await records.ReadAsync<BlogCategorysDto>();
            var count = await records.ReadFirstOrDefaultAsync<int>();

            var result = new SuccessDataResult<IEnumerable<BlogCategorysDto>>(datas, count);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return NotFound(result);
        }
    }
}
