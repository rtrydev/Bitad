import { useState, useEffect } from "react";
import { NavLink } from "react-router-dom";
import { NavHashLink } from "react-router-hash-link";
import Container from "../UI/Container";
import HideOnScroll from "./HideOnScroll";
import Hamburger from "./Hamburger";
import siteLogo from "../../assets/images/reset-logo.svg";
import styles from "./Navigation.module.css";
import bg from "../../assets/css/Backgrounds.module.css";

function Navigation() {
  const [isOpen, setIsOpen] = useState(false);

  useEffect(() => {
    const html = document.querySelector("html");
    isOpen
      ? html.classList.add(styles["no-scroll"])
      : html.classList.remove(styles["no-scroll"]);
  }, [isOpen]);

  const handleHamburgerClick = () => {
    setIsOpen((prevState) => !prevState);
  };

  return (
    <HideOnScroll
      className={`${bg["white-background"]} ${
        isOpen ? styles["navigation--open"] : ""
      } `}
    >
      <Container>
        <nav className={styles.navigation}>
          <div className={styles.navigation__element}>
            <NavLink to="/">
              <img src={siteLogo} alt="Reset Logo" />
            </NavLink>
          </div>
          <div className={styles.navigation__element}>
            <Hamburger isOpen={isOpen} onClick={handleHamburgerClick} />
            <ul>
              <li>
                <NavLink to="/">O konferencji</NavLink>
              </li>
              <li>
                <NavHashLink to="/#sponsors">Sponsorzy</NavHashLink>
              </li>
              <li>
                <NavLink to="/agenda">Agenda</NavLink>
              </li>
              <li>
                <NavLink to="/registration">Rejestracja</NavLink>
              </li>
            </ul>
          </div>
        </nav>
      </Container>
    </HideOnScroll>
  );
}

export default Navigation;
