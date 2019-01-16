# Weather

Xamarin.Forms learning project

## Running it

Just follow the generic procedures to set up Xamarin on your local environment. No additional steps are required AFAIK.

## Tech stack

- [Xamarin.Forms](https://github.com/xamarin/Xamarin.Forms)
- [Xamarin.Essentials](https://github.com/xamarin/Essentials)
- [sqlite-net-pcl](https://github.com/praeclarum/sqlite-net)
- [RestEase](http://github.com/canton7/RestEase)
- [MVVMHelpers](https://github.com/jamesmontemagno/mvvm-helpers)

## Implemented

- Querying OpenWeatherApi for weather forecast by name and country, as well as latitude + longitude
- Querying device for current GPS location
- SQLite persistence service for forecasts
- Simple error handling - app exceptions display as toasts
- Splash image

## Ideas for extension

- Settings (with persistence, e.g. a BusinessParameters table in the database)
- Autocomplete in SearchPage (from OpenWeatherApi's city ID file)
- UI revamp (e.g. [like so](https://dribbble.com/shots/553778-thermometer))
- Show a weather representation icon depending on weather code from OpenWeatherApi response
- Storing OpenWeatherApi API key someplace safer
- Handle errors better?
- Switch from RestEase to something quicker (reflection costs performance)
- Performance in general
- Test iOS, different Android APIs
- Fix Release build for potential deployment e.g. on F-Droid
- Spinner on forecast result loading
