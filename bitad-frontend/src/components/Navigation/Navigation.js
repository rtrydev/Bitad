import { useState, useEffect } from "react";
import { NavLink } from "react-router-dom";
import { NavHashLink } from "react-router-hash-link";
import Container from "../UI/Container";
import ImageAsLink from "../UI/ImageAsLink";
import Hamburger from "./Hamburger";

import siteLogo from "../../assets/images/reset-logo-red.svg";
import styles from "./Navigation.module.css";
import bg from "../../assets/css/Backgrounds.module.css";
import typography from "../../assets/css/Typography.module.css";
import { setNoScroll } from "../../hooks/custom-functions";

function Navigation() {
  const [isOpen, setIsOpen] = useState(false);

  useEffect(() => {
    setNoScroll(isOpen);
  }, [isOpen]);

  const handleHamburgerClick = () => {
    setIsOpen((prevState) => !prevState);
  };

  const handleLinkClick = () => {
    if (isOpen) {
      setIsOpen(false);
    }
  };

  return (
    <Container
      className={`${bg["white-background"]} ${
        isOpen ? styles["navigation--open"] : ""
      } `}
    >
      <nav className={styles.navigation}>
        <div className={styles.navigation__element}>
          <ImageAsLink
            to="/"
            src={siteLogo}
            alt="Reset Logo"
            onClick={handleLinkClick}
          />
        </div>
        <div className={styles.navigation__element}>
          <Hamburger isOpen={isOpen} onClick={handleHamburgerClick} />
          <ul>
            <li>
              <NavLink
                to="/"
                onClick={handleLinkClick}
                className={typography["nav-link"]}
              >
                O konferencji
              </NavLink>
            </li>
            <li>
              <NavHashLink
                to="/#sponsors"
                onClick={handleLinkClick}
                className={typography["nav-link"]}
              >
                Sponsorzy
              </NavHashLink>
            </li>
            <li>
              <NavHashLink
                to="/agenda#agenda"
                onClick={handleLinkClick}
                className={typography["nav-link"]}
              >
                Agenda
              </NavHashLink>
            </li>
            {!process.env.REACT_APP_ENABLE_REGISTRATION && (
              <li>
                <NavLink
                  to="/registration"
                  onClick={handleLinkClick}
                  className={`${typography["nav-link"]} ${typography.button} ${styles["button--hide"]}`}
                >
                  Rejestracja
                </NavLink>
              </li>
            )}
          </ul>
        </div>
      </nav>
    </Container>
  );
}

export default Navigation;
