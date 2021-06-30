import Container from "./Container";
import { Link } from "react-router-dom";
import styles from "./MainHero.module.css";
import bg from "../../assets/css/Backgrounds.module.css";

function MainHero(props) {
  return (
    <Container className={bg["hero-background"]}>
      <header className={styles.hero}>
        <img src={props.imageSrc} alt={props.imageAlt} />
        <h4>{props.subtitle}</h4>
        <h1>{props.title}</h1>
        {props.linkText !== undefined && (
          <Link to={props.linkTo} className={styles.hero__link}>
            {props.linkText}
          </Link>
        )}
      </header>
    </Container>
  );
}

export default MainHero;
