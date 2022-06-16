using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace VSpor.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {

        private readonly IDbConnection _dbConnection;
        private IConfiguration _configuration;
        public TestController(IDbConnection dbConnection, IConfiguration configuration)
        {
            _dbConnection = dbConnection;
            _configuration = configuration;
        }
        //[HttpGet("api/GetTestSubeler")]
        //public async Task<IEnumerable<Subeler>> GetTestSubeler()
        //{
        //    return await new DapperRepository(_dbConnection).QueryAsync<Subeler>(
        //        SubelerQuery.GetSubelerSql);
        //}

        //[HttpGet("api/GetCategories")]
        //public async Task<IEnumerable<Categori>> GetCategories()
        //{
        //    return await new DapperRepository(_dbConnection).QueryAsync<Categori>(
        //        CategoriQuery.GetCategoriesSql);
        //}

        //[HttpGet("api/GetProducts")]
        //public async Task<IEnumerable<Product>> GetProducts()
        //{
        //    return await new DapperRepository(_dbConnection).QueryAsync<Product>(
        //        ProductQuery.GetProductsSql);
        //}

        //[HttpGet("api/GetProduct/{productId}")]
        //public async Task<Product> GetProduct(int productId)
        //{
        //    return await new DapperRepository(_dbConnection).QueryFirstOrDefaultAsync<Product>(
        //        ProductQuery.GetProductSql,
        //        new 
        //        {
        //            productId = productId
        //        });
        //}

        //[HttpPost("AddCategori")]
        //public async Task<int> AddCategori(Categori categori)
        //{
        //    return await new DapperRepository(_dbConnection)
        //        .ExecuteAsync(CategoriQuery.InsertCategoriSql, categori);
        //}

        //[HttpPost("UpdateCategori")]
        //public async Task<int> UpdateCategori(Categori categori)
        //{
        //    return await new DapperRepository(_dbConnection)
        //        .ExecuteAsync(CategoriQuery.UpdateCategoriSql, categori);
        //}

        //[HttpPost("UpdateCategoriV2")]
        //public async Task<Categori> UpdateCategoriV2(Categori categori)
        //{
        //    return await new DapperRepository(_dbConnection)
        //        .QueryFirstOrDefaultAsync<Categori>
        //        (CategoriQuery.UpdateCategoriSqlV2, categori);
        //}

        //[HttpPost("DeleteCategori")]
        //public async Task<int> DeleteKategori(int Id)
        //{
        //    return await new DapperRepository(_dbConnection)
        //        .ExecuteAsync(CategoriQuery.DeleteCategoriSql, new { Id = Id });
        //}

        //[HttpPost("Topla")]
        //public int Topla(int sayi1,int sayi2)
        //{
        //    return  new TestBll().Topla(sayi1, sayi2);
        //}
        //[HttpPost("ToplaV2")]
        //public int ToplaV2(int[] sayilar)
        //{
        //    return new TestBll().Topla(sayilar);
        //}
    }
}
