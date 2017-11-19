import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';
import { WeatherOutput } from "./WeatherOutput";


interface SearchDataState {
    country: string;
    city: string;
    weather: Weather;
    outputState: WeatherOutputState;
    errorMessage: string;
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

export enum WeatherOutputState {
    NotVisible,
    Visible,
    InError
}


export class Home extends React.Component<RouteComponentProps<{}>, SearchDataState> {
    constructor(props: any) {
        super(props);
        this.state = { country: "", city: "", weather: new Weather(), outputState: WeatherOutputState.NotVisible, errorMessage: "" };

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
        this.setState({ outputState: WeatherOutputState.NotVisible });
        this.setState({ weather: new Weather() });

        fetch("http://localhost:5268/api/Weather/" + country + "/" + city)
            .then(response => {
                if (response.status === 200)
                    return response.json() as Promise<Weather>;

                if (response.status === 500)
                    throw new Error("City or country not found. Please try again.");
                
                if (response.status === 404)
                    throw new Error("Please fill city and country fields. If error keep displays, check the website http://localhost:5268 is online.");
                
                throw new Error(response.statusText);
            })
            .then(data => {
                this.setState({ weather: data });
                this.setState({ outputState: WeatherOutputState.Visible });
            })
            .catch(reason => {
                this.setState({ outputState: WeatherOutputState.InError });
                this.setState({ errorMessage: reason.message });
            });
    }

    public render() {
        return <div>
            <form onSubmit={this.handleSubmit}>
                <input placeholder="Country:" type="text" value={this.state.country} name="country" onChange={this.setCountry} />
                <input placeholder="City:" type="text" value={this.state.city} name="city" onChange={this.setCity} />
                <input type="submit" value="Submit" />
            </form>
            <WeatherOutput weather={this.state.weather} outputState={this.state.outputState} errorMessage={this.state.errorMessage}/>
        </div>;
    }
}