import logo from "./logo.svg";
import "./App.css";
import NavBar from "./components/NavBar";
import Departments from "../src/components/departments.js";
// const AppContainer = styled.div`
//   max-width: 1200px;
//   margin: 0 auto;
// `;

function App() {
  return (
    <div>
      <NavBar />
      {/* Your app content goes here */
      <Departments />
      }
    </div>
  );
}

export default App;
