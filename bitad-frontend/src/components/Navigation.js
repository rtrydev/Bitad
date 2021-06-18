import { useState, useEffect } from "react";
import Container from "./UI/Container";
import HideOnScroll from "./HideOnScroll";
import Hamburger from "./Hamburger";
import siteLogo from "../assets/images/reset-logo.svg";
import styles from "./Navigation.module.css";
import bg from "../assets/css/modules/Backgrounds.module.css";

function Navigation() {
  const [isOpen, setIsOpen] = useState(false);

  useEffect(() => {
    const html = document.querySelector("html");
    isOpen
      ? html.classList.add("no-scroll")
      : html.classList.remove("no-scroll");
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
      <Container className="">
        <nav className={styles.navigation}>
          <div className={styles.navigation__element}>
            <a href="#">
              <img src={siteLogo} alt="Reset Logo" />
            </a>
          </div>
          <div className={styles.navigation__element}>
            <Hamburger isOpen={isOpen} onClick={handleHamburgerClick} />
            <ul>
              <li>
                <a href="#">O konferencji</a>
              </li>
              <li>
                <a href="#">Sponsorzy</a>
              </li>
              <li>
                <a href="#">Agenda</a>
              </li>
              <li>
                <a href="#">Rejestracja</a>
              </li>
            </ul>
          </div>
        </nav>
      </Container>
    </HideOnScroll>
  );
}

export default Navigation;
