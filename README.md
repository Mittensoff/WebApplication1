# WebApplication1
Async, HttpClient, Mapper practice
TODO: 
Tests

// Summary for a method/class etc 

/// <summary>
/// Sets the <see cref="Context"/> associated with the provided <see cref="HttpRequestMessage"/>.
/// </summary>
/// <param name="request">The <see cref="HttpRequestMessage"/>.</param>
/// <param name="context">The <see cref="Context"/>, may be <c>null</c>.</param>
/// <remarks>
/// The <see cref="PolicyHttpMessageHandler"/> will attach a context to the <see cref="HttpResponseMessage"/> prior
/// to executing a <see cref="Policy"/>, if one does not already exist. The <see cref="Context"/> will be provided
/// to the policy for use inside the <see cref="Policy"/> and in other message handlers.
/// </remarks>
