import React, { Component } from 'react';
import { DateRangePicker } from 'react-dates';

class Filter extends Component {
    constructor(props) {
        super(props);
        this.state = {
            startDate: null,
            endDate: null,
            focusedInput: null
        }
    }

    render() {
        return (
            <div>
                <p className="f3">{'I can find the cheapest hotel. Give me a try.'}</p>
                <div className="center br-4 shadow-2 pa4 w-50">
                    <DateRangePicker
                        startDateId="startDate"
                        endDateId="endDate"
                        startDate={this.state.startDate}
                        endDate={this.state.endDate}
                        onDatesChange={({ startDate, endDate }) => { this.setState({ startDate, endDate }) }}
                        focusedInput={this.state.focusedInput}
                        onFocusChange={(focusedInput) => { this.setState({ focusedInput }) }}
                    />
                    {/* <input className="f4 pa2 w-80 bw0" type="text" onChange={onInputChange} /> */}
                    {/* <button className="f4 grow w-20 link ph3 pv2 dib white bg-light-purple ma0 bw0"
                        onClick={onButtonClick}>
                        Search
                    </button> */}
                </div>
            </div>
        );
    }
}

export default Filter;