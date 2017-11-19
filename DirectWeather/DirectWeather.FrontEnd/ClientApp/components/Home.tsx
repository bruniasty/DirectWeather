import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';
import { WeatherOutput } from "./WeatherOutput";


interface SearchDataState {
    country: string;
    city: string;
    isVisible : boolean
    weather: Weather;
}

export class Weather {
    Location: { Country: string, City: string };
    Temperature: { Format: string, Value: number };
    Humidity: number;

    constructor() {
        this.Location = { Country: "", City: "" };
        this.Temperature = { Format: "", Value: 0 },
            this.Humidity = 0;
    }
}

export class Home extends React.Component<RouteComponentProps<{}>, SearchDataState> {
    constructor(props: any) {
        super(props);
        this.state = { country: "", city: "", isVisible : false, weather: new Weather() };

        this.setCountry = this.setCountry.bind(this);
        this.setCity = this.setCity.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    setCountry(e: any) {
        this.setState({ country: e.target.value });
    }

    setCity(e: any) {
        this.setState({ city: e.target.value });
    }

    handleSubmit(event: any) {
        event.preventDefault();
        this.searchCommand(this.state.country, this.state.city);
    }

    searchCommand(country: string, city: string) {
        this.setState({ isVisible: false});
        fetch("http://localhost:5268/api/Weather/" + country + "/" + city)
            .then(response => response.json() as Promise<Weather>)
            .then(data => {
                this.setState({ weather: data });
                this.setState({ isVisible: true });
            });
    }

    public render() {
        return <div>
            <form onSubmit={this.handleSubmit}>
                <input placeholder="Country:" type="text" value={this.state.country} name="country" onChange={this.setCountry} />
                <input placeholder="City:" type="text" value={this.state.city} name="city" onChange={this.setCity} />
                <input type="submit" value="Submit" />
            </form>
            <WeatherOutput weather={this.state.weather} isVisible={this.state.isVisible}/>
        </div>;
    }
}