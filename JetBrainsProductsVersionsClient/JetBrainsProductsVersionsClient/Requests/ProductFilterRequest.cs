using System;
using CommunityToolkit.Diagnostics;

namespace JetBrainsProductsVersionsClient.Requests;

public class ProductFilterRequest
{
    public string ProductCode { get; }
    public string ReleaseType { get; }

    public ProductFilterRequest(string productCode, string releaseType)
    {
        Guard.IsNotNull(productCode, nameof(productCode));
        Guard.IsNotNull(releaseType, nameof(releaseType));

        ProductCode = productCode;
        ReleaseType = releaseType;
    }
}