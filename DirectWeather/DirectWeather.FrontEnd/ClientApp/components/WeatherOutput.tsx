import * as React from 'react';
import * as Home from "./Home";
import Weather = Home.Weather;

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
                        <p>Country: {this.props.weather.Location.Country}</p>
                        <p>City: {this.props.weather.Location.City}</p>
                        <p>Humidity: {this.props.weather.Humidity}</p>
                        <p>Teperature: {this.props.weather.Temperature.Value} {this.props.weather.Temperature.Format}</p>
                    </div>
                );
            } else if (this.props.outputState === Home.WeatherOutputState.Searching) {
                return <div>Searching the forecast...</div>;
            } else if (this.props.outputState === Home.WeatherOutputState.InError) {
                return <div className="has-error"> {this.props.errorMessage}</div>;
            } 
        }

        return <div />;
    }
}