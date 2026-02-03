using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService:IProductService
    {
        private readonly IMongoCollection<Product> _productsColleciton;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productsColleciton = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;

        }
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _productsColleciton.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productsColleciton.DeleteOneAsync(x => x.ProductID == id);


        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var values = await _productsColleciton.Find<Product>(x => x.ProductID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(values);
        }

        public async Task<List<ResultProductDto>> GetProductDtosAsync()
        {
            var values = await _productsColleciton.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await _productsColleciton.FindOneAndReplaceAsync(x => x.ProductID == updateProductDto.ProductID, values);


        }
    }
}
