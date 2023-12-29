# MetaBrainz.CritiqueBrainz [![Build Status][CI-S]][CI-L] [![NuGet Version][NuGet-S]][NuGet-L]

This is a library providing access to the
[CritiqueBrainz API v1][api-reference].

[CritiqueBrainz][home] is a repository for Creative Commons licensed
music reviews; it is based on data from [MusicBrainz][mb-home], an open
music encyclopedia.

This also contains OAuth2 functionality.

[CI-S]: https://github.com/Zastai/MetaBrainz.CritiqueBrainz/actions/workflows/build.yml/badge.svg
[CI-L]: https://github.com/Zastai/MetaBrainz.CritiqueBrainz/actions/workflows/build.yml

[NuGet-S]: https://img.shields.io/nuget/v/MetaBrainz.CritiqueBrainz
[NuGet-L]: https://nuget.org/packages/MetaBrainz.CritiqueBrainz

[api-reference]: https://critiquebrainz.readthedocs.io/api.html
[home]: https://critiquebrainz.org/
[mb-home]: https://musicbrainz.org/

## Debugging

The `OAuth2` class provides a `TraceSource` that can be used to
configure debug output; its name is `MetaBrainz.CritiqueBrainz.OAuth2`.

### Configuration

#### In Code

In code, you can enable tracing like follows:

```cs
// Use the default switch, turning it on.
OAuth2.TraceSource.Switch.Level = SourceLevels.All;

// Alternatively, use your own switch so multiple things can be
// enabled/disabled at the same time.
var mySwitch = new TraceSwitch("MyAppDebugSwitch", "All");
OAuth2.TraceSource.Switch = mySwitch;

// By default, there is a single listener that writes trace events to
// the debug output (typically only seen in an IDE's debugger). You can
// add (and remove) listeners as desired.
var listener = new ConsoleTraceListener {
  Name = "MyAppConsole",
  TraceOutputOptions = TraceOptions.DateTime | TraceOptions.ProcessId,
};
OAuth2.TraceSource.Listeners.Clear();
OAuth2.TraceSource.Listeners.Add(listener);
```

#### In Configuration

Starting from .NET 7 your application can also be set up to read tracing
configuration from the application configuration file. To do so, the
application needs to add the following to its startup code:

```cs
System.Diagnostics.TraceConfiguration.Register();
```

(Provided by the `System.Configuration.ConfigurationManager` package.)

The application config file can then have a `system.diagnostics` section
where sources, switches and listeners can be configured.

```xml
<configuration>
  <system.diagnostics>
    <sharedListeners>
      <add name="console" type="System.Diagnostics.ConsoleTraceListener" traceOutputOptions="DateTime,ProcessId" />
    </sharedListeners>
    <sources>
      <source name="MetaBrainz.CritiqueBrainz.OAuth2" switchName="MetaBrainz.CritiqueBrainz">
        <listeners>
          <add name="console" />
          <add name="cb-oauth2-log" type="System.Diagnostics.TextWriterTraceListener" initializeData="cb.oauth2.log" />
        </listeners>
      </source>
    </sources>
    <switches>
      <add name="MetaBrainz.CritiqueBrainz" value="All" />
    </switches>
  </system.diagnostics>
</configuration>
```

## Release Notes

These are available [on GitHub][release-notes].

[release-notes]: https://github.com/Zastai/MetaBrainz.CritiqueBrainz/releases
