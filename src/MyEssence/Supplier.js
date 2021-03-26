 
import React,{Component} from 'react';
import {Table} from 'react-bootstrap';
import {Button,ButtonToolbar} from 'react-bootstrap';
import {AddSupModal} from '../AddSupModal';
import {EditSupModal} from '../EditSupModal';


export class Supplier extends Component{
    constructor(props){
        super(props);
        this.state={sup:[],addModalShow:false, editModalShow:false}  
    }
    refreshList(){
        fetch('http://localhost:5000/api/Supplier')
        .then(response=>response.json())
        .then(data=>{
            this.setState({sup:data});
        });
    }
    componentDidMount(){
        this.refreshList();
    }
    componentDidUpdate(){
        this.refreshList();
    }
    deleteSup(supid){
        if(window.confirm('Are you sure?')){
            fetch("http://localhost:5000/api/Supplier/"+supid,{
                method:'DELETE',
                header:{'Accept':'application/json',
            'Content-Type':'application/json'}
            })
        }
    }
    render(){
        const {sup,supid,supname,supcity,supcunt}=this.state;
        let addModalClose=()=>this.setState({addModalShow:false});
        let editModalClose=()=>this.setState({editModalShow:false});
        return(
            <div>
             <Table className="mt-4" striped bordered hover size="sm">
                   <thead>
                       <tr>
                       <th> IdSupplier</th>
                       <th>NameSupplier</th>
                       <th>CitySupplier</th>
                       <th>CountrySupplier</th>
                    
                  </tr> 
                  </thead>
            <tbody>
                   {
                   sup.map(su=>
                    <tr key={su.IdSupplier}>
                        <td>{su.IdSupplier}</td>
                        <td>{su.NameSupplier}</td>
                        <td>{su.CitySupplier}</td>
                        <td>{su.CountrySupplier}</td>
                    <td>
              <ButtonToolbar>
    <Button className="mr-2" variant="info"
    onClick={()=>this.setState({editModalShow:true,
        supid:su.IdSupplier,supname:su.NameSupplier,supcity:su.CitySupplier,supcunt:su.CountrySupplier})}>
            Edit
        </Button>
        <Button className="mr-2" variant="danger"
    onClick={()=>this.deleteSup(su.IdSupplier)}>
            Delete
        </Button>
        <EditSupModal show={this.state.editModalShow}
        onHide={editModalClose}
        supid={supid}
        supname={supname}
        supcity={supcity} 
        supcunt={supcunt}/>
        </ButtonToolbar>
                                </td>
                            </tr>)}
                    </tbody>
                </Table>
                <ButtonToolbar>
                    <Button variant='primary'
                    onClick={()=>this.setState({addModalShow:true})}>
                    Add Supplier</Button>
                    <AddSupModal show={this.state.addModalShow}
                    onHide={addModalClose}/>
                </ButtonToolbar>
            </div>
        )
    }
}