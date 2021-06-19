import Navigation from "./components/Navigation/Navigation";
import { BrowserRouter, Switch, Route } from "react-router-dom";
import About from "./pages/About";
import Agenda from "./pages/Agenda";
import Details from "./pages/Details";
import Registration from "./pages/Registration";

function App() {
  return (
    <BrowserRouter>
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
    </BrowserRouter>
  );
}

export default App;
