import Navigation from "./components/Navigation/Navigation";
import Footer from "./components/Footer/Footer";
import { BrowserRouter, Switch, Route } from "react-router-dom";
import ScrollMemory from "react-router-scroll-memory";
import About from "./pages/About/About";
import Agenda from "./pages/Agenda";
import Details from "./pages/Details";
import Registration from "./pages/Registration";

function App() {
  return (
    <BrowserRouter>
      <ScrollMemory />
      <Navigation />
      <Switch>
        <Route exact path="/">
          <About />
        </Route>
        <Route path="/agenda">
          <Agenda />
        </Route>
        <Route path="/details">
          <Details />
        </Route>
        <Route path="/registration">
          <Registration />
        </Route>
      </Switch>
      <Footer />
    </BrowserRouter>
  );
}

export default App;
