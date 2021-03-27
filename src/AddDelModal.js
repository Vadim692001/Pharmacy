import React,{Component} from 'react';
import {Modal,Button, Row, Col, Form,Image} from 'react-bootstrap';

export class AddDelModal extends Component{
    constructor(props){
        super(props);
        this.state={emps:[]};
        // this.state={good:[]};
        // this.state={sup:[]};
        this.handleSubmit=this.handleSubmit.bind(this);
      
    }

    

    componentDidMount(){
        fetch("http://localhost:5000/api/Deliveries")
        .then(response=>response.json())  
        .then(data=>{
            this.setState({emps:data});
            // this.setState({good:data}),
            // this.setState({sup:data});
        }
        );
    }

    handleSubmit(event){
        event.preventDefault();
        fetch("http://localhost:5000/api/Deliveries",{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
               
                IdEmployees:event.target.IdEmployees.value,
                IdGoods:event.target.IdGoods.value,
                IdSupplier:event.target.IdSupplier.value,
                CountDeliveries:this.CountDeliveries,
                PricePurchase:event.target.PricePurchase.value,
                Data:event.target.Data.value

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
            Add Del
        </Modal.Title>
    </Modal.Header>
    <Modal.Body>

        <Row>
            <Col sm={6}>
                <Form onSubmit={this.handleSubmit}>
                    
                <Form.Group controlId="IdEmployees">
                        <Form.Label>IdEmployees</Form.Label>
                        <Form.Control as="select">
                        {this.state.emps.map(emp=>
                            <option key={emp.IdEmployees}>{emp.IdEmployees}</option>)}
                        </Form.Control>
                    </Form.Group>
                     <Form.Group controlId="IdGoods">
                        <Form.Label>IdGoods</Form.Label>
                        <Form.Control as="select">
                        {this.state.emps.map(go=>
                            <option key={go.IdGoods}>{go.IdGoods}</option>)}
                        </Form.Control>
                    </Form.Group>
                    <Form.Group controlId="IdSupplier">
                        <Form.Label>IdSupplier</Form.Label>
                        <Form.Control as="select">
                        {this.state.emps.map(su=>
                            <option key={su.IdSupplier}>{su.IdSupplier}</option>)}
                        </Form.Control>
                    </Form.Group>  
                    <Form.Group controlId="CountDeliveries">
                    <Form.Label>CountDeliveries</Form.Label>
                    <Form.Control type="text" name="CountDeliveries" required 
                    placeholder="CountDeliveries"/>
                </Form.Group>
                <Form.Group controlId="PricePurchase">
                    <Form.Label>PricePurchase</Form.Label>
                    <Form.Control type="text" name="PricePurchase" required 
                    placeholder="PricePurchase"/>
                </Form.Group>
    
                    <Form.Group controlId="Data">
                        <Form.Label>DateOfJoining</Form.Label>
                        <Form.Control 
                        type="date"
                        name="Data"
                        required
                        placeholder="Data"
                        />
                       
                        
                    </Form.Group>

                    <Form.Group>
                        <Button variant="primary" type="submit">
                            Add Del
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