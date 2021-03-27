
import React,{Component} from 'react';
import {Table} from 'react-bootstrap';
import {Button,ButtonToolbar} from 'react-bootstrap';
import {AddGoodsModal} from '../AddGoodsModal';
import {EditGoodsModal} from '../EditGoodsModal';


export class Goods extends Component{
    constructor(props){
        super(props);
        this.state={good:[],addModalShow:false, editModalShow:false}  
    }
    refreshList(){
        fetch('http://localhost:5000/api/Goods')
        .then(response=>response.json())
        .then(data=>{
            this.setState({good:data});
        });
    }
    componentDidMount(){
        this.refreshList();
    }
    componentDidUpdate(){
        this.refreshList();
    }
    deleteGoods(goodid){
        if(window.confirm('Are you sure?')){
            fetch("http://localhost:5000/api/Goods/"+goodid,{
                method:'DELETE',
                header:{'Accept':'application/json',
                'Content-Type':'application/json'}
            })
        }
    }
  

    
    render(){
        const {good,goodid,goodname,goodcount,goodprice}=this.state;
        let addModalClose=()=>this.setState({addModalShow:false});
        let editModalClose=()=>this.setState({editModalShow:false});
        return(
            <div>
             <Table className="mt-4" striped bordered hover size="sm">
             
                   <thead>
                       <tr>
                       <th>IdGoods</th>
                       <th>NameGoods</th>
                       <th>CountGoods</th>
                       <th>PriceGoods</th>
                       <th>Options</th>
                  </tr> 
                  </thead>
            <tbody>
                   {
                   good.map(go=>
                    <tr key={go.IdGoods}>
                        <td>{go.IdGoods}</td>
                        <td>{go.NameGoods}</td>
                        <td>{go.CountGoods}</td>
                        <td>{go.PriceGoods}</td>
                    <td>
              <ButtonToolbar>
    <Button className="mr-2" variant="info"
    onClick={()=>this.setState({editModalShow:true,
        goodid:go.IdGoods,goodname:go.NameGoods,goodcount:go.CountGoods,goodprice:go.PriceGoods})}>
            Edit
        </Button>
        <Button className="mr-2" variant="danger"
        onClick={()=>this.deleteGoods(go.IdGoods)}>
            Delete
        </Button>
        <EditGoodsModal show={this.state.editModalShow}
        onHide={editModalClose}
        goodid={goodid}
        goodname={goodname}
        goodcount={goodcount} 
        goodprice={goodprice}/>
        </ButtonToolbar>
                                </td>
                            </tr>)}
                    </tbody>
                </Table>
                <ButtonToolbar>
                    <Button variant='primary'
                    onClick={()=>this.setState({addModalShow:true})}>
                        
                    Add Goods</Button>
                    <AddGoodsModal show={this.state.addModalShow}
                    onHide={addModalClose}/>
                </ButtonToolbar>
            </div>
        )
    }
}