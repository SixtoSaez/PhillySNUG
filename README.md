PhillySNUG
==================

Code for the server-side of the demo

The solution contains three separate routes that represent a standard ASP.NET MVC web application; an HTTP-based API for use with the RealWorld.ApiClient project; and an implementation of a REST API complete with the use of hypermedia links. The RealWorld.RestClient project uses the REST version of the web application.

The REST API does not use of a custom media type for the structure of the API messages for simplicity of this demonstration. As in the client project, implementing a custom media type is left as an exercise for the reader.