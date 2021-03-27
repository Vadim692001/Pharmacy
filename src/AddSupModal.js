import React,{Component} from 'react';
import {Modal,Button, Row, Col, Form} from 'react-bootstrap';

export class AddSupModal extends Component{
    constructor(props){
    super(props);
    this.handleSubmit=this.handleSubmit.bind(this);
}
handleSubmit(event){
    event.preventDefault();
    fetch("http://localhost:5000/api/Supplier",
    {
        method:'POST',
        headers:{
            'Accept':'application/json',
            'Content-Type':'application/json'
        },
        body:JSON.stringify({

            NameSupplier:event.target.NameSupplier.value,
            CitySupplier:event.target.CitySupplier.value,
            CountrySupplier:event.target.CountrySupplier.value
        })
    })
    .then(res=>res.json())
    .then((result)=>{
        alert(result);
    },
    (error)=>{
        alert('Failed');
    })
}
render(){
    return (
        <div className="container">
<Modal
{...this.props}
size="lg"
aria-labelledby="contained-modal-title-vcenter"
centered
>
<Modal.Header clooseButton>
    <Modal.Title id="contained-modal-title-vcenter">
        Add Supplier
    </Modal.Title>
</Modal.Header>
<Modal.Body>
    <Row>
        <Col sm={6}>
            <Form onSubmit={this.handleSubmit}>
                <Form.Group controlId="NameSupplier">
                    <Form.Label>NameSupplier</Form.Label>
                    <Form.Control type="text" name="NameSupplier" required 
                    placeholder="NameSupplier"/>
                </Form.Group>
                <Form.Group controlId="CitySupplier">
                    <Form.Label>CitySupplier</Form.Label>
                    <Form.Control type="text" name="CitySupplier" required 
                    placeholder="CitySupplier"/>
                </Form.Group>
                <Form.Group controlId="CountrySupplier">
                    <Form.Label>CountrySupplier</Form.Label>
                    <Form.Control type="text" name="CountrySupplier" required 
                    placeholder="CountrySupplier"/>
                </Form.Group>
                <Form.Group>
                    <Button variant="primary" type="submit">
                        Add Supplier
                    </Button>
                </Form.Group>
            </Form>
        </Col>
    </Row>
</Modal.Body>
<Modal.Footer>
    <Button variant="danger" onClick={this.props.onHide}>Close</Button>
</Modal.Footer>
</Modal>
        </div>
    )
}
}