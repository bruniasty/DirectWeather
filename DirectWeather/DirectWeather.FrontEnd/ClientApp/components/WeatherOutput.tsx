import * as React from 'react';
import * as Home from "./Home";
import Weather = Home.Weather;

const reactLogo = require("./../css/weather.png");

interface WeatherProps {
    weather: Weather,
    outputState: Home.WeatherOutputState;
    errorMessage: string;
}

export class WeatherOutput extends React.Component<WeatherProps, {}> {

    render() {
        if (this.props != null) {
            if (this.props.outputState === Home.WeatherOutputState.Visible) {
                return (
                    <div>
                        <h3>Weather</h3>
                        <img src={reactLogo} height="64" />
                        <p>Country: {this.props.weather.Location.Country}</p>
                        <p>City: {this.props.weather.Location.City}</p>
                        <p>Humidity: <label id="HumidityOutput">{this.props.weather.Humidity}</label></p>
                        <p>Teperature: <label id="TemperatureOutput">{this.props.weather.Temperature.Value}</label> {this.props.weather.Temperature.Format}</p>
                    </div>
                );
            } else if (this.props.outputState === Home.WeatherOutputState.Searching) {
                return <div>Searching the forecast...</div>;
            } else if (this.props.outputState === Home.WeatherOutputState.InError) {
                return <div className='has-error'> {this.props.errorMessage}</div>;
            } 
        }

        return <div />;
    }
}