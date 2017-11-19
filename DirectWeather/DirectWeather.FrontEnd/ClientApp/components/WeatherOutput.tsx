import * as React from 'react';
import * as Home from "./Home";
import Weather = Home.Weather;

interface WeatherProps {
    weather: Weather,
    isVisible : boolean;
}


export class WeatherOutput extends React.Component<WeatherProps, {}> {
    render() {
        if (this.props.isVisible) {
            return (
                <div>
                    <h3>Weather for:</h3>
                    <p>Country: {this.props.weather.Location.Country}</p>
                    <p>City: {this.props.weather.Location.City}</p>
                    <p>Humidity: {this.props.weather.Humidity}</p>
                    <p>Teperature: {this.props.weather.Temperature.Value} {this.props.weather.Temperature.Format}</p>
                </div>
            );
        } else {
            return <div/>;
        }
    }
}