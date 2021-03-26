import React,{Component} from 'react';
import {Modal,Button, Row, Col, Form} from 'react-bootstrap';

export class EditEmployeesModal extends Component{
    constructor(props){
        super(props);
        this.handleSubmit=this.handleSubmit.bind(this);
    }

    handleSubmit(event){
        event.preventDefault();
        fetch("http://localhost:5000/api/Empoyees",
        {
            method:'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                IdEmployees:event.target.IdEmployees.value,
                SuernameEmployees:event.target.SuernameEmployees.value,
                NameEmployees:event.target.NameEmployees.value,
                MiddleNameEmployees:event.target.MiddleNameEmployees.value,
                Posada:event.target.Posada.value
               
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
            Edit Employees
        </Modal.Title>
    </Modal.Header>
    <Modal.Body>

        <Row>
            <Col sm={6}>
                <Form onSubmit={this.handleSubmit}>
                <Form.Group controlId="IdEmployees">
                        <Form.Label>IdEmployees</Form.Label>
                        <Form.Control type="text" name="IdEmployees" required
                        disabled
                        defaultValue={this.props.empid} 
                        placeholder="SuernameEmployees"/>
                    </Form.Group>

                    <Form.Group controlId="SuernameEmployees">
                        <Form.Label>SuernameEmployees</Form.Label>
                        <Form.Control type="text" name="SuernameEmployees" required 
                        defaultValue={this.props.empsorname}
                        placeholder="SuernameEmployees"/>
                    </Form.Group>
                    <Form.Group controlId="NameEmployees">
                        <Form.Label>NameEmployees</Form.Label>
                        <Form.Control type="text" name="NameEmployees" required 
                        defaultValue={this.props.empname}
                        placeholder="NameEmployees"/>
                    </Form.Group>
                    <Form.Group controlId="MiddleNameEmployees">
                        <Form.Label>MiddleNameEmployees</Form.Label>
                        <Form.Control type="text" name="MiddleNameEmployees" required 
                        defaultValue={this.props.empmid}
                        placeholder="MiddleNameEmployees"/>
                    </Form.Group>
                    <Form.Group controlId="Posada">
                        <Form.Label>Posada</Form.Label>
                        <Form.Control type="text" name="Posada" required 
                        defaultValue={this.props.emppos}
                        placeholder="Posada"/>
                    </Form.Group>

                    <Form.Group>
                        <Button variant="primary" type="submit">
                            Update Employees
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