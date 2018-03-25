import React from 'react';
import ReactDOM from 'react-dom';
import $ from 'jquery';
//import bootstrap from 'bootstrap';
import ReactBootstrap from 'react-bootstrap';
//import ReactBootstrap from 'react-bootstrap';


class MainPage extends React.Component {
   constructor(props){
       super(props);
       this.state = { requestFailed: false , ChildrenInformation : null, show: false};
       this.retrieveDataAsynchronously = this.retrieveDataAsynchronously.bind(this);

       this.handleShow = this.handleShow.bind(this);
       this.handleClose = this.handleClose.bind(this);
   }
   handleClose() {
    this.setState({ show: false });
  }

  handleShow() {
    this.setState({ show: true });
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
                <div className="col-lg-4 col-sm-4">{child.firstName} {child.lastName}</div>
                <div className="col-lg-4 col-sm-4">{child.balance}</div>
                <div className="col-lg-4 col-sm-4">
                <a href={`accountEdit.html?id=${child.id}`} >edit</a></div>
             </div>;
    });
    return (
    <div>
       <div className="row thead-dark" key="0"> 
       <div className="col-lg-4 col-sm-4"> <span style={{fontStyle: "10px", color: "#cccccc" }}>Name:</span></div>
       <div className="col-lg-4 col-sm-4">  <span style={{fontStyle: "10px", color: "#cccccc" }}>Balance</span></div>
       <div className="col-lg-4 col-sm-4"></div>

       </div>
       {childInfos}
       <Modal show={this.state.show} onHide={this.handleClose}>
          <Modal.Header closeButton>
            <Modal.Title>Modal heading</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <h4>Text in a modal</h4>
            <p>
              Duis mollis, est non commodo luctus, nisi erat porttitor ligula.
            </p>

            <h4>Overflowing text to show scroll behavior</h4>
            <p>
              Cras mattis consectetur purus sit amet fermentum. Cras justo odio,
              dapibus ac facilisis in, egestas eget quam. Morbi leo risus, porta
              ac consectetur ac, vestibulum at eros.
            </p>
            <p>
              Cras mattis consectetur purus sit amet fermentum. Cras justo odio,
              dapibus ac facilisis in, egestas eget quam. Morbi leo risus, porta
              ac consectetur ac, vestibulum at eros.
            </p>
            <p>
              Praesent commodo cursus magna, vel scelerisque nisl consectetur
              et. Vivamus sagittis lacus vel augue laoreet rutrum faucibus dolor
              auctor.
            </p>
            <p>
              Aenean lacinia bibendum nulla sed consectetur. Praesent commodo
              cursus magna, vel scelerisque nisl consectetur et. Donec sed odio
              dui. Donec ullamcorper nulla non metus auctor fringilla.
            </p>
          </Modal.Body>
          <Modal.Footer>
            <Button onClick={this.handleClose}>Close</Button>
          </Modal.Footer>
        </Modal>
    </div>
    );
  }
}

export default MainPage;
