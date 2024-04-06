import logo from "./logo.svg";
import "./App.css";
import NavBar from "./components/NavBar";
import Feed from "./pages/feed";

// const AppContainer = styled.div`
//   max-width: 1200px;
//   margin: 0 auto;
// `;

function App() {
  return (
    <div /*style={{ backgroundColor: "#191919", height: "100vh " }}*/>
      <NavBar />
      <div
        style={{
          width: "800px",
          margin: "auto",
        }}
      >
        <Feed />
      </div>
    </div>
  );
}

export default App;
