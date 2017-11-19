import * as React from 'react';

export interface LayoutProps {
    children?: React.ReactNode;
}

export class Layout extends React.Component<LayoutProps, {}> {
    public render() {
        return <div className='container'>

            <header className="App-header">
                <div className="App-logo" />
                <h1 className="App-title">Welcome to DirectWeather</h1>
            </header>

            {this.props.children}
        </div>;
    }
}
