import Container from "./Container";
import styles from "./MainHero.module.css";
import bg from "../../assets/css/Backgrounds.module.css";

function MainHero(props) {
  return (
    <Container className={bg["hero-background"]}>
      <header className={styles.hero}>
        <img src={props.imageSrc} alt={props.imageAlt} />
        <h4>{props.subtitle}</h4>
        <h1>{props.title}</h1>
        {props.button}
      </header>
    </Container>
  );
}

export default MainHero;
