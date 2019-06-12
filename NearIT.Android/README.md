# NearIT Android Xamarin Binding

A Xamarin binding ports an Android (or Java) library to C#. The input format is a aar (or a jar) and the output is a dll.

## Ternary dependencies

NearIT has various dependencies: Altbeacon, google services, gson, httpclient, firebase, compat,...

Since Near has ternary dependecies, those need to be included in this project in one of the following ways:
- Statically as jars: in one binding there can only be one *aar* and the spot is taken by the Near *aar* so if a ternary dependency is a *jar* it can be included in the Jars directory (build action: `EmbeddedReferenceJar`). The project will build only if the *aar* and all *jar*s C# conversions are successful. 
- As a reference: if a ternary *aar* dependency has already been binded as a *dll*, it can be statically included as a *dll* inside the `References`. Dependencies needs to be included as a reference if they are originally *aar*s (for example AltBeacon) and there is not a DLL out there available to use.
- As a package: don't do it, it appears that these dependencies are not actually included in your binding if added as a package. If a package is distributed on Nuget, you can download the .nupkg and extract the dll.

**Important** the following dependencies are not to included in the binding project:
```xml
<dependencies>
      <dependency id="Xamarin.Android.Support.Compat" version="26.1.0.1" />
      <dependency id="Xamarin.Firebase.Messaging" version="60.1142.0-beta2" />
      <dependency id="Xamarin.GooglePlayServices.Location" version="60.1142.0-beta2" />
      <dependency id="Xamarin.Forms" version="2.5.1.444934" />
</dependencies>
```
and are NOT included in the binding dll. As a consequence, a Xamarin Android app that just adds the NearIT Android dll won't  work until those dependencies are manually added in `Packages`.
A tipical NearIT integrator will NOT add this dll directly in his app, but it'll add the NearIT Xamarin bridge with NUGET, which includes the above dependencies automatically.

## New release checklist

* Account for new ternary dependencies of the native Near SDK
* Check for Altbeacon, Gson, Async-http, Orpheus new versions