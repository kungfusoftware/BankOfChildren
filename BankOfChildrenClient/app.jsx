import ReactDOM from 'react-dom';
import React from 'react';
import Greeter from './greeter';
import MainPage from './main-page';

let greeter = (
  <div>
  <Greeter />
  <MainPage />
  </div>
)

ReactDOM.render(greeter, document.getElementById('app'));
