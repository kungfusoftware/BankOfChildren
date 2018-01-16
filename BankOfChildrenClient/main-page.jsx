import React from 'react';
import $ from 'jquery';
import ReactBootstrap from 'react-bootstrap';


class MainPage extends React.Component {
   constructor(props){
       super(props);
       this.state = { requestFailed: false , ChildrenInformation : null};
       this.retrieveDataAsynchronously = this.retrieveDataAsynchronously.bind(this);
   }
  
    retrieveDataAsynchronously(searchText){
        let _this = this;

        // Url of your website that process the data and returns a
        // that returns the data according to the sent text
        let url = "https://bankofchildren.azurewebsites.net/api/BankofChildrenAPI/Account/All";
        
        $.ajax({
            url: url,
            headers: {
                'Access-Control-Allow-Origin': '*'
            },
            type: "GET", /* or type:"GET" or type:"PUT" */
            dataType: "json",
            crossDomain : true,
            success: function (result) {
                 _this.setState({
                    ChildrenInformation: result,
                    requestFailed: false
                });
                console.log(result);
            },
            error: function () {
                console.log("error");
                _this.setState({
                    ChildrenInformation: null,
                    requestFailed: true
                });
            }
        });
    }

    componentDidMount()
    {
        this.retrieveDataAsynchronously("");
    }

  render() {
    if (!this.state.ChildrenInformation) return <p>Loading...</p>
    var childInfos = this.state.ChildrenInformation.map(function(child) {
        return <div className="row" key={child.id}>
                <div className="col">Name:</div><div className="col">{child.firstName} {child.lastName}</div>
                <div className="col">Balance</div><div className="col">{child.balance}</div>
             </div>;
    });
    return (
    <div className="table-active">
       {childInfos}
    </div>
    );
  }
}

export default MainPage;
