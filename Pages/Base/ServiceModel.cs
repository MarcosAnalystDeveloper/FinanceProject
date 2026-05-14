using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FinanceProject.Pages;

public class ServiceModel
{
    protected Uri BaseUrl { get; } = new Uri("http://localhost:9999/");

    public static readonly JsonSerializerOptions JsonOptions = new() 
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase, 
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters = { new JsonStringEnumConverter() }
    };
}