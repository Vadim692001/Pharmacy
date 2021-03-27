import React,{Component} from 'react';
import {Modal,Button, Row, Col, Form} from 'react-bootstrap';

export class EditGoodsModal extends Component{
    constructor(props){
        super(props);
        this.handleSubmit=this.handleSubmit.bind(this);
    }

    handleSubmit(event){
        event.preventDefault();
        fetch("http://localhost:5000/api/Goods",
        {
            method:'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                IdGoods:event.target.IdGoods.value,
                NameGoods:event.target.NameGoods.value,
                PriceGoods:event.target.PriceGoods.value,
                CountGoods:event.target.CountGoods.value
               
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
            Edit Goods
        </Modal.Title>
    </Modal.Header>
    <Modal.Body>

        <Row>
            <Col sm={6}>
                <Form onSubmit={this.handleSubmit}>
                <Form.Group controlId="IdGoods">
                        <Form.Label>IdGoods</Form.Label>
                        <Form.Control type="text" name="IdGoods" required
                        disabled
                        defaultValue={this.props.goodid} 
                        placeholder="NameGoods"/>
                    </Form.Group>

                    <Form.Group controlId="NameGoods">
                        <Form.Label>NameGoods</Form.Label>
                        <Form.Control type="text" name="NameGoods" required 
                        defaultValue={this.props.goodname}
                        placeholder="NameGoods"/>
                    </Form.Group>
                    <Form.Group controlId="CountGoods">
                        <Form.Label>CountGoods</Form.Label>
                        <Form.Control type="text" name="CountGoods" required 
                        defaultValue={this.props.goodcount}
                        placeholder="CountGoods"/>
                    </Form.Group>
                    <Form.Group controlId="PriceGoods">
                        <Form.Label>PriceGoods</Form.Label>
                        <Form.Control type="text" name="PriceGoods" required 
                        defaultValue={this.props.goodprice}
                        placeholder="PriceGoods"/>
                    </Form.Group>

                    <Form.Group>
                        <Button variant="primary" type="submit">
                            Update Goods
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