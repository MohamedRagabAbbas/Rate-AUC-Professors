import logo from "./logo.svg";
import "./App.css";
import NavBar from "./components/NavBar";
import Feed from "./pages/feed";
import TestingRouting from "./pages/professors";
import NotFound from "./pages/notFound";
import { BrowserRouter, Routes, Route } from "react-router-dom";

// const AppContainer = styled.div`
//   max-width: 1200px;
//   margin: 0 auto;
// `;

function App() {
  return (
    <div>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Feed />} />
          <Route path="/home" element={<Feed />} />
          <Route path="/feed" element={<Feed />} />
          <Route path="/professors" element={<TestingRouting />} />
          <Route path="*" element={<NotFound />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
