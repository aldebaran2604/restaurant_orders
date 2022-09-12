import React, { Component } from 'react';
import Card from 'react-bootstrap/Card';
import ListGroup from 'react-bootstrap/ListGroup';
import axios from 'axios';

export default class Pending extends Component {

    constructor(props) {
        super(props);
        this.state = {
            data: {},
            text: "Init"
        }
    }

    componentDidMount() {
        axios.get("https://localhost:7041/api/Orders")
        .then(res=> {
            this.setState({data: res});
        });
        this.setState({ text: "new text" });
    }

    initClick() {
        this.setState({ text: "Other text" });
    }

    render() {
        return (
            <div id='data-pending'>
                <p>{JSON.stringify(this.state)}</p>
                <button  onClick={this.initClick()} >
                    Click
                </button>
                <Card>
                    <Card.Header>
                        Titulo
                    </Card.Header>
                    <Card.Body>
                        <ListGroup variant="flush">
                            <ListGroup.Item>Cras justo odio</ListGroup.Item>
                            <ListGroup.Item>Dapibus ac facilisis in</ListGroup.Item>
                            <ListGroup.Item>Vestibulum at eros</ListGroup.Item>
                        </ListGroup>
                    </Card.Body>
                </Card>
            </div>
        );
    }
}