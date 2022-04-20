using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrainsProductsVersionsClient.Requests;

namespace JetBrainsProductsVersionsClient.Services;

public interface IJetBrainsApiService
{
    /// <summary>
    /// Retrieves all JetBrains products from their API.
    /// </summary>
    /// <returns>The <see cref="List{T}"/> of all <see cref="ProductRequest"/></returns>
    Task<List<ProductRequest>> RetrieveAllProductsAsync();

    /// <summary>
    /// Retrieves certain JetBrains product.
    /// </summary>
    /// <param name="productFilterRequest">The request for filtering product request.</param>
    /// <returns>The <see cref="List{T}"/> of all <see cref="ProductRequest"/></returns>
    Task<List<ProductRequest>> RetrieveProductAsync(ProductFilterRequest productFilterRequest);
}