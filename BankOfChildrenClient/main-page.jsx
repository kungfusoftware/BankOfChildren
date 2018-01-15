import React from 'react';

class MainPage extends React.Component {
   constructor(props){
       super(props);
       this.state = { Name : "Bill Sun" , Balance : 1000.00 };
       this.handleChange = this.handleChange.bind(this);
   }
    handleChange(value){
       event.preventDefault(); 
       this.setState({address: value});
    }
  render() {
    
    return (
    <div>
        <div className="Row">
            <div className="Column" > Name: </div>
            <div className="" >{this.state.Name}</div>
         </div>
         <div className="Row">
            <div> Balance </div>
            <div>{this.state.Balance}</div>
        </div>
    </div>
    );
  }
}

export default MainPage;
