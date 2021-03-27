  
import React,{Component} from 'react';

export class Home extends Component{
   
    render(){
        return(
            <div className="mt-5 d-flex justify-content-left">
                This is Home page. Щось корине:)
            </div>
        )
    }
}
function refreshList(){
        
    fetch('http://localhost:3000/api/Empoyees')
    .then(response=>console.log(response))
    // .then(data=>{
    //     this.setState({emps:data});
    
}
  refreshList();