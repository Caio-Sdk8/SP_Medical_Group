import React from 'react';
import ReactDOM from 'react-dom';
import Login from './Pages/Login/login'
import Home from './Pages/Home/App'
import './index.css';
import Testin from './Pages/Consultas/consultas';
import reportWebVitals from './reportWebVitals';
import {
  Route,
  BrowserRouter as Router,
  Redirect,
  Switch,
} from 'react-router-dom';


const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Home} />
        <Route path="/login" component={Login} />
        <Route path="/Consultas" component={Testin} /> 
      </Switch>
    </div>
  </Router>
);

ReactDOM.render(routing, document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
