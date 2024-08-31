import logo from './logo.svg';
import './App.css';
import Navbar from "./components/Navbar"
import { Routes, Route } from "react-router-dom";
import Contact from './components/Contact';
import Home from './components/Home';
import About from './components/About';

function App() {
  return (
    <div className="App">
      <Navbar />
      <Routes>
        <Route exact path="/" element={<Home />} />
        <Route exact path="/about" element={<About />} />
        <Route exact path="/contact" element={<Contact />} />
      </Routes>
    </div>
  );
}

export default App;
