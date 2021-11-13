using System;

using JetBrains.Annotations;

namespace MetaBrainz.CritiqueBrainz;

/// <summary>Enumeration of the scopes available through CritiqueBrainz OAuth2 authentication.</summary>
[Flags]
[PublicAPI]
public enum AuthorizationScope {

  /// <summary>No authorization requested.</summary>
  None = 0,

  /// <summary>Request all available permissions (not recommended).</summary>
  Everything = -1,

  /// <summary>Create and modify reviews.</summary>
  Review = 0x00000001,

  /// <summary>Submit and delete votes on reviews.</summary>
  Vote = 0x00000002,

  /// <summary>Modify profile info and delete profile.</summary>
  User = 0x00000004,

}
