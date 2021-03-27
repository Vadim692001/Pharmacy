import React,{Component} from 'react';
import {Table} from 'react-bootstrap';
import{Employees} from "../MyEssence/Employees";
import {Button,ButtonToolbar} from 'react-bootstrap';
import {AddDelModal} from '../AddDelModal';
import {EditDelModal} from '../EditDelModal';

export class Deliveries extends Component{

    constructor(props){
        super(props);
        this.state={dels:[], addModalShow:false, editModalShow:false}
    }

    refreshList(){
        fetch("http://localhost:5000/api/Deliveries")
        .then(response=>response.json())
        .then(data=>{
            this.setState({dels:data});
        });
    }

    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate(){
        this.refreshList();
    }

    deleteDel(delid){
        if(window.confirm('Are you sure?')){
            fetch("http://localhost:5000/api/Deliveries/"+delid,{
                method:'DELETE',
                header:{'Accept':'application/json',
               'Content-Type':'application/json'}
            })
        }
    }
    render(){
        const {dels, delid,delcou,delpr,em,god,supt,dat}=this.state;
        let addModalClose=()=>this.setState({addModalShow:false});
        let editModalClose=()=>this.setState({editModalShow:false});
        return(
            <div >
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>IdOperation</th>
                        <th>NameEmployees</th>
                        <th>IdGoods</th>
                        <th>IdSupplier</th>
                        <th>CountDeliveries</th>
                        <th>PricePurchase</th>
                        <th>Data</th>
                        <th>Options</th>
                        </tr>
                    </thead>
                    <tbody>
                        {dels.map(del=>
                            <tr key={del.IdOperation}>
                                <td>{del.IdOperation}</td>
                                <td>{del.IdEmployees}</td>
                                <td>{del.IdGoods}</td>
                                <td>{del.IdSupplier}</td>
                                <td>{del.CountDeliveries}</td>
                                <td>{del.PricePurchase}</td>
                                <td>{del.Data}</td>
                                <td>
<ButtonToolbar>
    <Button className="mr-2" variant="info"
    onClick={()=>this.setState({editModalShow:true,
        delid:del.IdOperation,em:del.IdEmployees,god:del.IdGoods,sup:del.IdSupplier,delcou:del.CountDeliveries,
        delpr:del.PricePurchase,dat:del.Data})}>
            Edit
        </Button>

        <Button className="mr-2" variant="danger"
        onClick={()=>this.deleteDel(del.IdOperation)}>
            Delete
        </Button>

        <EditDelModal show={this.state.editModalShow}
        onHide={editModalClose}
        delid={delid}
        em={em}
        god={god}
        supt={supt}
        delcou={delcou}
        delpr={delpr}
        dat={dat}
        />
</ButtonToolbar>

                                </td>

                            </tr>)}
                    </tbody>

                </Table>

                <ButtonToolbar>
                    <Button variant='primary'
                    onClick={()=>this.setState({addModalShow:true})}>
                    Add Deliveries</Button>

                    <AddDelModal show={this.state.addModalShow}
                    onHide={addModalClose}/>
                </ButtonToolbar>
            </div>
        )
    }
}