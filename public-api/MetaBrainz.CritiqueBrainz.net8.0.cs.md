# API Reference: MetaBrainz.CritiqueBrainz

## Assembly Attributes

```cs
[assembly: System.Runtime.InteropServices.ComVisibleAttribute(false)]
[assembly: System.Runtime.Versioning.TargetFrameworkAttribute(".NETCoreApp,Version=v8.0", FrameworkDisplayName = ".NET 8.0")]
```

## Namespace: MetaBrainz.CritiqueBrainz

### Type: AuthorizationScope

```cs
[System.FlagsAttribute]
public enum AuthorizationScope {

  Everything = -1,
  None = 0,
  Review = 1,
  User = 4,
  Vote = 2,

}
```

### Type: OAuth2

```cs
public sealed class OAuth2 : System.IDisposable {

  public const string AuthorizationEndPoint = "/oauth/authorize";

  public static readonly System.Uri OutOfBandUri;

  public const string TokenEndPoint = "/ws/1/oauth/token";

  public const string TokenRequestBodyType = "application/x-www-form-urlencoded";

  public static readonly System.Diagnostics.TraceSource TraceSource;

  string ClientId {
    public get;
    public set;
  }

  string DefaultClientId {
    public static get;
    public static set;
  }

  int DefaultPort {
    public static get;
    public static set;
  }

  string DefaultServer {
    public static get;
    public static set;
  }

  string DefaultUrlScheme {
    public static get;
    public static set;
  }

  int Port {
    public get;
    public set;
  }

  string Server {
    public get;
    public set;
  }

  string UrlScheme {
    public get;
    public set;
  }

  public OAuth2();

  public OAuth2(System.Net.Http.HttpClient client, bool takeOwnership = false);

  public void Close();

  public void ConfigureClient(System.Action<System.Net.Http.HttpClient>? code);

  public void ConfigureClientCreation(System.Func<System.Net.Http.HttpClient>? code);

  public System.Uri CreateAuthorizationRequest(System.Uri redirectUri, AuthorizationScope scope, string? state = null);

  public sealed override void Dispose();

  protected override void Finalize();

  public MetaBrainz.CritiqueBrainz.Interfaces.IAuthorizationToken GetBearerToken(string code, string clientSecret, System.Uri redirectUri);

  public System.Threading.Tasks.Task<MetaBrainz.CritiqueBrainz.Interfaces.IAuthorizationToken> GetBearerTokenAsync(string code, string clientSecret, System.Uri redirectUri, System.Threading.CancellationToken cancellationToken = default);

  public MetaBrainz.CritiqueBrainz.Interfaces.IAuthorizationToken RefreshBearerToken(string refreshToken, string clientSecret);

  public System.Threading.Tasks.Task<MetaBrainz.CritiqueBrainz.Interfaces.IAuthorizationToken> RefreshBearerTokenAsync(string refreshToken, string clientSecret, System.Threading.CancellationToken cancellationToken = default);

}
```

## Namespace: MetaBrainz.CritiqueBrainz.Interfaces

### Type: IAuthorizationToken

```cs
public interface IAuthorizationToken : MetaBrainz.Common.Json.IJsonBasedObject {

  string? AccessToken {
    public abstract get;
  }

  int Lifetime {
    public abstract get;
  }

  string? RefreshToken {
    public abstract get;
  }

  string? TokenType {
    public abstract get;
  }

}
```
