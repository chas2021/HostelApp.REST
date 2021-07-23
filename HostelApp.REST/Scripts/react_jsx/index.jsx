var ReactDOM = require('react-dom');
var React = require('react');
import DataTable from 'react-data-table-component';
import Loader from 'react-loader-spinner';


const columns = [
    {
        name: 'Code',
        selector: 'ReservationCode',
		sortable: true,
    },
    {
        name: 'Price',
        selector: 'Amount',
		sortable: true,
    },
    {
        name: 'Сurrency',
        selector: 'Сurrency',
		sortable: true,
    },
    {
        name: 'Date Check-in',
        selector: 'DtCheckIn',
		sortable: true,
    },
	 {
        name: 'Date Departure',
        selector: 'DtDeparture',
		sortable: true,
    },
	 {
        name: 'Commission',
        selector: 'Commission',
		sortable: true,
    },
	 {
        name: 'Source',
        selector: 'Source',
		sortable: true,
    },
];

const columnsNested = [
    {
        name: 'Name',
        selector: 'Name',
    },
    {
        name: 'Surname',
        selector: 'Surname',
    },
];

class ClickButton extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
            error: null,
            isLoaded: true,
            items: []
        };
		this.onLoadData = this.onLoadData.bind(this);
		this.onRemoveUser = this.onRemoveUser.bind(this);
	}
    onLoadData(){
        this.setState({isLoaded: false});
        const requestOptions = {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        };
        fetch('/api/Reservation/GetReservations', requestOptions)
            .then(response => response.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        items: result
                    });
                },
                (error) => {
                    this.setState({
                        isLoaded: true,
                        error
                    });
                }
            );
    }
	
	onRemoveUser(userId) {
		console.log("Here Logic RemoveUser by id = " + userId);
    }
	
	render() {
		if (this.state.error) {
			return <div>Error: {this.state.error.message}</div>;
		}
		else if (!this.state.isLoaded) {
            return (
                <div>
                    <div className="loader">
                        <h1>Loading data, please wait</h1>
                    </div>
                    <div className="loader">
                        <Loader type="ThreeDots" color="#00BFFF" height="100" width="100"/>
                    </div>
                </div>
            );
        }
		else {
			return (<div>
			<div class="row justify-content-center"><div class="col-2">
			    <button type="button" className="btn btn-primary mt-4 mb-4" onClick={this.onLoadData}>Load data</button>
			</div></div>
                <DataTable
                    title="Rservations list"
                    columns={columns}
                    data={this.state.items}
					expandableRows
					expandableRowsComponent={<MyExpander onUserRemove={this.onRemoveUser}/>}
                />
			</div>
            );
        }
    }	
}

const MyExpander = props => <div>
                <h4>Guests list:</h4>
                <ul className="list-group mb-4">
                    {
                        props.data.Guests.map(function (currUser) {
                            return <User key={currUser.Id} user={currUser} UserRemove={props.onUserRemove}/>
                        })
                    }
                </ul>
            </div>
//const MyExpander = props => <DataTable title="Guests list" columns={columnsNested} data={props.data.Guests} />

class User extends React.Component {

    constructor(props) {
        super(props);
        this.state = { user: props.user };
        this.onClick = this.onClick.bind(this);
    }
    onClick(e) {
        this.props.UserRemove(this.state.user.Id);
    }
    render() {
        return <li className="list-group-item">
		
		<div className="row">
            <div className="col-md-2">{this.state.user.Name}</div>
            <div className="col-md-2">{this.state.user.Surname}</div>
            <div className="col-md-2">{this.state.user.Email}</div>
            <div className="col-md-2">{this.state.user.PhoneNumber}</div>
            <div className="col-md-2">{this.state.user.Adress}</div>
            <div className="col-md-2"><button type="button" className="btn btn-secondary" onClick={this.onClick}>Удалить</button></div>
        </div>
        </li>;
    }
}
          
ReactDOM.render(<ClickButton />, document.getElementById("app"))
