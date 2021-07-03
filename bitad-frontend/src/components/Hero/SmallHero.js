import React from "react";
import { Link } from "react-router-dom";
import Container from "../UI/Container";
import Columns from "../UI/Columns";
import styles from "./Hero.module.css";
import bg from "../../assets/css/Backgrounds.module.css";
import typography from "../../assets/css/Typography.module.css";

export default function SmallHero(props) {
  return (
    <Container className={bg["hero-background--small"]}>
      <header className={styles.hero}>
        <Columns columns="2" reverse={true}>
          <div>
            <h4>{props.subtitle}</h4>
            <h1>{props.title}</h1>
            {props.linkText !== undefined && (
              <Link to={props.linkTo} className={styles.hero__link}>
                {props.linkText}
              </Link>
            )}
          </div>
          <div>
            <img
              src={props.imageSrc}
              alt={props.imageAlt}
              className={styles["small-hero__image"]}
            />
          </div>
        </Columns>
      </header>
    </Container>
  );
}
