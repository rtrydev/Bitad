import Container from "./UI/Container";
import MainButton from "./UI/MainButton";
import styles from "./MainHero.module.css";
import bg from "../assets/css/modules/Backgrounds.module.css";
import heroImage from "../assets/images/bitad-logo.svg";

function MainHero() {
  return (
    <Container className={bg["hero-background"]}>
      <header className={styles.hero}>
        <img src={heroImage} alt="Bitad Logo" />
        <h4>20 marca 2020, na terenie uczelni ATH w Bielsku-Białej</h4>
        <h1>Konferencja Informatyczna</h1>
        <MainButton>
          <a href="#">Zapisz się już dziś</a>
        </MainButton>
      </header>
    </Container>
  );
}

export default MainHero;
