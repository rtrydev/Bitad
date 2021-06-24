import { useState, useEffect } from "react";
import { NavLink } from "react-router-dom";
import { NavHashLink } from "react-router-hash-link";
import Container from "../UI/Container";
import ImageAsLink from "../UI/ImageAsLink";
import HideOnScroll from "./HideOnScroll";
import Hamburger from "./Hamburger";

import siteLogo from "../../assets/images/reset-logo-red.svg";
import styles from "./Navigation.module.css";
import bg from "../../assets/css/Backgrounds.module.css";
import typography from "../../assets/css/Typography.module.css";

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

  const handleLinkClick = () => {
    if (isOpen) {
      setIsOpen(false);
    }
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
                  // scroll={(e) => {
                  //   e.scrollIntoView();
                  //   e.classList.add(bg.highlight);
                  //   setTimeout(() => e.classList.remove(bg.highlight), 4000);
                  // }}
                >
                  Sponsorzy
                </NavHashLink>
              </li>
              <li>
                <NavLink
                  to="/agenda"
                  onClick={handleLinkClick}
                  className={typography["nav-link"]}
                >
                  Agenda
                </NavLink>
              </li>
              <li>
                <NavLink
                  to="/registration"
                  onClick={handleLinkClick}
                  className={`${typography["nav-link"]} ${typography.button}`}
                >
                  Rejestracja
                </NavLink>
              </li>
            </ul>
          </div>
        </nav>
      </Container>
    </HideOnScroll>
  );
}

export default Navigation;
