import logo from './logo.svg';
import './App.css';

import{Home} from "./Home";
import{Deliveries} from "./MyEssence/Deliveries";
import{Employees} from "./MyEssence/Employees";
import{Goods} from "./MyEssence/Goods";
import{Supplier} from "./MyEssence/Supplier";
import {Navigation} from './Navigation';

import {BrowserRouter, Route, Switch} from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
    <div className="container">
      <h3 className="m-3 d-flex justify-content-center">
       My Pharmacy
     </h3>
     <Navigation/>

<Switch>
  <Route path='/' component={Home} exact/>
  <Route path='/MyEssence/Deliveries' component={Deliveries}/>
  <Route path='/MyEssence/Employees' component={Employees}/>
  <Route path='/MyEssence/Goods' component={Goods}/>
  <Route path='/MyEssence/Supplier' component={Supplier}/>
</Switch>
    </div>
    </BrowserRouter>
  );
}

export default App;
