  
import React,{Component} from 'react';
import {Table} from 'react-bootstrap';
import {Button,ButtonToolbar} from 'react-bootstrap';
import {AddEmployeesModal} from '../AddEmployeesModal';
import {EditEmployeesModal} from '../EditEmployeesModal';


export class Employees extends Component{
    constructor(props){
        super(props);
        this.state={emps:[], addModalShow:false, editModalShow:false}
    }
    refreshList(){
        
        fetch('http://localhost:5000/api/Employees')
        .then(response=>response.json())
        .then(data=>{
            this.setState({emps:data});
        });
    }
    componentDidMount(){
        this.refreshList();
    }
    componentDidUpdate(){
        this.refreshList();
    }
    deleteEmp(empid){
        if(window.confirm('Are you sure?')){
            fetch('http://localhost:5000/api/Employees/'+empid,{
                method:'DELETE',
                header:{'Accept':'application/json',
            'Content-Type':'application/json'}
            })
        }
    }
    sortEm()
    {
         fetch('http://localhost:5000/api/Employees/GetSortSuernameEmployees')
        .then(response=>response.json())
        .then(data=>{
            this.setState({emps:data});
        });
         
         
    }
    

    render(){
 
        const {emps, empid,empname,empsorname,empmid,emppos}=this.state;
        let addModalClose=()=>this.setState({addModalShow:false});
        let editModalClose=()=>this.setState({editModalShow:false});
      
        return(
            <div>
             <Table className="mt-4" striped bordered hover size="sm">
                   <thead>
                         <tr>
                            <th> IdEmployees</th>
                            <th onClick={()=>this.sortEm()} > SurnameEmployees</th>
                            <th>NameEmployees</th>
                            <th>MiddleNameEmployees</th>
                             <th>Posada</th>
                            <th>Options</th>
                         </tr> 
                  </thead>
                   <tbody>
                   {emps.map(emp=>
                    <tr key={emp.IdEmployees}>
                        <td>{emp.IdEmployees}</td>
                        <td>{emp.SuernameEmployees}</td>
                        <td>{emp.NameEmployees}</td>
                        <td>{emp.MiddleNameEmployees}</td>
                        <td>{emp.Posada}</td>     
                    <td>
                    <ButtonToolbar>
    <Button className="mr-2" variant="info"
    onClick={()=>this.setState({editModalShow:true,
        empid:emp.IdEmployees,empname:emp.NameEmployees,empsorname:emp.SuernameEmployees,empmid:emp.MiddleNameEmployees,
       emppos:emp.Posada})}>
            Edit
        </Button>

        <Button className="mr-2" variant="danger"
    onClick={()=>this.deleteEmp(emp.IdEmployees)}>
            Delete
        </Button>

        <EditEmployeesModal show={this.state.editModalShow}
        onHide={editModalClose}
        empid={empid}
        empname={empname}
        empsorname={empsorname}
        empmid={empmid}
        emppos={emppos}
        />
</ButtonToolbar>

                                </td>

                            </tr>)}
                    </tbody>

                </Table>

                <ButtonToolbar>
                    <Button variant='primary'
                    onClick={()=>this.setState({addModalShow:true})}>
                    Add Employee</Button>
                    <AddEmployeesModal show={this.state.addModalShow}
                    onHide={addModalClose}/>
                </ButtonToolbar>
            
                
            </div>
        )
    }
}