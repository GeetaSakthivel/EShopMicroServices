﻿
namespace Catalog.API.Products.GetProduct
{

    public record GetProductQuery(int? pageNumber = 1, int? pageSize = 10) :IQuery<GetProductResult>;
    public record GetProductResult(IEnumerable<Product> Products);
    public class GetProductQueryHandler(IDocumentSession session) : IQueryHandler<GetProductQuery, GetProductResult>
    {
       public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            var products = await session.Query <Product>().ToPagedListAsync(query.pageNumber ?? 1,query.pageSize ?? 10,cancellationToken);
            return new GetProductResult(products);

        }
    }
}
 