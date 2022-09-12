import './App.css';
import Tab from 'react-bootstrap/Tab';
import Tabs from 'react-bootstrap/Tabs';
//import Swal from 'sweetalert2';
//import withReactContent from 'sweetalert2-react-content';
import Pending from './Components/Pending';
import InProcess from './Components/InProcess';
import Completed from './Components/Completed';
import Delivered from './Components/Delivered';
import Canceled from './Components/Canceled';

//const MySwal = withReactContent(Swal)

function App() {
  return (
    <div className='App' class="container">
      <Tabs
        defaultActiveKey="Pending"
        id="app-tabs"
        className="mb-3">
        <Tab eventKey="Pending" title="Pending">
          <Pending />
        </Tab>
        <Tab eventKey="InProcess" title="In Process">
          <InProcess />
        </Tab>
        <Tab eventKey="Completed" title="Completed">
          <Completed />
        </Tab>
        <Tab eventKey="Delivered" title="Delivered">
          <Delivered />
        </Tab>
        <Tab eventKey="Canceled" title="Canceled">
          <Canceled />
        </Tab>
      </Tabs>
    </div>
  );
}

export default App;
