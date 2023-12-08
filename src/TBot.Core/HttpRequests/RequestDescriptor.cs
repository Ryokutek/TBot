using TBot.Core.HttpRequests.Models;

namespace TBot.Core.HttpRequests;

public class RequestDescriptor
{
    public HttpMethod Method { get; private set; }
    public string Endpoint { get; private set; }
    public List<Header> Headers { get; private set; }
    public List<QueryParameter> QueryParameters { get; private set; }
    public List<Content> Contents { get; private set; }
    
    private RequestDescriptor(
        HttpMethod method, 
        string endpoint,
        List<Header> headers, 
        List<QueryParameter> queryParameters, 
        List<Content> contents)
    {
        Method = method;
        Endpoint = endpoint;
        Headers = headers;
        QueryParameters = queryParameters;
        Contents = contents;
    }
    
    public static RequestDescriptor CreatePost(
        string endpoint,
        List<QueryParameter> queryParameters,
        List<Header>? headers = null,
        List<Content>? contents = null)
    {
        return Create(HttpMethod.Post, endpoint, queryParameters, headers, contents);
    }
    
    public static RequestDescriptor Create(
        HttpMethod method, 
        string endpoint,
        List<QueryParameter> queryParameters,
        List<Header>? headers = null,
        List<Content>? contents = null)
    {
        return new RequestDescriptor(
            method, 
            endpoint, 
            headers ?? new List<Header>(), 
            queryParameters,
            contents ?? new List<Content>());
    }
}