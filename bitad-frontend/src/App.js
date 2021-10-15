import Navigation from "./components/Navigation/Navigation";
import Footer from "./components/Footer/Footer";
import { BrowserRouter, Switch, Route } from "react-router-dom";
import ScrollMemory from "react-router-scroll-memory";
import About from "./pages/About/About";
import Agenda from "./pages/Agenda/Agenda";
import Details from "./pages/Details";
import Registration from "./pages/Registration/Registration";
import AccountActivation from "./pages/AccountActivation";
import AccountCreationInfo from "./pages/AccountCreationInfo";
import AccountRestartPassword from "./pages/AccountRestartPassword/AccountRestartPassword";

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
        {!process.env.REACT_APP_ENABLE_REGISTRATION && (
          <Route path="/registration">
            <Registration />
          </Route>
        )}
        <Route path="/account-activation/:code">
          <AccountActivation />
        </Route>
        <Route path="/account-creation-info/success">
          <AccountCreationInfo />
        </Route>
        <Route path="/account-creation-info/error">
          <AccountCreationInfo
            title="Coś poszło nie tak"
            description="Spróbuj ponownie później"
          />
        </Route>
        <Route path="/account-reset-password-info/success">
          <AccountCreationInfo title="Hasło zostało zmienione" description="" />
        </Route>
        <Route path="/account-reset-password-info/error">
          <AccountCreationInfo
            title="Coś poszło nie tak"
            description="Kod do odzyskiwania konta został już wykorzystany"
          />
        </Route>
        <Route path="/password-reset/:code">
          <AccountRestartPassword />
        </Route>
      </Switch>
      <Footer />
    </BrowserRouter>
  );
}

export default App;
