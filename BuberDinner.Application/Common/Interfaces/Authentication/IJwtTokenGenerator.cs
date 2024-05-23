using BuberDinner.Domain.UserAggregate;

namespace BuberDinner.Application.Common.Interfaces.Authentication;

// This interface specifies the methods for a JWT (JSON Web Token) generator service,
// essential for creating secure, user-specific tokens that enable authenticated access
// to application resources.
public interface IJwtTokenGenerator
{
    // Contract method to generate a JWT,
    // encoding the user's identification details into a compact, URL-safe string used for authenticating API requests.
    string GenerateToken(User user);
}